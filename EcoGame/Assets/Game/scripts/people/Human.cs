using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Human : MonoBehaviour
{
    private Rigidbody2D _rb;

    private bool _has_chanse_drop_a_thrash;

    [HideInInspector] public Transform move_target;

    [SerializeField] private float _min_speed_m_per_sec;
    [SerializeField] private float _max_speed_m_per_sec;
    [SerializeField] private float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _speed = Random.Range(_min_speed_m_per_sec, _max_speed_m_per_sec);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 _movement_vector = (move_target.position - transform.position).normalized;
        _rb.AddForce(_movement_vector * _speed * _rb.drag);

        float target_distance = Vector2.Distance(transform.position, move_target.position);

        if (target_distance <= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
