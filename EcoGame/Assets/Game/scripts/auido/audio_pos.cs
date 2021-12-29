using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_pos : MonoBehaviour
{

    private GameObject _player;

    private void Start()
    {
        _player = scene_manager.player;
    }
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _player.transform.localPosition.z);
    }
}
