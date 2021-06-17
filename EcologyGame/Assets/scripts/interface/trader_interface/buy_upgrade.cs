using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buy_upgrade : MonoBehaviour
{
    public GameObject small_cell;
    private small_upgrades su;

    public GameObject medium_cell;
    private medium_upgrade mu;

    public GameObject hight_cell;
    private hight_upgrade hu;

    public money_count money_cnt;

    public static Transform upgrades_cell;
    void Start()
    {
        money_cnt = GameObject.FindGameObjectWithTag("money_interface").GetComponent<money_count>();

        su = small_cell.GetComponent<small_upgrades>();
        mu = medium_cell.GetComponent<medium_upgrade>();
        hu = hight_cell.GetComponent<hight_upgrade>();
    }
    public void buy()
    {

        if (upgrades_cell.GetChild(0).GetComponent<upgrade_parametr>().price <= money_cnt.money_count_to_text)
        {
            if (upgrades_cell != null)
            {
                money_cnt.money_count_text.transform.localScale = money_cnt.new_scale;
                upgrades_cell.GetChild(0).gameObject.AddComponent<upgrade_activated>();
                su.reload_upgrade();
                mu.reload_upgrade();
                hu.reload_upgrade();
                upgrades_cell = null;
                Debug.Log("items was reloaded");
            }
        }
    }
}
