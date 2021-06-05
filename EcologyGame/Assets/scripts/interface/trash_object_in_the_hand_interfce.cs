using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class trash_object_in_the_hand_interfce : MonoBehaviour
{


    private SpriteRenderer sp_renderer_trash_interface;
    private SpriteRenderer sp_renderer_trash_in_the_hand;
    public TextMeshPro text;

    private GameObject player;
    private Transform trash_empty;

    [HideInInspector]
    public Transform trash_in_the_hand;


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

        if (trash_empty.childCount == 1 && text != null)
        {
            // Отображение предмета в интерфейсе

            trash_in_the_hand = trash_empty.transform.GetChild(0);
            sp_renderer_trash_in_the_hand = trash_in_the_hand.GetComponent<SpriteRenderer>();
            sp_renderer_trash_in_the_hand.size = new Vector3(0.7f, 0.7f, 0.7f);
            sp_renderer_trash_interface.sprite = sp_renderer_trash_in_the_hand.sprite;

            // Отображение материала предмета
            text.text = trash_in_the_hand.tag switch
            {
                "glass" => "стекло",
                "metal" => "металл",
                "paper" => "бумага",
                "battery" => "батарейка",
                "organic" => "стекло",
                "plastick" => "пластик",
                "Untagged" => "Введи тег",
            };
        }
        else if (trash_empty.childCount == 0 && text != null)
        {     
            text.text = "";
            sp_renderer_trash_interface.sprite = null;
        }

    }
}
