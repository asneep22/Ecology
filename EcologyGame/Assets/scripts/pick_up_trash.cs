using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_trash : MonoBehaviour
{

    private GameObject player;
    private Transform trash_empty;
    private Rigidbody2D trash_rb;


    private bool trash_is_put = false;
    public float activity_distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trash_rb = transform.GetComponent<Rigidbody2D>();
        trash_empty = player.transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position); // дистанция между ГГ и мусором



        if (!trash_is_put) // если мусор не поднят
        {

            if (distance < activity_distance && Input.GetKeyDown(KeyCode.E) && trash_empty.transform.childCount < 1)
            {

                transform.SetParent(trash_empty); // устанавливаем родителя мусору. Этот родитель находится около ГГ
                trash_is_put = !trash_is_put; // меняем состояние мусора на противоположное
            }
        }
        else
        {

            transform.localPosition = (transform.parent == trash_empty) ? Vector3.zero : transform.localPosition;


            if (Input.GetKeyDown(KeyCode.E)) // Отпускание мусора при повторном нажантии на клавишу, если тот поднят
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");


                transform.SetParent(null);
                trash_rb.AddForce(new Vector3(horizontal, vertical, 0) * Time.deltaTime * 1000);
                trash_rb.gravityScale = 0.4f;
                StartCoroutine("gravity");
                trash_is_put = !trash_is_put;
            }
        }
    }

    IEnumerator gravity()
    {
        yield return new WaitForSeconds(0.025f);
        trash_rb.gravityScale = 0;
    }
}
