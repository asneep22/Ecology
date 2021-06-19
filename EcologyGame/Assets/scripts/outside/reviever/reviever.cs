using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reviever : MonoBehaviour
{
    // Скрипт появления грузовика находится в скрипте "inspector", который висит на NPC - inspector

    public Inspector inspector_script;
    public Transform stop_point;
    public Transform dest_point;
    public float stop_time;
    public float distance = 3;

    private bool start_rev = false;

    private Rigidbody2D rb;

    // Update is called once per frame

    void Start()
    {
        transform.localPosition = new Vector3(0, 0, -1.6f);
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(start_from_stop_point());
    }
    void FixedUpdate()
    {

        if (!start_rev)
        {
            if (distance > 0.1f)
            {
                distance = Vector2.Distance(transform.position, stop_point.position);
                rb.AddForce(Vector2.right * (inspector_script.rev_speed * distance) * Time.fixedDeltaTime);
            }
        }
        else
        {
            distance = Vector2.Distance(transform.position, dest_point.position);
            rb.AddForce(Vector2.right * (inspector_script.rev_speed / distance * 5) * Time.fixedDeltaTime);

            if (transform.position.x > dest_point.transform.position.x)
            {
                inspector_script.is_create = false;
                inspector_script.inspector_text.text = "нажмите 'e', чтобы вызвать грузовик";
                Destroy(gameObject);
            }
        }
    }

    IEnumerator start_from_stop_point()
    {
        yield return new WaitForSeconds(stop_time);
        start_rev = true;
    }
}