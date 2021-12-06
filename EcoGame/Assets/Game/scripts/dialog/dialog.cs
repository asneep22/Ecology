using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialog : MonoBehaviour
{
    public List<string> dialog_texts = new List<string>();
    [SerializeField] private float _next_dialog_time = 1f;

    private bool is_started;
    private float _distance;
    [SerializeField] private float start_dialog_dist = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector2.Distance(transform.position, scene_manager.player.transform.position);

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
        bool _is_first_pat = false;

        while (dialog_texts.Count > 0)
        {
            _is_first_pat = !_is_first_pat;

            Transform _active_paticipant = (_is_first_pat) ? _paticipant_1 : _paticipant_2;

            Debug.Log($"{_active_paticipant.name} says: {dialog_texts[0]}");
            dialog_texts.RemoveAt(0);

            yield return new WaitForSeconds(_next_dialog_time);
        }

        is_started = false;
    }
}
