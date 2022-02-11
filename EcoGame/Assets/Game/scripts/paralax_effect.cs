using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax_effect : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField, Range(0, 1f)] private float _paralax_multiply;
    Vector3 _prev_pos;
    void Start()
    {
        _prev_pos = _camera.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = _camera.position - _prev_pos;

        _prev_pos = _camera.transform.position;
        transform.position += new Vector3(delta.x * _paralax_multiply, delta.y * _paralax_multiply, 0);


    }
}
