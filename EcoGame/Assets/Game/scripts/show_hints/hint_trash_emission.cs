using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_trash_emission : MonoBehaviour
{
    [SerializeField] Shader _shader;
    [SerializeField] private float _speed = 8;
    private SpriteRenderer _rend;
    float _EmissionStrength = 0;
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();

        _rend.material.shader = _shader;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menu.is_pause)
        {
            ShowHint();
        }
    }

    private void ShowHint()
    {

        if (Input.GetKey(KeyCode.Tab))
        {
            _rend.material.SetFloat("_EmissionStrength", Mathf.Lerp(_rend.material.GetFloat("_EmissionStrength"), 1,  _speed * Time.deltaTime));
        }
        else
        {
            _rend.material.SetFloat("_EmissionStrength", Mathf.Lerp(_rend.material.GetFloat("_EmissionStrength"), 0, _speed * Time.deltaTime));
        }
    }
}
