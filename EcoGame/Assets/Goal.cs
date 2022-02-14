using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    [SerializeField] private List<string> _text = new List<string>();
    [SerializeField] private TextMeshProUGUI _tmpro;

    void Start()
    {
    }

    public void NextGoal()
    {
        _text.RemoveAt(0);
        _tmpro.text = _text[0];
    }
}
