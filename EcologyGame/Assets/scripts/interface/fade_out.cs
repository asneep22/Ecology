using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_out : MonoBehaviour
{
    private Camera cam;
    [HideInInspector]
    public SpriteRenderer sr;

    private Color sprite_color;
    
    [Header("parameteers")]
    public float time; // the less the faster
    public float value; // the less the faster
    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(Screen.width, Screen.height, 1);
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -100f);

        StartCoroutine("faded_out");
    }

    public IEnumerator faded_out()
    {
        while (sr.color.a > 0)
        {
            sprite_color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - value);
            sr.color = sprite_color;
            yield return new WaitForSeconds(time);
        }
    }

    public IEnumerator faded_in()
    {
        while (sr.color.a < 1)
        {
            sprite_color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + value);
            sr.color = sprite_color;
            yield return new WaitForSeconds(time);
        }
    }
}
