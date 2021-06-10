using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_from_level : MonoBehaviour
{

    private fade_out fade;
    private GameObject player;

    private stretch_trash_status trash_array;

    public float activity_distance;
    public bool exit = false;
    public int lvl_value;

    void Start()
    {
        fade = Camera.main.GetComponentInChildren<fade_out>();
        player = GameObject.FindGameObjectWithTag("Player");
        trash_array = GameObject.FindGameObjectWithTag("stretch_status_element").GetComponent<stretch_trash_status>();

    }

    // Update is called once per frame
    void Update()
    {
    
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < activity_distance && trash_array.trash.Count == 0 && Input.GetKeyDown(KeyCode.E) && !exit)
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
