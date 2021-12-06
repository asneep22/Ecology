using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Player must be first object in the parent
public class player_beh : MonoBehaviour
{
    [HideInInspector] public Controls _controls;
    [HideInInspector] public trash_beh _trash_beh;
    [HideInInspector] public money Money;

    [HideInInspector] public SpringJoint2D _SpringJoint2D;

    [Header("propereties")]
    public float _speed = 5;
    public float _get_trash_distnce = 1.5f;
    public float show_hint_distance = 1.5f;
    void Start()
    {
        //set scripts
        Money = GetComponent<money>();

        _SpringJoint2D = GetComponent<SpringJoint2D>();
        _SpringJoint2D.enabled = false;
    }

    public void onActivity(InputAction.CallbackContext context)
    {
        Debug.Log("activity");
    }
}
