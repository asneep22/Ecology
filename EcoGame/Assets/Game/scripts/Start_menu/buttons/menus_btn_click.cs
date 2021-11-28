using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menus_btn_click : MonoBehaviour
{
    //script for all buttons in the menu

    [SerializeField] private Vector3 _move_to;
    private camera_follow _cmera_follow;

    private void Start()
    {
        _cmera_follow = Camera.main.GetComponent<camera_follow>();
    }

    public void Btn_move_menu()
    {
        _cmera_follow._move_to = _move_to;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {

    }

    public void Switch_language()
    {
        string _localization = Lean.Localization.LeanLocalization.GetFirstCurrentLanguage();

        if (_localization == "English")
        {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("Russian");

        } else
        {
            Lean.Localization.LeanLocalization.SetCurrentLanguageAll("English");
        }
    }
}
