using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_set : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null) 
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y);
        }
    }
}
