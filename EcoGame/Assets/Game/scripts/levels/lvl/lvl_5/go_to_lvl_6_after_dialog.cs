using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_lvl_6_after_dialog : MonoBehaviour
{
    [SerializeField] dialog _dial;
    [SerializeField] go_to_level _go_to_lvl;

    private bool cour_is_started;
    void Start()
    {
        _dial = GetComponent<dialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dial.dialog_texts.Count == 0 && !cour_is_started)
        {
            cour_is_started = true;
            StartCoroutine(Load_next_lvl());
        }
    }

    private IEnumerator Load_next_lvl()
    {
        yield return new WaitForSeconds(5);

        go_to_level _go_to_lvl = new go_to_level();
        _go_to_lvl.Go_to_lvl(6);


    }
}
