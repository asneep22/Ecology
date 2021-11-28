using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Controls_set : MonoBehaviour
{


    void Start()
    {
    }

    public void Select_field()
    {
        Time.timeScale = 0;

        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();

        foreach (var key in allKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Controls.activity = key;
                Debug.Log(Controls.activity);
                Change_field();
            }
        }

    }

    public void Change_field()
    {
        Time.timeScale = 1;
    }

}
