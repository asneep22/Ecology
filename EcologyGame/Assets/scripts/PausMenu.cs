using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    [SerializeField]
     public GameObject pause_menu;


    private SpriteRenderer menu_sr_renderer;
    
    void Start()
    {
        pause_menu.SetActive(false);
        menu_sr_renderer = pause_menu.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause_menu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            pause_menu.SetActive(true);
            Time.timeScale = 0;

        } else if (pause_menu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {

            pause_menu.SetActive(false);
            Time.timeScale = 1;
        }
    }


}
