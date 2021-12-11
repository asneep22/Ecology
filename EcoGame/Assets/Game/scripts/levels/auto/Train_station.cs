using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_station : MonoBehaviour
{
    private bool _is_created;

    [SerializeField] private List<Transform> _trains = new List<Transform>();
    private Transform _train;
    [SerializeField] private Transform _start_point;
    [SerializeField] private Transform _target_point;

    private Rigidbody2D _train_rb;
    [SerializeField] private float _train_speed;


    [SerializeField] private float _min_time_create = 5;
    [SerializeField] private float _max_time_create = 15;


    void Start()
    {
        StartCoroutine(Try_create_train());
    }

    void FixedUpdate()
    {
        Move_train();
    }

    private void Move_train()
    {
        if (_train != null)
        {
            Vector2 _movement_vector = new Vector2(_target_point.position.x - _train.position.x, 0).normalized;
            _train_rb.AddForce(_movement_vector * _train_speed * _train_rb.drag * _train_rb.mass);


            float distance = Mathf.Abs(_target_point.transform.position.x) - Mathf.Abs(_train.transform.position.x);

            if (distance <= 0)
            {
                Remove_train();
            }
        }
    }

    private void Remove_train()
    {
            Destroy(_train.gameObject);
            _is_created = false;
    }

    IEnumerator Try_create_train()
    {
        while (true)
        {
            float create_time = Random.Range(_min_time_create, _max_time_create);

            if (!_is_created && _start_point.gameObject.activeSelf == true)
            {
                _train = Instantiate(_trains[Random.Range(0, _trains.Count)], transform);
                _train_rb = _train.GetComponent<Rigidbody2D>();
                _train.transform.position = _start_point.transform.position;
                _is_created = true;

            }

            yield return new WaitForSeconds(create_time);
        }
    }


}
