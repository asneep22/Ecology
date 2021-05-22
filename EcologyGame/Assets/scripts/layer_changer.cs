using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer_changer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    private Vector3 start_position;

    public float change_distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y + 0.05f)
        {
            transform.position = start_position;
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + change_distance);
        }
    }
}
