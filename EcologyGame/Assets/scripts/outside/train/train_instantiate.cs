using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_instantiate : MonoBehaviour
{

    public GameObject train;

    [Header("time")]
    public float time_min;
    public float time_max;

    [Header("train_ñharacteristics")]
    public float speed;
    public float max_cam_shake_effect_pos_x;
    public float max_cam_shake_effect_pos_y;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(train_inst());
    }

    public IEnumerator train_inst() {
        float time = Random.Range(time_min, time_max);
        yield return new WaitForSeconds(time);
        GameObject inst_train = Instantiate(train);
        inst_train.AddComponent<train_behaviour>();
        inst_train.transform.localPosition = transform.localPosition;
    }
}
