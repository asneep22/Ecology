using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontend_opacicty : MonoBehaviour
{
    private SpriteRenderer _sRenderer;
    private Transform _player;
    [SerializeField] private float _newOpacity = 0.5f;
    [SerializeField] private float _distance = 3f;
    [SerializeField] private float _speed = 5;
    void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
        _player = scene_manager.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(_player.position, transform.position);

        if (_player.position.y > transform.position.y && distance < _distance)
        {
            _sRenderer.color = new Color(_sRenderer.color.r, _sRenderer.color.g, _sRenderer.color.b, Mathf.Lerp(_sRenderer.color.a, _newOpacity, _speed * Time.deltaTime));
        } else {
            _sRenderer.color = new Color(_sRenderer.color.r, _sRenderer.color.g, _sRenderer.color.b, Mathf.Lerp(_sRenderer.color.a, 1, _speed * Time.deltaTime));
        }
    }
}
