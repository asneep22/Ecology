using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_set : MonoBehaviour
{

    //script for all non_static objects

    private Transform parent;
    void Start()
    {
        //set parent
        parent = transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, parent.position.z - transform.localPosition.y);
    }
}
