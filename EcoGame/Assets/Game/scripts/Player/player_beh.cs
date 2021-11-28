using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Player must be first object in the parent
public class player_beh : MonoBehaviour
{
    [HideInInspector] public Controls _controls;
    private player_movement _player_movement;

    [HideInInspector] public SpringJoint2D _SpringJoint2D;

    [Header("propereties")]
    public float _speed = 5;
    public float _get_trash_distnce = 1.5f;
    void Start()
    {
        //set scripts
        _controls = GetComponent<Controls>();

        _SpringJoint2D = GetComponent<SpringJoint2D>();
        _SpringJoint2D.enabled = false;
    }

    public void Activity()
    {
        if (Input.GetKeyDown(_controls.activity))
        {

        }
    }
}
