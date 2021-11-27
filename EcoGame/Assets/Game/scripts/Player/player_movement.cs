using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player_movement : MonoBehaviour
{
    private camera_follow _camera_follow;

    [Header("m/s")]
    [SerializeField] private float _speed = 1f;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera_follow = Camera.main.GetComponent<camera_follow>();
        _camera_follow._to_follow_obj = transform;
    }

    void FixedUpdate()
    {
        Movement_logic();
    }

    private void Movement_logic()
    {
        float horizontal_movement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal_movement, 0, 0);

        _rb.AddForce(movement * _speed * _rb.drag);

        
    }
}
