using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script must be applied for trash root parent

public class Lose : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    private GameObject _player;

    [SerializeField] private int _trash_count_lose;


    private void Start()
    {
        _player = scene_manager.player;
    }

    private void Update()
    {
        TryLose();
    }

    public void TryLose()
    {
        if (scene_manager.player == null || transform.childCount >= _trash_count_lose) {

            scene_manager.player = _player;
            _menu.CallRestartMenu();

        }
    }
}
