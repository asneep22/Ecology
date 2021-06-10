using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_behaviour : MonoBehaviour
{
    // NEED MAKE NORMAL RESPONSE

    private Rigidbody2D rb;
    private Transform trash_position; // empty object, on the which will the trash catches
    public float speed;
    public bool can_run = true;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trash_position = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // player movement

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (can_run)
        {

            Vector2 movement = new Vector2(horizontal, vertical);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

            rb.AddForce(movement * speed * Time.fixedDeltaTime);


            // rotate player
            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 4);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 4);
            }


            // animation
            bool is_run = (horizontal != 0);
            anim.SetBool("is_running", is_run);


            bool is_run_back = (vertical > 0);
            anim.SetBool("is_running_back", is_run_back);

            bool is_run_fore = (vertical < 0);
            anim.SetBool("is_running_fore", is_run_fore);


            // locate trash_position
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_run_left_and_right"))
            {
                trash_position.localPosition = new Vector3(-0.04f, -0.05f, 0.001f);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_run_back"))
            {
                trash_position.localPosition = new Vector3(-0.003f, -0.05f, -0.001f);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_run_fore"))
            {
                trash_position.localPosition = new Vector3(-0.003f, -0.05f, 0.001f);
            }
        }
        else
        {
            anim.SetBool("is_running", false);
            anim.SetBool("is_running_back", false);
            anim.SetBool("is_running_fore", false);
        }
    }
}
