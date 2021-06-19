using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class strt_menu_btns : MonoBehaviour
{

    public Transform start_menu;

    public void play()
    {
        SceneManager.LoadScene(0);
    }

    public void options()
    {
        start_menu.GetComponent<menu_position>().start_menu_pos_devine = -2000;
    }

    public void exit()
    {
        Application.Quit();
    }

}
