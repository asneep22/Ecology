using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_level : MonoBehaviour
{
    [SerializeField] private int _lvl_index;
    [SerializeField] private bool _is_ready;
    private Controls _controls;


    private void Update()
    {
        To_next_lvl();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            _controls = collision.gameObject.GetComponent<Controls>();

            _is_ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _is_ready = false;
    }


    void To_next_lvl()
    {
        if (_controls)
        {
            if (Input.GetKeyDown(_controls.activity) && _is_ready)
            {
                SceneManager.LoadScene(_lvl_index);
            }
        }

    }
}
