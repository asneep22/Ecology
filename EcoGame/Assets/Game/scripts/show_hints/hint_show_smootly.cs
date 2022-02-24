using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint_show_smootly : MonoBehaviour
{
    private RectTransform _hint;
    private Vector3 _start_vector;
    [SerializeField] private Vector3 _to_vector;
    [SerializeField] private float _speed = 8f;
    void Start()
    {
        _hint = transform.GetComponent<RectTransform>();
        _start_vector = _hint.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Menu.is_pause)
        {
            showHint();
        }
    }

    private void showHint()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            _hint.anchoredPosition = Vector3.Lerp(_hint.anchoredPosition, _to_vector, _speed * Time.deltaTime);
        }
        else
        {
            _hint.anchoredPosition = Vector3.Lerp(_hint.anchoredPosition, _start_vector, _speed * Time.deltaTime);
        }
    }
}
