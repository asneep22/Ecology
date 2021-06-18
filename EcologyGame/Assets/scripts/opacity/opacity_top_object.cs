using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opacity_top_object : MonoBehaviour
{

    private SpriteRenderer sp_rend;

    private GameObject player;


    private float max_opacity = 1;
    public float min_opacity = 0.5f;
    public float activity_distance = 0.23f;
    public float change_speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        sp_rend = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (player.transform.position.y > transform.position.y - 0.15f && activity_distance > distance)
        {
            float opacity = Mathf.Lerp(sp_rend.color.a, min_opacity, change_speed * Time.deltaTime);

            sp_rend.color = new Color(sp_rend.color.r, sp_rend.color.g, sp_rend.color.b, opacity);

        }
        else
        {
            float opacity = Mathf.Lerp(sp_rend.color.a, max_opacity, change_speed * Time.deltaTime);

            sp_rend.color = new Color(sp_rend.color.r, sp_rend.color.g, sp_rend.color.b, opacity);
        }
    }
}
