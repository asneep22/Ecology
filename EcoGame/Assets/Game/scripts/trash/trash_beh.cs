using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_beh : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Controls _controls;
    private player_beh _player_beh;

    private Transform _parent;
    private Transform _player;

    private float _get_trash_distance;
    private bool _is_get;

    void Start()
    {
        //get rb
        _rb = GetComponent<Rigidbody2D>();

        //get objects
        _parent = transform.root;
        _player = _parent.GetChild(0);

        //get scripts
        _player_beh = _player.GetComponent<player_beh>();
        _controls = _player.GetComponent<Controls>();

        //set propereties
        _get_trash_distance = _player_beh._get_trash_distnce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_controls.activity))
        {
            Get_trash(_player_beh._SpringJoint2D);
        }
    }

    private void Get_trash(SpringJoint2D _SpringJoint2D)
    {
        if (!_is_get)
        {

            float distance = Vector2.Distance(_player.position, transform.position);

            if (distance <= _get_trash_distance)
            {
                _SpringJoint2D.connectedBody = _rb;
                _SpringJoint2D.enabled = true;
                _is_get = true;
            }
        } else
        {
            Put_trash(_SpringJoint2D);
        }
    }

    private void Put_trash(SpringJoint2D _SpringJoint2D)
    {
        _SpringJoint2D.enabled = false;
        _is_get = false;
    }
}
