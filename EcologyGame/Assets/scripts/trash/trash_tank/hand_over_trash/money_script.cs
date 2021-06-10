using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class money_script : MonoBehaviour
{

    private GameObject target;
    private money_count money_count_script;

    // Start is called before the first frame update
    void Start()
    {
        money_count_script = GameObject.FindGameObjectWithTag("money_interface").GetComponentInChildren<money_count>();
        target = GameObject.FindGameObjectWithTag("money");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);

        float pos_x = Mathf.Lerp(transform.position.x, target.transform.position.x, Time.deltaTime * 8);
        float pos_y = Mathf.Lerp(transform.position.y, target.transform.position.y, Time.deltaTime * 8);
        transform.localPosition = new Vector3(pos_x, pos_y, -30); 

        if (distance < 0.1f)
        {
            float new_scale_x = money_count_script.start_scale.x + 0.35f;
            float new_scale_y = money_count_script.start_scale.y + 0.35f;
            money_count_script.money_count_text.transform.localScale = new Vector2(new_scale_x, new_scale_y);
            money_count_script.money_count_to_text++;
            Destroy(gameObject);
        }


    }
}
