using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class show_price : MonoBehaviour
{
    private upgrade_parametr up_par;

    public Transform cell;

    private TextMeshProUGUI price_text;
    private Vector3 start_size;
    public float anim_speed = 15;
    void Start()
    {
        price_text = transform.GetComponent<TextMeshProUGUI>();
        start_size = transform.localScale;
    }

    private void FixedUpdate()
    {
        float start_size_lerp = Mathf.Lerp(transform.localScale.x ,start_size.x, anim_speed  * Time.fixedDeltaTime);
        transform.localScale = new Vector3(start_size_lerp, start_size_lerp, start_size_lerp);

        if (cell.childCount > 0)
        {
            up_par = cell.GetChild(0).GetComponent<upgrade_parametr>();
            if (up_par != null)
            {
                price_text.text = up_par.price.ToString();
            }
        }
    }

    public void reload_price()
    {
        float new_size = start_size.x + 0.7f;
        price_text.transform.localScale = new Vector3(new_size, new_size, new_size);
    }
}
