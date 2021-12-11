using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script must be applied for the root level parent

public class Change_condition_after_time : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private List<GameObject> change_condition_objects = new List<GameObject>();
    private bool change_ready;

    private void Start()
    {
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(_time);

        foreach (var item in change_condition_objects)
        {

            item.gameObject.SetActive(!item.gameObject.activeSelf);
        }



    }
}
