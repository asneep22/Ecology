using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_exit : MonoBehaviour
{

    private player_beh _player_beh;

    [SerializeField] private GameObject _exit;
    public int need_count = 30;


    private void Start()
    {
        _player_beh = scene_manager.player.GetComponent<player_beh>();    
    }

    private void Update()
    {
        TryOpenExit();
    }


    public void TryOpenExit()
    {
        float _count = need_count - _player_beh.catched_trash;
        Debug.Log(_count);

        if (_count == 0)
        {
            _exit.SetActive(true);
            Destroy(this);
        }
    }
}
