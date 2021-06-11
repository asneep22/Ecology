using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neigbours_create : MonoBehaviour
{
    private Camera cam;

    private bool cam_is_bigger = false;
    private float time_min = 5;
    private float time_max = 10;
    private float random_time;

    private lvl1_hints hint_scr;
    private GameObject hint_interface;
    void Start()
    {
        cam = Camera.main;

        hint_scr = GameObject.FindGameObjectWithTag("hint_interface").GetComponent<lvl1_hints>();
        hint_interface = GameObject.FindGameObjectWithTag("hint_interface");

        random_time = Random.Range(time_min, time_max);
        StartCoroutine("negbours_create", random_time);
    }

    private void Update()
    {
        if (cam_is_bigger)
        {
            CameraExtension.camera_scale_bigger(cam, 2f, 5);
        } else
        {
            CameraExtension.camera_scale_bigger(cam, 0.8f, 5);
        }
    }

    IEnumerator negbours_create(float time)
    {
        yield return new WaitForSeconds(time);
        cam_is_bigger = !cam_is_bigger;
        StartCoroutine("neigbour_create_hint");
    }

    IEnumerator neigbour_create_hint()
    {
        yield return new WaitForSeconds(5);
        cam_is_bigger = !cam_is_bigger;
        hint_scr.hint_index = 25;
        hint_interface.SetActive(true);
        StartCoroutine("neigbor_scrip_destory");
    }

    IEnumerator neigbor_scrip_destory() {
        yield return new WaitForSeconds(3);
        Destroy(this);
    }
}
