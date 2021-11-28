using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_beh : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Controls _controls;
    private player_beh _player_beh;

    private Transform _parent;
    private Transform _player;

    private float _get_trash_distance;
    private bool _is_get;

    [HideInInspector] public Transform _trash_tank;
    [HideInInspector] public trash_tank_beh _trash_tank_beh;
    [HideInInspector] public bool is_move_to_the_trash_tank;

    [Header("Trash tank propereties")]
    [SerializeField] private string _trash_type;
    [SerializeField] private float _trash_move_to_tank_speed = 8f;
    [SerializeField] private float _trash_count_distance = 0.5f;


    void Start()
    {
        //get rb
        _rb = GetComponent<Rigidbody2D>();

        //get objects
        _parent = transform.root;
        _player = _parent.GetChild(0);

        //get scripts
        _player_beh = _player.GetComponent<player_beh>();
        _controls = _player.GetComponent<Controls>();

        //set propereties
        _get_trash_distance = _player_beh._get_trash_distnce;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_move_to_the_trash_tank)
        {
            if (Input.GetKeyDown(_controls.activity))
            {
                Get_trash(_player_beh._SpringJoint2D);
            }
        } else
        {
            Move_trash_to_the_tank(_trash_tank, _trash_tank_beh);
        }
    }

    private void Get_trash(SpringJoint2D _SpringJoint2D)
    {
        if (!_is_get)
        {

            float distance = Vector2.Distance(_player.position, transform.position);

            if (distance <= _get_trash_distance)
            {
                _SpringJoint2D.connectedBody = _rb;
                _SpringJoint2D.enabled = true;
                _player_beh._trash_beh = this;
                _is_get = true;
            }
        } else
        {
            Put_trash(_SpringJoint2D);
        }
    }

    private void Put_trash(SpringJoint2D _SpringJoint2D)
    {
        _SpringJoint2D.enabled = false;
        _player_beh._trash_beh = null;
        _is_get = false;
    }

    public void Move_trash_to_the_tank(Transform _trash_tank_object, trash_tank_beh _trash_tank_beh_script)
    {
        float distance = Vector2.Distance(_trash_tank_object.position, transform.position);

        if (_trash_tank_beh._tank_fill < _trash_tank_beh._tank_fill_max)
        {

            if (distance >= _trash_count_distance)
            {

                transform.position = Vector2.Lerp(transform.position, _trash_tank.position, Time.deltaTime * _trash_move_to_tank_speed);

            }
            else
            {
                if (_trash_type == _trash_tank_beh_script.trash_type)
                {

                    //give token

                }
                else
                {

                    //not give token

                }

                _trash_tank_beh_script.Add_trash_In_the_tank(transform);

            }
        } else
        {

            _trash_tank_beh_script.Tank_is_full_message();

        }
    }
}
