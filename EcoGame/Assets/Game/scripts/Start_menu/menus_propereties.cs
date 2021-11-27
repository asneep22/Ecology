using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menus_propereties : MonoBehaviour
{
    //script for all menus parent element 

   [Header("per m/s")]
   [SerializeField] private float _speed = 2.5f; // menu move speed;
   [HideInInspector] public Vector3 _move_to;

    private void FixedUpdate()
    {
        Move_menu();
    }

    public void Move_menu()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _move_to, Time.fixedDeltaTime * _speed);
    }
}
