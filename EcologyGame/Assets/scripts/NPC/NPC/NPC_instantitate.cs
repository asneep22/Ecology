using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_instantitate : MonoBehaviour
{

    public GameObject[] citizen;
    private int min_index = 0; 
    private int max_index;
    private int citizen_index;

    public Transform target;
    public Transform add_force_position;

    [Header("Time")]
    public float time_min;
    public float time_max;

    [Header("Npc_charact")]
    public float min_speed;
    public float max_speed;
    [HideInInspector]
    public float speed;
    public float pos_y_devine;
    public bool npc_is_going_left = true;

    [Header("trash_charact")]
    public float hand_over_time_max;
    public float force_max;

    void Start()
    {
        max_index = citizen.Length;

        StartCoroutine(NPC_inst());
    }

    public IEnumerator NPC_inst()
    {
        float time = Random.Range(time_min, time_max);

        while (true)
        {
            citizen_index = Random.Range(min_index, max_index);
            speed = Random.Range(min_speed, max_speed);
            GameObject inst_NPC = Instantiate(citizen[citizen_index], transform);
            float dev = (Random.Range(-pos_y_devine, pos_y_devine));
            inst_NPC.transform.position = new Vector3(transform.position.x, transform.position.y + dev, transform.position.y + dev);
            inst_NPC.transform.localScale = (npc_is_going_left) ? new Vector3(-1,1,1) : new Vector3(1, 1, 1);
            inst_NPC.AddComponent<NPC_behaviour>();
            inst_NPC.GetComponent<NPC_behaviour>().speed = speed;
            inst_NPC.GetComponent<NPC_behaviour>().target = target;
            inst_NPC.GetComponent<NPC_behaviour>().hand_over_pos = add_force_position;
            yield return new WaitForSeconds(time);
        }

    }
    
}
