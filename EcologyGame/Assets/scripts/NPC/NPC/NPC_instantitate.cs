using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_instantitate : MonoBehaviour
{

    public GameObject npc;
    [Header("Time")]
    public float time_min;
    public float time_max;

    [Header("Npc_charact")]
    public float speed;

    void Start()
    {
        StartCoroutine(NPC_inst());
    }

   public IEnumerator NPC_inst()
    {
        float time = Random.Range(time_min, time_max);
        yield return new WaitForSeconds(time);
        GameObject inst_NPC = Instantiate(npc, transform);
        inst_NPC.AddComponent<NPC_behaviour>();

    }
    
}
