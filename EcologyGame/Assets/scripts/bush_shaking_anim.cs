using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush_shaking_anim : MonoBehaviour
{

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            anim.SetBool("is_shaking", true);
            StartCoroutine("wait", 0.3f);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            anim.SetBool("is_shaking", false);
            anim.SetInteger("shake_count", 1);
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetInteger("shake_count", 0);
    }
}
