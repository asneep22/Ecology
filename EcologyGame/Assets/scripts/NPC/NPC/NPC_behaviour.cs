using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPC_behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public Transform hand_over_pos;
    public float speed;
    private bool inst_trash;
    public float force_max;
    public float time_max;
    public float procent = 0.2f;
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();

        float random_procent = Random.value;
        inst_trash = (random_procent <= procent);

        if (inst_trash)
        {
            gameObject.AddComponent<random_trash_inst>();

        }
    }

    private void FixedUpdate()
    {

        if (inst_trash && transform.childCount > 0)
        {

            transform.GetChild(0).localPosition = new Vector3(-0.02f, -0.02f, 0.01f);
        }

        rb.AddForce(target.transform.localPosition * speed * Time.fixedDeltaTime);

        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < 0.1f)
        {
            Destroy(gameObject);
        }

        float add_force_distance = Vector2.Distance(transform.position, hand_over_pos.transform.position);
        if (add_force_distance < 1 && transform.childCount > 0)
        {
            float time = Random.Range(0, time_max);
            StartCoroutine(trash_hand_over(time));
        }
    }

    IEnumerator trash_hand_over(float time)
    {
        float force = Random.Range(0.2f, force_max);
        yield return new WaitForSeconds(time);

        if (transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.AddComponent<pick_up_trash>();
            transform.GetChild(0).gameObject.AddComponent<add_trash_into_array>();
            tras_add_force.add_force(transform.GetChild(0).gameObject, GameObject.FindGameObjectWithTag("Player").transform, 100f, force);
        }
    }

}
