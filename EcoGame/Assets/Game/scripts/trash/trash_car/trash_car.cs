using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class trash_car : MonoBehaviour
{
    private GameObject _player;
    [HideInInspector] public bool can_pass_trash;

    public List<trash_tank_beh> trash_tanks = new List<trash_tank_beh>();

    private void Start()
    {
        _player = scene_manager.player;   
    }


    public void onActivity(InputAction.CallbackContext context)
    {

        Try_pass_trash();
    }

    private void Try_pass_trash()
    {

        if (trash_tanks.Count > 0 && can_pass_trash)
        {

            Debug.Log($"there is {trash_tanks.Count} trash tanks");


            foreach (trash_tank_beh item in trash_tanks)
            {
                if (!item.start_pass_trash)
                {
                    item.StartCoroutine(item.Start_pass_trash_to_the_car(transform));
                    item.start_pass_trash = true;
                }

            }

        }
    }
}
