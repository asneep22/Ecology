using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_beh : MonoBehaviour
{
    private Rigidbody2D _rb;

    private player_beh _player_beh;

    private Transform _player;


    private float _get_trash_distance;
    private bool _is_get;

    [HideInInspector] public AudioSource audioSource;

    [HideInInspector] public Transform _trash_tank;
    [HideInInspector] public trash_tank_beh _trash_tank_beh;
    [HideInInspector] public bool is_move_to_the_trash_tank;

    [HideInInspector] public trash_car car;
    [HideInInspector] public bool is_move_to_the_trash_car;

     public AudioClip sound;

    [Header("Trash tank propereties")]
    [SerializeField] private string _trash_type;
    [SerializeField] private float _trash_move_to_tank_speed = 8f;
    [SerializeField] private float _trash_count_distance = 0.5f;


    void Start()
    {
        //get rb
        _rb = GetComponent<Rigidbody2D>();

        //get objects
        _player = scene_manager.player.transform;

        //get scripts
        _player_beh = _player.GetComponent<player_beh>();

        //set propereties
        _get_trash_distance = _player_beh._get_trash_distnce;

        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (is_move_to_the_trash_tank)
        {

            Move_trash_to_the_tank(_trash_tank, _trash_tank_beh);

        }
        else if (is_move_to_the_trash_car)
        {

            Move_trash_to_the_car(_trash_tank_beh, car);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnActivity();
        }
    }

    public void OnActivity()
    {

        float distance = Vector2.Distance(_player.position, transform.position);

        if (distance <= _get_trash_distance)
        {
            if (!is_move_to_the_trash_tank)
            {
                Debug.Log("trash");
                Get_trash(_player_beh._SpringJoint2D);
            }
        }
    }

    private void Get_trash(SpringJoint2D _SpringJoint2D)
    {
        if (!_is_get)
        {
            audioSource.PlayOneShot(sound);
            _SpringJoint2D.connectedBody = _rb;
            _SpringJoint2D.enabled = true;
            _player_beh._trash_beh = this;
            _is_get = true;
        }
        else
        {
            Put_trash(_SpringJoint2D);
        }

    }

    private void Put_trash(SpringJoint2D _SpringJoint2D)
    {
        _SpringJoint2D.enabled = false;
        _player_beh._trash_beh = null;
        _is_get = false;
        audioSource.PlayOneShot(sound);
    }

    public void Move_trash_to_the_tank(Transform _trash_tank_object, trash_tank_beh _trash_tank_beh_script)
    {
        float distance = Vector2.Distance(_trash_tank_object.position, transform.position);

        if (_trash_tank_beh._tank_fill < _trash_tank_beh._tank_fill_max)
        {

            if (distance >= _trash_count_distance)
            {

                transform.position = Vector3.Slerp(transform.position, _trash_tank.position, Time.deltaTime * _trash_move_to_tank_speed);

            }
            else
            {
                _trash_tank_beh_script.Add_trash_In_the_tank(this);

            }
        }
        else
        {

            _trash_tank_beh_script.Tank_is_full_message();

        }


    }

    public void Move_trash_to_the_car(trash_tank_beh _tank_trash_beh, trash_car _car = null)
    {
        if (car != null)
        {
            float distance = Vector2.Distance(car.transform.position, transform.position);

            if (_trash_tank_beh._tank_fill < _trash_tank_beh._tank_fill_max)
            {

                if (distance >= _trash_count_distance)
                {

                    transform.position = Vector3.Lerp(transform.position, _car.transform.position, Time.deltaTime * _trash_move_to_tank_speed);

                }
                else
                {
                    if (_trash_type == _tank_trash_beh.trash_type)
                    {

                        _player_beh.Money.Add(1);

                    }
                    else
                    {

                        //not give token

                    }

                    _tank_trash_beh.Remove_trash_In_the_tank(transform);
                    AudioSource _as = Instantiate(_tank_trash_beh._audio_sourse);
                    _as.PlayOneShot(sound);
                    Destroy(gameObject);

                }

            }
        } else
        {
            throw new NullReferenceException("car is null");
        }

    }
}
