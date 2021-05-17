using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer_changer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    public float distance;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y + 0.05f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 0.2f);
        } else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 0.2f);
        }
    }
}
