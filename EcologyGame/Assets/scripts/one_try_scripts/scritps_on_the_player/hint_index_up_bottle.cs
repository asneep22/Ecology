using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_index_up_bottle : MonoBehaviour
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
        if (transform.GetChild(0).childCount == 1)
        {
            hint_scr.hint_index = 4;
            hint_interface.SetActive(true);
            gameObject.AddComponent<hint_put_bottle_in_the_tank>();
            Destroy(this);
        }
    }
}
