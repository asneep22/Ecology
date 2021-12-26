using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump_into_player : MonoBehaviour
{
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out player_beh _player_beh) && (_rb.velocity.x > 5f || _rb.velocity.x < -5f))
        {
            Destroy(_player_beh.gameObject);
            scene_manager.player = null;
        }
    }
}
