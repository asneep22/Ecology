using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class trash_tank_beh : MonoBehaviour
{
    private player_beh _player_beh;

    private Transform _player;

    [Header("Tank Propereties")]
    [SerializeField] private Transform _car;
    public float _put_in_the_tank_distance = 1.5f;
    public string trash_type;
    [Space]
    public List<Transform> _trash_array = new List<Transform>();
    public int _tank_fill_max;
    public int _tank_fill;

    void Start()
    {
        _player = scene_manager.player.transform;

        _player_beh = _player.GetComponent<player_beh>();
    }


    public void OnPut(InputAction.CallbackContext context)
    {
        Put_trash_in_the_tank();
    }

    void Put_trash_in_the_tank(Transform _car = null)
    {
        float _car_distance = 10000;
        float _distance = Vector2.Distance(transform.position, _player.position);

        if (_car != null)
        {
            _car_distance = Vector2.Distance(_car.position, transform.position);
            Debug.Log(_car_distance);
        }

        if (_distance <= _put_in_the_tank_distance)
        {
            SpringJoint2D _springJoint2D = _player_beh._SpringJoint2D;

            if (_player_beh._trash_beh)
            {
                trash_beh _trash_beh = _player_beh._trash_beh;

                _trash_beh._trash_tank = transform;
                _trash_beh._trash_tank_beh = this;
                _trash_beh.GetComponent<BoxCollider2D>().enabled = false;

                if (_springJoint2D.enabled)
                {
                    _trash_beh.is_move_to_the_trash_tank = true;
                }

                _springJoint2D.enabled = false;
                _springJoint2D.connectedBody = null;
            }

        } 
        
        if (_car_distance <= 5)
        {
            Move_trash_to_the_car(_car);
        }
    }

    public void Add_trash_In_the_tank(Transform _trash)
    {
        _trash.parent = transform;
        _trash_array.Add(_trash);
        _tank_fill++;
        _trash.gameObject.SetActive(false);
    }

    public void Tank_is_full_message()
    {
        Debug.Log("Tank is full");
    }

    private void Move_trash_to_the_car(Transform _car = null)
    {
        Debug.Log("Yes");
        if (transform.childCount > 0 && _car != null)
        {
            Debug.Log("YesX2");

                List<Transform> _trash_array = transform.GetComponentsInChildren<Transform>().ToList();

            foreach (Transform item in _trash_array)
            {

                float distance = Vector2.Distance(_car.position, item.position);

                if (distance >= 1.5f)
                {
                    item.gameObject.SetActive(true);
                    item.position = Vector3.Slerp(transform.position, _car.position, Time.deltaTime * _put_in_the_tank_distance);
                }
                else
                {
                    Destroy(item.gameObject);
                }
            }
        }

    }


}
