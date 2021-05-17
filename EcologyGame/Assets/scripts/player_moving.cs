using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moving : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool is_run = (horizontal == 0 ? true : false);
        

        if (horizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        } else  if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.AddForce(movement * speed * Time.fixedDeltaTime);
    }
}
