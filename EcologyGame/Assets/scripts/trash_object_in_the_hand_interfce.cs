using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trash_object_in_the_hand_interfce : MonoBehaviour
{


    private SpriteRenderer sp_renderer_trash_interface;
    private SpriteRenderer sp_renderer_trash_in_the_hand;

    private GameObject player;
    private Transform trash_empty;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        trash_empty = player.transform.GetChild(0);

        sp_renderer_trash_interface = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (trash_empty.childCount == 1)
        {

            Transform trash_in_the_hand = trash_empty.transform.GetChild(0);
            sp_renderer_trash_in_the_hand = trash_in_the_hand.GetComponent<SpriteRenderer>();
            sp_renderer_trash_in_the_hand.size = new Vector3(0.7f, 0.7f, 0.7f);
            sp_renderer_trash_interface.sprite = sp_renderer_trash_in_the_hand.sprite;
        }
        else if (trash_empty.childCount == 0)
        {
            sp_renderer_trash_interface.sprite = null;
        }

    }
}
