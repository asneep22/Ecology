using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretch_trash_status : MonoBehaviour
{
    public List<GameObject> trash;
    public float stretch_power_value_for_the_unit_trash;
    public float start_scale_x;
    public float speed;

    // Start is called before the first frame update
    void Awake()
    {

        start_scale_x = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float x_stretch = Mathf.Lerp(transform.localScale.x, trash.Count * stretch_power_value_for_the_unit_trash, Time.deltaTime * speed);
        transform.localScale = new Vector3(x_stretch, transform.localScale.y, transform.localScale.z);

        float x_pos = transform.parent.localPosition.x;
        transform.localPosition = new Vector3(x_pos + 0.02f, transform.localPosition.y, transform.localPosition.z);
    }
}
