using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class money_count : MonoBehaviour
{
    public TextMeshProUGUI money_count_text;
    public int money_count_to_text = 240;

    public Vector3 new_scale;
    public float devine_size = 0.5f;

    [HideInInspector]
    public Vector3 start_scale;
    public float anim_speed;

    // Start is called before the first frame update
    public void Start()
    {
        new_scale = new Vector3(money_count_text.transform.localScale.x + devine_size, money_count_text.transform.localScale.y + devine_size, money_count_text.transform.localScale.z);
        start_scale = money_count_text.transform.localScale;
    }

    // Update is called once per frame
    public void Update()
    {
        money_count_text.text = money_count_to_text.ToString();

        float scale_x = Mathf.Lerp(money_count_text.transform.localScale.x, start_scale.x, Time.deltaTime * anim_speed);
        float scale_y = Mathf.Lerp(money_count_text.transform.localScale.y, start_scale.y, Time.deltaTime * anim_speed);
        money_count_text.transform.localScale = new Vector3(scale_x, scale_y, transform.localScale.z);
    }
}
