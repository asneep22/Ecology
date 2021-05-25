using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class tank_behaviour_green : MonoBehaviour
{
    private GameObject player;
    public TextMeshPro text;

    private GameObject trash_empty;
    private Transform trash_in_the_hand;

    private stretch_trash_status sts;

    private int fill_tank_status = 0;

    public float activity_distance;
    public int fill_tank_max = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trash_empty = GameObject.FindGameObjectWithTag("trash_empty");
        sts = GameObject.FindGameObjectWithTag("stretch_status_element").GetComponent<stretch_trash_status>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (trash_empty.transform.childCount > 0) {
            trash_in_the_hand = GameObject.FindGameObjectWithTag("trash_empty").transform.GetChild(0);
        }

        if (distance < activity_distance && Input.GetKey(KeyCode.E) && trash_in_the_hand != null && fill_tank_max > fill_tank_status)
        {
            fill_tank_status++;
            Destroy(trash_in_the_hand.gameObject);
            sts.trash.Remove(trash_in_the_hand.gameObject);

        } else if (fill_tank_status >= fill_tank_max)
        {
            text.enabled = true;

        }
    }
}
