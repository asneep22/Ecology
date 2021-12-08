using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Human : MonoBehaviour
{
    private Rigidbody2D _rb;

    private bool trash_dropped;
    [SerializeField] private List<Transform> _trash = new List<Transform>();
                     private Vector2 _drop_trash_vector;
    [SerializeField] private float _drop_trash_chance = 0.5f;
    [SerializeField] private float _try_drop_trash_time = 2f;
    [SerializeField] private float _drop_trash_force = 1.2f;
    [HideInInspector]public Transform drop_trash_parent;

    [HideInInspector] public Transform move_target;

    [SerializeField] private float _min_speed_m_per_sec;
    [SerializeField] private float _max_speed_m_per_sec;
    [SerializeField] private float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _speed = Random.Range(_min_speed_m_per_sec, _max_speed_m_per_sec);

        StartCoroutine(Try_drop_trash());
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

    private void Drop_trash()
    {
        float _chance = Random.Range(0, 1f);

        if (_chance < _drop_trash_chance)
        {
            Transform choosed_droping_trash = _trash[Random.Range(0, _trash.Count)];
            Transform dropting_trash_go = Instantiate(choosed_droping_trash, drop_trash_parent);
            dropting_trash_go.transform.position = transform.position;

            _drop_trash_vector = new Vector2(Random.Range(0, 1f), Random.Range(0, 1f));
            dropting_trash_go.GetComponent<Rigidbody2D>().AddForce(_drop_trash_vector * _drop_trash_force, ForceMode2D.Impulse);

            trash_dropped = true;
        }
    }

    private IEnumerator Try_drop_trash()
    {
        while (!trash_dropped) {

            yield return new WaitForSeconds(_try_drop_trash_time);
            Drop_trash();
        }
    }
}
