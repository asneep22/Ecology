using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class trash_car : MonoBehaviour
{
    private GameObject _player;

    public List<trash_tank_beh> trash_tanks = new List<trash_tank_beh>();
    [SerializeField] private float _pass_distance = 3f;

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
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance < _pass_distance && trash_tanks.Count > 0)
        {

            Debug.Log($"there is {trash_tanks.Count} trash tanks");


            foreach (trash_tank_beh item in trash_tanks)
            {
                if (!item.start_pass_trash)
                {
                    item.StartCoroutine(item.Start_pass_trash_to_the_car());
                }

            }

        }
    }
}
