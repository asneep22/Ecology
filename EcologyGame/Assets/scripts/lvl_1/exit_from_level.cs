using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_from_level : MonoBehaviour
{

    private fade_out fade;
    private GameObject player;

    public float activity_distance;
    public bool exit = false;
    public int lvl_value;

    void Start()
    {
        fade = Camera.main.GetComponentInChildren<fade_out>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < activity_distance && Input.GetKeyDown(KeyCode.E) && !exit)
        {
            StartCoroutine(fade.faded_in());
            exit = !exit;
        }

        if (fade.sr.color.a > 0.95 && exit == true)
        {
            SceneManager.LoadScene(lvl_value);
            exit = !exit;
        }

    }
}
