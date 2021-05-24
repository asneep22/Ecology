using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer_changer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;


    public float min_change_distance;
    public float distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < min_change_distance && transform.position.y < player.transform.position.y + 0.2f)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z - 0.1f);
        }
        else
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z + 0.1f);
        }
    }
}
