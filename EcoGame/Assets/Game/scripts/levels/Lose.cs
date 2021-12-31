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
    }

    private void Update()
    {
        TryLose();
    }

    public void TryLose()
    {
        if (transform.childCount >= _trash_count_lose) {

            _menu.CallRestartMenu();
        }
    }

    public void GameLose()
    {
        _menu = Camera.main.GetComponentInChildren<Menu>();
        _menu.CallRestartMenu();
    }
}
