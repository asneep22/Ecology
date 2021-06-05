using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_tank_with_house : MonoBehaviour
{
    private lvl1_hints hint_scr;
    private GameObject hint_interface;


    // Start is called before the first frame update
    void Start()
    {
        hint_scr = GameObject.FindGameObjectWithTag("hint_interface").GetComponent<lvl1_hints>();
        hint_interface = GameObject.FindGameObjectWithTag("hint_interface");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > -0.15f)
        {
            hint_interface.SetActive(true);
            hint_scr.hint_index++;
            Destroy(this);
        }
    }
}
