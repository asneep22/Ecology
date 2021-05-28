using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activated_interface : MonoBehaviour
{

    private GameObject player;
    private GameObject trader_menu;

    public float activity_distance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trader_menu = GameObject.FindGameObjectWithTag("trader_interface");
        trader_menu.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);


        if (!trader_menu.activeSelf && distance < activity_distance && Input.GetKeyDown(KeyCode.E))
        {
            trader_menu.SetActive(true);
        } else if ((trader_menu.activeSelf && Input.GetKeyDown(KeyCode.E)) || activity_distance < distance)
        {
            trader_menu.SetActive(false);
        }
    }
}
