using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_add_trash_tank_to_array : MonoBehaviour
{
    private trash_car _trash_car;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out trash_tank_beh _trash_tank))
        {
            Debug.Log("trash_tank_detected");
            _trash_car = transform.parent.GetComponent<trash_car>();

            _trash_car.trash_tanks.Add(_trash_tank);
            _trash_car.can_pass_trash = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out trash_tank_beh _trash_tank))
        {
            _trash_car = transform.parent.GetComponent<trash_car>();

            _trash_car.trash_tanks.Remove(_trash_tank);
            _trash_car.can_pass_trash = false;
        }
    }

}
