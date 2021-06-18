using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade_activated : MonoBehaviour
{

    private upgrade_parametr up_par;
    private money_count money_c;

    private small_upgrades su;
    private medium_upgrade mu;
    private hight_upgrade hu;

    public float plus_speed = 15;
    public float plus_hand_length = 0.02f;
    public int plus_tank_max = 5;

    private int aviable_money;
    private int price;


    private void Awake()
    {
        if (GetComponentInParent<small_upgrades>() != null)
        {
            su = GetComponentInParent<small_upgrades>();
        }
        else if (GetComponentInParent<medium_upgrade>() != null)
        {
            mu = GetComponentInParent<medium_upgrade>();
        }
        else
        {
            hu = GetComponentInParent<hight_upgrade>();
        }

        hu = GetComponentInParent<hight_upgrade>();

        money_c = GameObject.FindGameObjectWithTag("money_interface").GetComponent<money_count>();
        aviable_money = money_c.money_count_to_text;


        up_par = transform.GetComponent<upgrade_parametr>();
        price = up_par.price;

        if (aviable_money >= up_par.price)
        {

            switch (up_par.parametr)
            {
                case "player_speed":
                    stats.player_speed += plus_speed;
                    money_c.money_count_to_text -= price;
                    su.upgrades_array[0].GetComponent<upgrade_parametr>().price += su.upgrades_array[0].GetComponent<upgrade_parametr>().plus_price_after_buying;
                    Debug.Log($"player_speed = {stats.player_speed}, upgrade_price = {su.upgrades_array[0].GetComponent<upgrade_parametr>().price}");
                    break;

                case "player_hand_length":
                    stats.player_hand_length += plus_hand_length;
                    money_c.money_count_to_text -= price;
                    su.upgrades_array[1].GetComponent<upgrade_parametr>().price += su.upgrades_array[1].GetComponent<upgrade_parametr>().plus_price_after_buying;
                    Debug.Log($"player_hand_length = {stats.player_hand_length}, upgrade_price = {su.upgrades_array[1].GetComponent<upgrade_parametr>().price}");
                    break;

                case "trash_tank_max":
                    stats.tank_fill_status_max += plus_tank_max;
                    money_c.money_count_to_text -= price;
                    mu.upgrades_array[0].GetComponent<upgrade_parametr>().price += mu.upgrades_array[0].GetComponent<upgrade_parametr>().plus_price_after_buying;
                    Debug.Log($"tank_max_status = {stats.tank_fill_status_max}, upgrade_price = {mu.upgrades_array[0].GetComponent<upgrade_parametr>().price}");
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
