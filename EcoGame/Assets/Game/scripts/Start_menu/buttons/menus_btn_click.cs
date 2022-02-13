using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Continue()
    {

        Menu _menu = transform.parent.parent.GetComponent<Menu>();

        Time.timeScale = 1;
        Destroy(_menu._menu_obj);
        _menu.is_called = false;

    }

    public void Restart()
    {

        Menu _menu = transform.parent.parent.GetComponent<Menu>();

        Time.timeScale = 1;
        go_to_level _go_to_Level = gameObject.AddComponent<go_to_level>();
        _go_to_Level.Go_to_lvl(SceneManager.GetActiveScene().buildIndex);
        Destroy(_menu._menu_obj);

    }

    public void ToMenu()
    {
        Menu _menu = transform.parent.parent.GetComponent<Menu>();

        Time.timeScale = 1;
        Destroy(_menu._menu_obj);
        _menu.is_called = false;

        SceneManager.LoadScene(0);
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
