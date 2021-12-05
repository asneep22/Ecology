using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_parent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        scene_manager.player.transform.position = Vector3.zero;
        Camera.main.GetComponent<camera_follow>()._to_follow_obj = scene_manager.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
