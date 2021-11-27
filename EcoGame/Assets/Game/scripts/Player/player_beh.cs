using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_beh : MonoBehaviour
{
    private Controls _controls;
    void Start()
    {
        _controls = GetComponent<Controls>();
    }


    public void Activity()
    {
        if (Input.GetKeyDown(_controls.activity))
        {

        }
    }
}
