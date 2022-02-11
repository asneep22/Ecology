using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inst_cars : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Insantiate points")]
    [SerializeField] private List<car> _cars = new List<car>();

    [Header("Insantiate points")]
    [SerializeField] private Transform _spawn_point;
    [SerializeField] private Transform _target;
    [SerializeField] private float devine_min_per_meters = 0;
    [SerializeField] private float devine_max_per_meters = 1f;

    [Header("Propereties")]
    [SerializeField] private float _start_delay_sec = 3;
    [SerializeField] private float _delay_sec_min = 3;
    [SerializeField] private float _delay_sec_max = 8;


    private void Start()
    {
        StartCoroutine(Spawn(_start_delay_sec));
    }

    private IEnumerator Spawn(float _delay_sec)
    {


        while (true)
        {

         
            Vector3 spawn_pos = new Vector3(_spawn_point.localPosition.x + Random.Range(devine_min_per_meters, devine_max_per_meters), _spawn_point.localPosition.y + Random.Range(devine_min_per_meters, devine_max_per_meters), _spawn_point.position.z);
            car _car = _cars[Random.Range(0, _cars.Count)];

            _car.transform.position = spawn_pos;
            _car.move_target = _target;

            _delay_sec = Random.Range(_delay_sec_min, _delay_sec_max);

            //Instantite human
            Instantiate(_car.transform, transform);

            yield return new WaitForSeconds(_delay_sec);
        }


    }
}

