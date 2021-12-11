using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class set_parent : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private Transform _player_spawn_pos;

    //script must be applied for the root level paarent//

    void Start()
    {
        if (scene_manager.player)
        {

            player = scene_manager.player;

            player.transform.position = _player_spawn_pos.position;
            player.transform.parent = transform;
            Camera.main.GetComponent<camera_follow>()._to_follow_obj = player.transform;
        }
    }
}
