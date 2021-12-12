using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RandomLevel : MonoBehaviour
{
    private go_to_level _go_to_lvl;

    private void Start()
    {
        _go_to_lvl = GetComponent<go_to_level>();
    }

    public void OnActivity(InputAction.CallbackContext _context)
    {
            _go_to_lvl.Go_to_lvl(Random.Range(7, 10));
    }
}
