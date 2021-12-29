using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class trash_tank_beh : MonoBehaviour
{
    private player_beh _player_beh;

    private Transform _player;

    [Header("Tank Propereties")]
    public float _put_in_the_tank_distance = 1.5f;
    public string trash_type;
    [Space]
    public List<Transform> _trash_array = new List<Transform>();
    public int _tank_fill_max;
    public int _tank_fill;
    public bool start_pass_trash;

    void Start()
    {
        if (scene_manager.player)
        {
            _player = scene_manager.player.transform;

            _player_beh = _player.GetComponent<player_beh>();
        }
    }


    public void OnPut(InputAction.CallbackContext context)
    {
        Put_trash_in_the_tank();
    }

    void Put_trash_in_the_tank()
    {
        float _distance = Vector2.Distance(transform.position, _player.position);


        if (_distance <= _put_in_the_tank_distance)
        {
            SpringJoint2D _springJoint2D = _player_beh._SpringJoint2D;

            if (_player_beh._trash_beh)
            {
                trash_beh _trash_beh = _player_beh._trash_beh;

                _trash_beh._trash_tank = transform;
                _trash_beh._trash_tank_beh = this;
                _trash_beh.GetComponent<BoxCollider2D>().enabled = false;

                if (_springJoint2D.enabled)
                {
                    _trash_beh.is_move_to_the_trash_tank = true;
                }

                _springJoint2D.enabled = false;
                _springJoint2D.connectedBody = null;
            }

        } 
    }

    public void Add_trash_In_the_tank(Transform _trash)
    {
        _trash.parent = transform;
        _trash_array.Add(_trash);
        _tank_fill++;
        _trash.gameObject.SetActive(false);
        _player_beh.catched_trash++;
    }


    public void Remove_trash_In_the_tank(Transform _trash)
    {
        _trash_array.Remove(_trash);
        _tank_fill--;
    }
    public void Tank_is_full_message()
    {
        Debug.Log("Tank is full");
    }

    public IEnumerator Start_pass_trash_to_the_car(Transform car)
    {
        start_pass_trash = true;

        while (_trash_array.Count > 0)
        {
            Transform item = _trash_array[0];

            trash_beh _trash_beh = item.GetComponent<trash_beh>();

            item.gameObject.SetActive(true);
            item.parent = transform.parent.parent;
            _trash_beh.is_move_to_the_trash_tank = false;
            _trash_beh.is_move_to_the_trash_car = true;
            _trash_beh.car = car;
            _trash_beh._trash_tank_beh = this;
            _trash_array.RemoveAt(0);

            yield return new WaitForSeconds(0.05f);

        }

        start_pass_trash = false;
        Debug.Log("pass has over");

    }


}
