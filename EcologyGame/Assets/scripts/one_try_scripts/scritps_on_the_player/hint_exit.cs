using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_exit : MonoBehaviour
{
    private GameObject[] array;

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
        array = GameObject.FindGameObjectsWithTag("plastick");

        if (array.Length == 0)
        {
            hint_scr.hint_index = 8;
            hint_interface.SetActive(true);
            Destroy(this);
        }
    }
}
