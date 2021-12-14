using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [HideInInspector] public bool is_called;
    [HideInInspector] public bool is_restart;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _restart_menu;
    [HideInInspector] public GameObject _menu_obj;

    public void TryCallMenu(InputAction.CallbackContext _context)
    {

        if (!is_called && !is_restart)
        {

            _menu_obj = Instantiate(_menu, transform);
            is_called = true;
            Time.timeScale = 0;

        } else if (!is_restart)
        {


                Time.timeScale = 1;
                Destroy(_menu_obj);
                is_called = false;

        }
    }

    public void CallRestartMenu()
    {
        if (_menu_obj == _menu)
        {
            Destroy(_menu_obj);
            is_called = true;
        }

        if (!is_restart) {
            _menu_obj = Instantiate(_restart_menu, transform);
            is_restart = true;
            Time.timeScale = 0;
        }
    }
}
