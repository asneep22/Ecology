using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_out : MonoBehaviour
{
    [SerializeField] private Collider2D _exit;

    // Update is called once per frame
    void Update()
    {

        if (transform.childCount == 0)
        {
            _exit.enabled = true;
        }
        
    }
}
