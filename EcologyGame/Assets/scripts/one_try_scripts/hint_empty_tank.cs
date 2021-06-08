using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_empty_tank : MonoBehaviour
{
    // Start is called before the first frame update

    private lvl1_hints hint_scr;
    private GameObject hint_interface;
    private tank_behaviour t_beh;
    void Start()
    {
        hint_scr = GameObject.FindGameObjectWithTag("hint_interface").GetComponent<lvl1_hints>();
        hint_interface = GameObject.FindGameObjectWithTag("hint_interface");;
        t_beh = GetComponent<tank_behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t_beh.fill_tank_status == 0)
        {
            hint_interface.SetActive(true);
            gameObject.AddComponent<hint_tank_with_house>();
            hint_scr.hint_index = 14;
            Destroy(this);
        }
    }
}
