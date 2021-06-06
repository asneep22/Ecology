using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrain : MonoBehaviour
{
    public float speed = 4f;
    
    
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        
    }
}
