using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class money_script : MonoBehaviour
{

    private GameObject target;
    private TextMeshProUGUI money_count_text;

    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);
        }


    }
}
