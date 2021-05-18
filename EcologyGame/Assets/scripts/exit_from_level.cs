using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit_from_level : MonoBehaviour
{

    private fade_out fade;
    private GameObject player;

    public float activity_distance;
    public int lvl_value;

    void Start()
    {
        fade = Camera.main.GetComponentInChildren<fade_out>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {

            if (Vector2.Distance(player.transform.position, transform.position) < activity_distance)
            {
                StartCoroutine(fade.faded_in());
                StartCoroutine("load_next_lvl");
            }

        }
    }

    IEnumerator load_next_lvl()
    {
        yield return new WaitForSeconds(2);
        if (fade.sr.color.a > 0.95)
        {
            SceneManager.LoadScene(lvl_value);
        }
    }
}
