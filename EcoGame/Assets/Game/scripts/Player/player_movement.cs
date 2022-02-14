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

    private Animator anim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera_follow = Camera.main.GetComponent<camera_follow>();
        _player_beh = GetComponent<player_beh>();

        _speed = _player_beh._speed;
        _camera_follow._to_follow_obj = transform;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (can_move)
        {
            _moveDir = new Vector2(horizontal, vertical);

            transform.localScale = (horizontal >= 0) ? new Vector3(8, transform.localScale.y, transform.localScale.z): new Vector3(-8, transform.localScale.y, transform.localScale.z);

            bool is_run = (horizontal != 0);
            anim.SetBool("is_running", is_run);

            bool is_run_back = (vertical > 0);
            anim.SetBool("is_running_back", is_run_back);

            bool is_run_fore = (vertical < 0);
            anim.SetBool("is_running_fore", is_run_fore);

        } else
        {
            _moveDir = Vector2.zero;
            anim.SetBool("is_running", false);
            anim.SetBool("is_running_back", false);
            anim.SetBool("is_running_fore", false);

        }
        Movement_logic(_moveDir);

    }

    private void Movement_logic(Vector2 movement)
    {
        _rb.AddForce(movement * _speed * _rb.drag);
      
    }
}
