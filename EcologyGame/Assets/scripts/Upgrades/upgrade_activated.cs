using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade_activated : MonoBehaviour
{

    public float plus_speed = 15;
    public float hand_length = 0.02f;
    private upgrade_parametr up_par;


    private void Awake()
    {

        up_par = transform.GetComponent<upgrade_parametr>();

        switch (up_par.parametr)
        {
            case "player_speed":
                player_stats.player_speed += plus_speed;
                Debug.Log($"player_speed = {player_stats.player_speed}");
                break;

            case "player_hand_length":
                player_stats.player_hand_length += hand_length;
                Debug.Log($"player_hand_length = {player_stats.player_hand_length}");
                break;

            case "":
                Debug.Log("select parametr");
                break;

            default:
                break;
        }
    }
    private void Start()
    {
    }
}
