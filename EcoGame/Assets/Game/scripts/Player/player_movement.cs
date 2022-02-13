using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player_movement : MonoBehaviour
{
    [HideInInspector] public camera_follow _camera_follow;
    private player_beh _player_beh;

    private float _speed;
    public bool can_move = true;
    private Vector2 _moveDir;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera_follow = Camera.main.GetComponent<camera_follow>();
        _player_beh = GetComponent<player_beh>();

        _speed = _player_beh._speed;
        _camera_follow._to_follow_obj = transform;
    }

    void FixedUpdate()
    {
        if (can_move)
        {
            _moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        } else
        {
            _moveDir = Vector2.zero;
        }
        Movement_logic(_moveDir);
    }

    private void Movement_logic(Vector2 movement)
    {
        _rb.AddForce(movement * _speed * _rb.drag);
      
    }
}
