using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [HideInInspector] public bool is_called;
    [SerializeField] private GameObject _menu;
    [HideInInspector] public GameObject _menu_obj;

    public void TryCallMenu(InputAction.CallbackContext _context)
    {

        if (!is_called)
        {

            _menu_obj = Instantiate(_menu, transform);
            is_called = true;
            Time.timeScale = 0;

        } else
        {
            Time.timeScale = 1;
            Destroy(_menu_obj);
            is_called = false;
        }
    }

    public void CloseMenu()
    {

    }
}
