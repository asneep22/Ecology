using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class money_count_trader_interfaace : MonoBehaviour
{
    [HideInInspector]
    public money_count mon_cnt;
    [HideInInspector]
    public TextMeshProUGUI mon_cnt_trader_inter;

    [HideInInspector]
    public Vector3 start_scale;

    [HideInInspector]
    public Vector3 new_scale;

    private Color start_color;

    public float devine_size = 0.5f;
    public float anim_speed = 10;
    void Start()
    {
        mon_cnt_trader_inter = transform.GetComponent<TextMeshProUGUI>();
        mon_cnt = GameObject.FindGameObjectWithTag("money_interface").GetComponent<money_count>();

        start_color = mon_cnt_trader_inter.color;

        new_scale = new Vector3(mon_cnt_trader_inter.transform.localScale.x + devine_size, mon_cnt_trader_inter.transform.localScale.y + devine_size, mon_cnt_trader_inter.transform.localScale.z);
        start_scale = mon_cnt_trader_inter.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        mon_cnt_trader_inter.text = mon_cnt.money_count_text.text;

        mon_cnt_trader_inter.color = new Color(Mathf.Lerp(mon_cnt_trader_inter.color.r, start_color.r, anim_speed / 8 * Time.deltaTime), Mathf.Lerp(mon_cnt_trader_inter.color.g, start_color.g, anim_speed / 8 * Time.deltaTime), Mathf.Lerp(mon_cnt_trader_inter.color.b, start_color.b, anim_speed / 8 * Time.deltaTime));

        float scale_x = Mathf.Lerp(mon_cnt_trader_inter.transform.localScale.x, start_scale.x, Time.deltaTime * anim_speed);
        float scale_y = Mathf.Lerp(mon_cnt_trader_inter.transform.localScale.y, start_scale.y, Time.deltaTime * anim_speed);
        mon_cnt_trader_inter.transform.localScale = new Vector3(scale_x, scale_y, transform.localScale.z);
    }
}
