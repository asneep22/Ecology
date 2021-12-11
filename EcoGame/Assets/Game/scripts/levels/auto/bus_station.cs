using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bus_station : MonoBehaviour
{
    private Transform _player;
    private enum Bus_states
    {
        Preparing_for_departure,
        Bus_called,
        Bus_arrived,
        Bus_left
    }

    [SerializeField] private Transform _bus;
    [SerializeField] private BoxCollider2D to_lvl_trigger;
    private Vector3 start_bus_pos;

    private Rigidbody2D _bus_rb;
    [SerializeField] private float _bus_speed = 15f;
    private Vector2 _bus_movement_vector;

    [SerializeField] private float _bus_call_dist;
    [SerializeField] private Bus_states _bus_state;

    private void Start()
    {
        _player = scene_manager.player.transform;

        start_bus_pos = _bus.transform.position;
        _bus_rb = _bus.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float _distance = Vector2.Distance(transform.position, _player.transform.position);

        if (_distance <= _bus_call_dist)
        {
            TryCallTheBus();
        }
        else
        {
            TryLeftTheBus();
        }
    }

    private void TryCallTheBus()
    {
        if (_bus_state == Bus_states.Preparing_for_departure)
        {

            _bus_state = Bus_states.Bus_called;


        }
        else if (_bus_state == Bus_states.Bus_called)
        {

            MoveBusToBusStation();

        } else if (_bus_state == Bus_states.Bus_left)
        {
            MoveBusFromBusStation();
        }
    }

    private void MoveBusToBusStation()
    {
        float _bus_distance = Mathf.Abs(transform.position.x - _bus.transform.position.x);

        if (_bus_state == Bus_states.Bus_called)
        {

            if (_bus_distance > 0.01f)
            {
                _bus_movement_vector = new Vector2(transform.position.x - _bus.transform.position.x, 0).normalized;
                _bus_rb.AddForce(_bus_movement_vector * _bus_speed * _bus_rb.drag * _bus_rb.mass * Mathf.Clamp(_bus_distance, 0.01f, 1));
            }
            else
            {
                _bus_state = Bus_states.Bus_arrived;
                to_lvl_trigger.enabled = true;
            }

        }
    }

    private void TryLeftTheBus()
    {

        if (_bus_state == Bus_states.Bus_arrived)
        {

            _bus_state = Bus_states.Bus_left;
            to_lvl_trigger.enabled = false;

        }
        else if (_bus_state == Bus_states.Bus_left)
        {

            MoveBusFromBusStation();

        }

    }

    private void MoveBusFromBusStation()
    {
        float _bus_distance = Vector2.Distance(transform.position, _bus.transform.position);

        _bus_movement_vector = Vector2.right;
        _bus_rb.AddForce(_bus_movement_vector * _bus_speed * _bus_rb.drag * _bus_rb.mass * Mathf.Clamp(_bus_distance, 0.5f, 1));

        if (_bus_distance > 100f)
        {
            _bus_state = Bus_states.Preparing_for_departure;
            _bus.transform.position = start_bus_pos;
        }
    }

}
