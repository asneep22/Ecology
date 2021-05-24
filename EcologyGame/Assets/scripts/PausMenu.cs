using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void PausOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }


}
