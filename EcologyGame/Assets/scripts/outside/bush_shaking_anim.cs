using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush_shaking_anim : MonoBehaviour
{

    private Animator anim;
    private GameObject player;
    private float activity_distance = 0.12f;
    private bool animation_end = true;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance <= activity_distance && !animation_end)
        {
            anim.SetBool("is_shaking", true);
            animation_end = true;
            StartCoroutine("wait", 0.3f);
        } else if (distance > activity_distance && animation_end)

        {
            anim.SetBool("is_shaking", false);
            animation_end = false;
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("is_shaking", false);
    }

}
