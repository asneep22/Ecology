using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_animation_pulse : MonoBehaviour
{

    public float devine;
    public float speed;
    private float scale;
    public float anim_reverse_time;

    private Vector2 start_scale;
    void Start()
    {
        start_scale = transform.localScale;
        StartCoroutine(reverse_anim(anim_reverse_time));
    }

    public void Update()
    {
        scale = Mathf.Lerp(transform.localScale.x, start_scale.x + devine, Time.deltaTime * speed);

        transform.localScale = new Vector2(scale, scale);
    }

    IEnumerator reverse_anim(float time)
    {
        yield return new WaitForSeconds(time);
        devine = -devine;
        StartCoroutine(reverse_anim(anim_reverse_time));
    }
}
