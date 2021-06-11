using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class train_behaviour : MonoBehaviour
{

    private train_instantiate tr_inst;

    private GameObject player;
    private Camera cam;

    private GameObject target;

    private Rigidbody2D rb;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;


        rb = GetComponent<Rigidbody2D>();

        tr_inst = GameObject.FindGameObjectWithTag("train_inst").GetComponent<train_instantiate>();
        target = GameObject.FindGameObjectWithTag("train_destroy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Движение поезда
        rb.AddForce(Vector2.left * tr_inst.speed * Time.fixedDeltaTime);
        

        if (transform.localPosition.x < target.transform.position.x)
        {
            tr_inst.StartCoroutine("train_inst");
            Destroy(gameObject);
        }

        //Тряска камеры
        float cam_shake_effect_pos_x = Random.Range(-tr_inst.max_cam_shake_effect_pos_x, tr_inst.max_cam_shake_effect_pos_x);
        float cam_shake_effect_pos_y = Random.Range(-tr_inst.max_cam_shake_effect_pos_y, tr_inst.max_cam_shake_effect_pos_y);

        float distance = Vector2.Distance(player.transform.position, transform.position);
        cam.transform.position = new Vector3(cam.transform.position.x + cam_shake_effect_pos_x / distance, cam.transform.position.y + cam_shake_effect_pos_y / distance, cam.transform.position.z);
    }
}
