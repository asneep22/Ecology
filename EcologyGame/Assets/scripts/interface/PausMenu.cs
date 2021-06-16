using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
     public GameObject pause_menu;
    public float leftLimit;
    public float rightLimit;
    public float bottomLimit;
    public float upperLimit;

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

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
    }

    public void pause_off()
    {
        pause_menu.SetActive(false);
        Time.timeScale = 1;
    }


}
