using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_trash_inst : MonoBehaviour
{

    private Object[] trash;

    private GameObject trash_inst;
    void Start()
    {
        trash = Resources.LoadAll("trash");
        trash_inst = (GameObject)Instantiate(trash[Random.Range(0, trash.Length)], transform);
        trash_inst.transform.localPosition = Vector3.zero;
        Destroy(trash_inst.GetComponent<pick_up_trash>());
        Destroy(trash_inst.GetComponent<add_trash_into_array>());
        Destroy(this);
    }

    void Update()
    {
    }
}
