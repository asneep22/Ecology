using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialog : MonoBehaviour
{
    public List<string> dialog_texts = new List<string>();
    [SerializeField] private float _next_dialog_time = 1f;

    private bool is_started;
    private float _distance;
    [SerializeField] private float start_dialog_dist = 5f;

    [SerializeField] private SpriteRenderer _dialog_backround_sr;
    [SerializeField] private Transform _dialog_backround;
    [SerializeField] private float _dialog_backround_height = 1;
    [SerializeField] private TextMeshPro _text;

    void Start()
    {
        if (!_dialog_backround_sr)
        _dialog_backround_sr = _dialog_backround.GetComponent<SpriteRenderer>();

        _dialog_backround_sr.color = new Color(_dialog_backround_sr.color.r, _dialog_backround_sr.color.g, _dialog_backround_sr.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_manager.player != null)
        {
            _distance = Vector2.Distance(transform.position, scene_manager.player.transform.position);
        }

        if (_distance < start_dialog_dist && !is_started)
        {
            TryStartDialog();
        }
    }

    public void AddDialog(List<string> add_dialogs_array)
    {
        dialog_texts.AddRange(add_dialogs_array.ToArray());
    }

    void TryStartDialog()
    {

        if (dialog_texts.Count != 0)
        {


            if (_distance < start_dialog_dist)
            {

                StartCoroutine(Next_dialog(transform, scene_manager.player.transform));
                is_started = true;

            }
        }

    }

    IEnumerator Next_dialog(Transform _paticipant_1 = null, Transform _paticipant_2 = null)
    {
        bool _is_first_pat = true;
        Vector3 _firstPatBackrPos = new Vector3(_paticipant_1.position.x, _paticipant_1.position.y + _dialog_backround_height, transform.position.z);

        if (_paticipant_2.TryGetComponent(out player_movement _player_movement))
            _player_movement.can_move = false;

        while (dialog_texts.Count > 0)
        {
            _text.text = "";
            Vector3 _secondPatBackrPos = new Vector3(_paticipant_2.position.x, _paticipant_2.position.y + _dialog_backround_height, transform.position.z);

            Transform _active_paticipant = (_is_first_pat) ? _paticipant_1 : _paticipant_2;
            _dialog_backround.transform.position = (_active_paticipant == _is_first_pat) ? _firstPatBackrPos : _secondPatBackrPos;

            _dialog_backround_sr.color = new Color(_dialog_backround_sr.color.r, _dialog_backround_sr.color.g, _dialog_backround_sr.color.b, 100);

            StartCoroutine(static_text.PrintTextMeshProByPrinMachine(dialog_texts[0], _text, 0.035f));
            dialog_texts.RemoveAt(0);

            _is_first_pat = !_is_first_pat;

            yield return new WaitForSeconds(_next_dialog_time);
        }

        if (_player_movement)
            _player_movement.can_move = true;

        is_started = false;
        _dialog_backround_sr.color = new Color(_dialog_backround_sr.color.r, _dialog_backround_sr.color.g, _dialog_backround_sr.color.b, 0);
    }
}
