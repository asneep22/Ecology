using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_player_btn : MonoBehaviour
{

    [SerializeField] private GameObject _first_character;
    [SerializeField] private GameObject _second_character;

    public void Destroy_player()
    {
        _first_character.SetActive(true);
        _second_character.SetActive(true);

        camera_follow _camera_follow = Camera.main.GetComponent<camera_follow>();

        if (_camera_follow._to_follow_obj)
        {
            Destroy(_camera_follow._to_follow_obj.gameObject);
        }
    }
}
