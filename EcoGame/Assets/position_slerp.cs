using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_slerp : MonoBehaviour
{
    private float minimum;
    private float maximum;
    [SerializeField] private float _devine = 0.2f;

    static float t = 0.0f;

    void Start()
    {
        minimum = transform.position.y - _devine;
        maximum = transform.position.y + _devine;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum, maximum, t), transform.position.z);

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
