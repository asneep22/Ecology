using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_trash : MonoBehaviour
{

    private GameObject player;
    private Transform trash_position;
    private Rigidbody2D trash_rb;


    private bool trash_is_put = false;
    public float activity_distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trash_rb = transform.GetComponent<Rigidbody2D>();
        trash_position = player.transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);


        if (!trash_is_put)
        {

            if (distance < activity_distance && Input.GetKeyDown(KeyCode.E))
            {

                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 0.1f);
                transform.SetParent(trash_position);
                trash_is_put = !trash_is_put;
            }
        } else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 0.1f);


            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.SetParent(null);
                trash_rb.gravityScale = 0.4f;
                StartCoroutine("gravity");
                trash_is_put = !trash_is_put;
            }
        }
    }

    IEnumerator gravity()
    {
        yield return new WaitForSeconds(0.025f);
        trash_rb.gravityScale = 0;
    }
}
