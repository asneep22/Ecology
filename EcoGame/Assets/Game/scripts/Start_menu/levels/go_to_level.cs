using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_level : MonoBehaviour
{
    [SerializeField] private int _lvl_index;
    [SerializeField] private bool _is_ready;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out player_beh player_behaviour))
        {
            scene_manager.player = collision.gameObject;
            _is_ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _is_ready = false;
    }


    private void Update()
    {
        if (_is_ready && Input.GetKeyDown(KeyCode.E))
        {
            Go_to_lvl(_lvl_index);
        }
    }

    public void Go_to_lvl(int lvl)
    {
        Transform player = scene_manager.player.transform;

        player.parent = null;
        DontDestroyOnLoad(player);

        SceneManager.LoadScene(lvl);
    }
}
