using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialog_cloud : MonoBehaviour
{
    [HideInInspector] private float y_devine;
    [HideInInspector] private float _speed = 5;
    [HideInInspector] private TextMeshPro _tmpro;
    [HideInInspector] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float showTime = 3f;
    [SerializeField] private bool is_show;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
    }

    void Update()
    {
        
    }

    public void showCloud()
    {



    }
}
