using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose_player : MonoBehaviour
{
    [SerializeField] private Transform _frst_character;
    [SerializeField] private Transform _second_character;

    [SerializeField] private Transform _player;

    private void OnMouseDown()
    {
        Transform _character_obj = Instantiate(_player);
        _character_obj.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

        _frst_character.gameObject.SetActive(false);
        _second_character.gameObject.SetActive(false);
    }
}
