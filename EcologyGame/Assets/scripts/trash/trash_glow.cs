using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash_glow : MonoBehaviour
{
    public Material mat;

    private bool hint_activated = false;
    public float anim_speed = 0.5f;
    public float time = 5;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine("glow_on", time);

    }
    // Update is called once per frame
    public void Update()
    {
        if (!hint_activated)
        {
            float color_rgb = Mathf.Lerp(mat.GetColor("_Color").r, 0, Time.deltaTime * anim_speed);
            mat.SetColor("_Color", new Color(color_rgb, color_rgb, color_rgb));

            if (color_rgb < 0.05f)
            {
                StartCoroutine("glow_on", time);
            }

        } else
        {
            float color_rgb = Mathf.Lerp(mat.GetColor("_Color").r, 1, Time.deltaTime * anim_speed);
            mat.SetColor("_Color", new Color(color_rgb, color_rgb, color_rgb));

            if (color_rgb > 0.8f)
            {
                hint_activated = false;
            }
        }
    }

    IEnumerator glow_on(float time)
    {
        yield return new WaitForSeconds(time);
        hint_activated = true;
    }
}