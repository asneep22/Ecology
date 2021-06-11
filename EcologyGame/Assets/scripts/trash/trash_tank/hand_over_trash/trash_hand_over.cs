using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_hand_over : MonoBehaviour
{
    private GameObject money;
    private List<GameObject> money_array = new List<GameObject>();

    private GameObject target;
    private float speed = 3f;

    public Vector3 start_scale;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject.GetComponent<pick_up_trash>());
        Destroy(gameObject.GetComponent<add_trash_into_array>());
    }

    void Start()
    {
        money = GameObject.FindGameObjectWithTag("money");

        start_scale = transform.localScale;

        if (GameObject.FindGameObjectWithTag("target_for_the_trash") != null)
        {
            target = GameObject.FindGameObjectWithTag("target_for_the_trash");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("target_for_the_trash") != null)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            transform.localScale = new Vector3(start_scale.x * distance, start_scale.y * distance, transform.localScale.z);

            float target_position_x = (Mathf.Lerp(transform.position.x, target.transform.position.x, Time.deltaTime * speed));
            float target_position_y = (Mathf.Lerp(transform.position.y, target.transform.position.y, Time.deltaTime * speed));
            transform.position = new Vector3(target_position_x, target_position_y, target_position_y);

            if (distance <= 0.2f)
            {
                Destroy(gameObject);
            }
        }
    }
}
