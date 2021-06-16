using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class train_behaviour : MonoBehaviour
{
    
    private train_instantiate tr_inst;

    private GameObject player;
    private Camera cam;

    private GameObject target;

    private Rigidbody2D rb;

    private Transform trash_add_force_pos_min;

    private int i = 0;

    //trash
    private List<Transform> empty = new List<Transform>();
    private float position_add_force;

    void Start()
    {
        trash_add_force_pos_min = GameObject.FindGameObjectWithTag("trash_add_force_pos_min").transform;

        empty = transform.GetChild(0).GetComponentsInChildren<Transform>().ToList();
        empty.Remove(empty[0]);

        foreach (Transform item in empty)
        {
            int random = Random.Range(0,2);

            if (random ==  1)
            {
                item.gameObject.AddComponent<random_trash_inst>();
            }
        }

        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;


        rb = GetComponent<Rigidbody2D>();

        tr_inst = GameObject.FindGameObjectWithTag("train_inst").GetComponent<train_instantiate>();
        target = GameObject.FindGameObjectWithTag("train_destroy");

        position_add_force = trash_add_force_pos_min.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < position_add_force)
        {
            position_add_force -= Random.Range(0, tr_inst.next_trash_add_force_pos_devine_max);
            if (i < empty.Count)
            {

                if (empty[i].childCount > 0) {
                    empty[i].GetChild(0).gameObject.AddComponent<pick_up_trash>();
                    tras_add_force.add_force(empty[i].GetChild(0).gameObject, GameObject.FindGameObjectWithTag("Player").transform, 900, tr_inst.force);
                }
                i++;
            }
        }

        transform.GetChild(0).localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.1f);

        // Движение поезда
        rb.AddForce(Vector2.left * tr_inst.speed * Time.fixedDeltaTime);
        

        if (transform.position.x < target.transform.position.x)
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
