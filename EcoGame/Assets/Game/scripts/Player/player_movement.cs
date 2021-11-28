using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player_movement : MonoBehaviour
{
    [HideInInspector] public camera_follow _camera_follow;
    private player_beh _player_beh;

    private float _speed;
    [SerializeField] private bool move_only_x;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera_follow = Camera.main.GetComponent<camera_follow>();
        _player_beh = GetComponent<player_beh>();

        _speed = _player_beh._speed;
        //set object which camera follow
        _camera_follow._to_follow_obj = transform;
    }

    void FixedUpdate()
    {
        Movement_logic();
    }

    private void Movement_logic()
    {
        float _horizontal_movement = Input.GetAxis("Horizontal");
        float _vertical_movement = Input.GetAxis("Vertical");

        Vector3 movement = (move_only_x) ? new Vector3(_horizontal_movement, 0, 0) : new Vector3(_horizontal_movement, _vertical_movement, 0);

        _rb.AddForce(movement * _speed * _rb.drag);

        
    }
}
