using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{

    private Camera cam;

    public float camera_speed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, transform.position.x, camera_speed * Time.fixedDeltaTime), Mathf.Lerp(cam.transform.position.y, transform.position.y, camera_speed * Time.fixedDeltaTime), -150f);
    }
}
