using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_exit : MonoBehaviour
{

    private tank_behaviour t_beh;
    private lvl1_hints hint_scr;
    private GameObject hint_interface;

    // Start is called before the first frame update
    void Start()
    {
        t_beh = gameObject.GetComponent<tank_behaviour>();
        hint_scr = GameObject.FindGameObjectWithTag("hint_interface").GetComponent<lvl1_hints>();
        hint_interface = GameObject.FindGameObjectWithTag("hint_interface");
    }

    // Update is called once per frame
    void Update()
    {
        if (t_beh != null)
        {
            if (t_beh.fill_tank_status == 10)
            {
                hint_scr.hint_index = 8;
                hint_interface.SetActive(true);
                Destroy(this);
            }
        }
    }
}
