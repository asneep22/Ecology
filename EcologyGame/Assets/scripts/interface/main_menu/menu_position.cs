using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_position : MonoBehaviour
{

    public Transform options_menu;
    public float start_menu_pos_devine = 0;
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        float devine = Mathf.Lerp(transform.localPosition.x, start_menu_pos_devine, speed * Time.deltaTime);


        transform.localPosition = new Vector3(devine, transform.localPosition.y, transform.localPosition.z);
        options_menu.transform.localPosition = new Vector3(transform.localPosition.x + 2000, options_menu.transform.localPosition.y, options_menu.transform.localPosition.z);
    }
}
