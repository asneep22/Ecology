using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tras_add_force : MonoBehaviour

{
    public static void add_force(GameObject go, Transform target, float force_min, float force_max)
    {
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce((target.transform.position - go.transform.position).normalized * Random.Range(force_min, force_max) * Time.fixedDeltaTime, ForceMode2D.Impulse);
        go.transform.SetParent(null);
    }

}
