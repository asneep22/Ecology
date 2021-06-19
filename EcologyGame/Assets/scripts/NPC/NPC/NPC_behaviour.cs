using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPC_behaviour : MonoBehaviour
{
    private NPC_instantitate NPC_inst;
    private Rigidbody2D rigi;
    private GameObject target;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        NPC_inst = GameObject.FindGameObjectWithTag("NPC_inst").GetComponent<NPC_instantitate>();
        target = GameObject.FindGameObjectWithTag("NPC_destr");
    }

    private void FixedUpdate()
    {
        rigi.AddForce(Vector2.left * NPC_inst.speed * Time.fixedDeltaTime);
        if (transform.position.x < target.transform.position.x)
        {
            NPC_inst.StartCoroutine("NPC_inst");
            Destroy(gameObject);
        }
    }

}
