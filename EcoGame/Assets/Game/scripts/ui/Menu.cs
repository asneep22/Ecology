using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [HideInInspector] public static bool is_pause;
    [HideInInspector] public bool is_called;
    [HideInInspector] public bool is_restart;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _restart_menu;
    [HideInInspector] public GameObject _menu_obj;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TryCallMenu();
        }
    }

    public void TryCallMenu()
    {

        if (!is_called && !is_restart)
        {

            _menu_obj = Instantiate(_menu, transform);
            is_called = true;
            is_pause = true;
            Time.timeScale = 0;

        } else if (!is_restart)
        {


                Time.timeScale = 1;
                Destroy(_menu_obj);
                is_pause = false;
                is_called = false;

        }
    }

    public void CallRestartMenu()
    {
        if (_menu_obj == _menu)
        {
            Destroy(_menu_obj);
            is_pause = false;
            is_called = true;
        }

        if (!is_restart) {
            _menu_obj = Instantiate(_restart_menu, transform);
            is_restart = true;
            is_pause = true;
            Time.timeScale = 0;
        }
    }
}
