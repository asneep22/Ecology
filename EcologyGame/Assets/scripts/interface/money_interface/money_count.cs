using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class money_count : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI money_count_text;
    [HideInInspector]
    public int money_count_to_text = 0;

    [HideInInspector]
    public Vector3 start_scale;
    public float anim_speed;

    // Start is called before the first frame update
    public void Start()
    {
        money_count_text = transform.GetComponent<TextMeshProUGUI>();

        start_scale = transform.localScale;
    }

    // Update is called once per frame
    public void Update()
    {
        money_count_text.text = money_count_to_text.ToString();

        float scale_x = Mathf.Lerp(transform.localScale.x, start_scale.x, Time.deltaTime * anim_speed);
        float scale_y = Mathf.Lerp(transform.localScale.y, start_scale.y, Time.deltaTime * anim_speed);
        transform.localScale = new Vector3(scale_x, scale_y, transform.localScale.z);
    }
}
