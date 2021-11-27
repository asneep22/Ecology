using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
   public Transform _to_follow_obj;
   [HideInInspector] public Vector3 _move_to;

    [Header("m/s")]
   [SerializeField] private float _speed;
   [Space]
   [SerializeField] private float _clamp_min_x;
   [SerializeField] private float _clamp_max_x;

   [SerializeField] private float _clamp_min_y;
   [SerializeField] private float _clamp_max_y;

    void FixedUpdate()
    {
        Camera_follow();
    }

    void Camera_follow()
    {
        if (_to_follow_obj)
        {

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _to_follow_obj.position.x, Time.fixedDeltaTime * _speed), transform.position.y, transform.position.z);

        } else
        {
            transform.position = Vector3.Lerp(transform.localPosition, _move_to, Time.fixedDeltaTime * _speed);
        }
    }
}
