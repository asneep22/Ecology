using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretch_sttus_hint : MonoBehaviour
{
    private stretch_trash_status sts;
    private lvl1_hints hint_scr;
    private GameObject hint_interface;

    // Start is called before the first frame update
    void Start()
    {
        sts = transform.GetComponent<stretch_trash_status>();
        hint_scr = GameObject.FindGameObjectWithTag("hint_interface").GetComponent<lvl1_hints>();
        hint_interface = GameObject.FindGameObjectWithTag("hint_interface");
    }

    // Update is called once per frame
    void Update()
    {   
        if (sts.trash.Count == 0)
        {
            hint_interface.SetActive(true);
            hint_scr.hint_index = 23;
            gameObject.AddComponent<neigbours_create>();
            Destroy(this);
        }

    }
}
