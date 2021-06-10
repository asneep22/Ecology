using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_trash_into_array : MonoBehaviour
{
    private stretch_trash_status sts;
    // Start is called before the first frame update
    void Start()
    {
        sts = GameObject.FindGameObjectWithTag("stretch_status_element").GetComponent<stretch_trash_status>();
        sts.trash.Add(gameObject);
    }
}
