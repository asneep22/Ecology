using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade_activated : MonoBehaviour
{

    private upgrade_parametr up_par;
    private money_count money_c;

    public float plus_speed = 15;
    public float hand_length = 0.02f;

    private int aviable_money;
    private int price;


    private void Awake()
    {
        money_c = GameObject.FindGameObjectWithTag("money_interface").GetComponent<money_count>();
        aviable_money = money_c.money_count_to_text;


        up_par = transform.GetComponent<upgrade_parametr>();
        price = up_par.price;

        if (aviable_money >= up_par.price)
        {

            switch (up_par.parametr)
            {
                case "player_speed":
                    player_stats.player_speed += plus_speed;
                    money_c.money_count_to_text -= price;
                    Debug.Log($"player_speed = {player_stats.player_speed}");
                    break;

                case "player_hand_length":
                    player_stats.player_hand_length += hand_length;
                    money_c.money_count_to_text -= price;
                    Debug.Log($"player_hand_length = {player_stats.player_hand_length}");
                    break;

                case "":
                    Debug.Log("select parametr");
                    break;

                default:
                    break;
            }
        } else
        {
            Debug.Log("you haven't enought money");
        }
    }
}
