using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class set_parent : MonoBehaviour
{

    private GameObject player;

    //script must be applied for the root level paarent//

    void Start()
    {
        player = scene_manager.player;

        player.transform.position = Vector3.zero;
        player.transform.parent = transform;
        Camera.main.GetComponent<camera_follow>()._to_follow_obj = player.transform;
    }
}