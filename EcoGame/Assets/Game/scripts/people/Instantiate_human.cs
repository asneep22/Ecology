using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instantiate_human : MonoBehaviour
{

    [Header("Insantiate points")]
    [SerializeField] private List<Human> _people = new List<Human>();
    [SerializeField] private Transform _drop_trash_parent;

    [Header("Insantiate points")]
    [SerializeField] private Transform _spawn_points_1;
    [SerializeField] private Transform _spawn_points_2;
    [SerializeField] private float devine_min_per_meters = 0;
    [SerializeField] private float devine_max_per_meters = 1f;

    [Header("Propereties")]
    [SerializeField] private float _start_delay_sec = 3;
    [SerializeField] private float _delay_sec_min = 3;
    [SerializeField] private float _delay_sec_max = 8;
    [SerializeField] private bool _freeze_x_pos = true;


    private void Start()
    {
        StartCoroutine(Spawn(_start_delay_sec));
    }

    private IEnumerator Spawn(float _delay_sec)
    {
        Transform _spawn_point = null;
        Transform _move_target = null;

        while (true)
        {
            //set variables

            if (Convert.Int_to_bool(Random.Range(0, 2)))
            {
                _spawn_point = _spawn_points_1;
                _move_target = _spawn_points_2;
            }
            else
            {
                _spawn_point = _spawn_points_2;
                _move_target = _spawn_points_1;
            }

            Vector3 spawn_pos = new Vector3(_spawn_point.localPosition.x + Random.Range(devine_min_per_meters, devine_max_per_meters), _spawn_point.localPosition.y + Random.Range(devine_min_per_meters, devine_max_per_meters), _spawn_point.position.z);
            Human _human = _people[Random.Range(0, _people.Count)];

            _human.transform.position = spawn_pos;
            _human.move_target = _move_target;
            _human.drop_trash_parent = _drop_trash_parent;
            _human.freeze_x_pos = _freeze_x_pos;

            _delay_sec = Random.Range(_delay_sec_min, _delay_sec_max);

            //Instantite human
            Instantiate(_human.transform, transform);

            yield return new WaitForSeconds(_delay_sec);
        }


    }
}
