using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script must be applied for trash root parent

public class Lose : MonoBehaviour
{
    [SerializeField] private int _trash_count_lose;

    private void Update()
    {
        TryLose();
    }

    public void TryLose()
    {
        if (scene_manager.player == null || transform.childCount >= _trash_count_lose) {
            Debug.Log("YouLose");
        }
    }
}
