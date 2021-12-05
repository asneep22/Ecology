using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_hints : MonoBehaviour
{
    private player_beh _player_beh;

    [SerializeField] private GameObject _hint;
     private GameObject _player;

    private GameObject hint_go;

    private float show_hint_distance;


    private void Start()
    {
        _player = scene_manager.player;
        _player_beh = _player.GetComponent<player_beh>();
        show_hint_distance = _player_beh.show_hint_distance;
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance < show_hint_distance)
        {
            Show(_hint);
        }
        else
        {
            Unshow();
        }
    }

    private void OnDisable()
    {
        Unshow();
    }

    public void Show(GameObject hint)
    {
        if (!hint_go)
        {
            hint_go = Instantiate(hint);
        }

        hint_go.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z - 1f);
    }

    public void Unshow()
    {
        if (hint_go != null)
        {
            Destroy(hint_go);
            hint_go = null;
        }
    }
}
