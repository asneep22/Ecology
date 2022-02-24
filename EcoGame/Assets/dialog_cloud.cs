using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialog_cloud : MonoBehaviour
{
    [HideInInspector] private float _speed = 5;
    [HideInInspector] public TextMeshPro tmpro;
    [HideInInspector] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float showTime = 3f;
    public bool is_show;
    public bool start_show_time;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
        tmpro = transform.GetComponentInChildren<TextMeshPro>();
  
    }

    void Update()
    {
        TryShowCloud();
    }

    public void TryShowCloud()
    {
        if (is_show)
        {

            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, Mathf.Lerp(_spriteRenderer.color.a, 1f, Time.deltaTime * _speed));
            tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, Mathf.Lerp(tmpro.color.a, 1f, Time.deltaTime * _speed));

            if (!start_show_time)
            {
                start_show_time = true;
                StartCoroutine(show());
            }


        } else
        {

            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, Mathf.Lerp(_spriteRenderer.color.a, 0, Time.deltaTime * _speed));
            tmpro.color = new Color(tmpro.color.r, tmpro.color.g, tmpro.color.b, Mathf.Lerp(tmpro.color.a, 0, Time.deltaTime * _speed));

        }
    }

    private IEnumerator show()
    {
        yield return new WaitForSeconds(showTime);
        is_show = false;
        start_show_time = false;
    }
}
