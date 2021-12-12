using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_lvl_4 : MonoBehaviour
{
    private trash_tank_beh _trash_tank_beh;
    private open_exit _open_exit;

    void Start()
    {
        _trash_tank_beh = GetComponent<trash_tank_beh>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
