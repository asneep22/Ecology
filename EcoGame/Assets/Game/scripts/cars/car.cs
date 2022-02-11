using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    private Rigidbody2D _rb;

    [HideInInspector] public Transform move_target;

    [SerializeField] private float _min_speed_m_per_sec;
    [SerializeField] private float _max_speed_m_per_sec;
    [SerializeField] private float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();


        _speed = Random.Range(_min_speed_m_per_sec, _max_speed_m_per_sec);

        transform.localScale = (move_target.position.x - transform.position.x < 0) ? transform.localScale : new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 _movement_vector = (move_target.position - transform.position).normalized;
        _rb.AddForce(_movement_vector * _speed * _rb.mass * _rb.drag);

        float _distance = Vector2.Distance(move_target.position, transform.position);

        if (_distance <= 5)
        {
            Destroy(gameObject);
        }
    }
}
