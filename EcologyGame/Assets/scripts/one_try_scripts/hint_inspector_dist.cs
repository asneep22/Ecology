using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_inspector_dist : MonoBehaviour
{
    // Start is called before the first frame update
    private lvl1_hints hint_scr;
    private GameObject hint_interface;
    private GameObject inspector;
    void Start()
    {
        hint_scr = GameObject.FindGameObjectWithTag("hint_interface").GetComponent<lvl1_hints>();
        hint_interface = GameObject.FindGameObjectWithTag("hint_interface");
        inspector = GameObject.FindGameObjectWithTag("inspector");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, inspector.transform.position);
        if (distance < 0.2f)
        {
            hint_interface.SetActive(true);
            hint_scr.hint_index++;
            gameObject.AddComponent<hint_empty_tank>();
            Destroy(this);
        }
    }
}
