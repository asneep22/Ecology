using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("UP", true);
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Stay", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            anim.SetBool("Down", true);
        }
    }
}
