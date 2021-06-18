using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class pick_up_trash : MonoBehaviour
{

    private GameObject player;
    private Player_behaviour p_beh;

    private Transform trash_empty;
    private Rigidbody2D trash_rb;
    private Collider2D coll_2d;

    public float distance;

    private bool trash_is_put = false;
    public float activity_distance = 0.2f;

     
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());


        player = GameObject.FindGameObjectWithTag("Player");
        trash_rb = transform.GetComponent<Rigidbody2D>();
        coll_2d = GetComponent<Collider2D>();
        trash_empty = player.transform.GetChild(0);

        p_beh = player.GetComponent<Player_behaviour>();
    }

    // Update is called once per frame
    void Update()
    {

       activity_distance = stats.player_hand_length;
       distance = Vector2.Distance(player.transform.position, transform.position); // дистанция между ГГ и мусором



        if (!trash_is_put) // если мусор не поднят
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y + 0.1f);

            if (p_beh.can_run && distance < activity_distance && Input.GetKeyDown(KeyCode.E) && trash_empty.transform.childCount < 1)
            {

                transform.SetParent(trash_empty); // устанавливаем родителя мусору. Этот родитель находится около ГГ
                trash_is_put = !trash_is_put; // меняем состояние мусора на противоположное
                coll_2d.enabled = false; // выключаем коллайдер
            }
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
            transform.localPosition = (transform.parent == trash_empty) ? Vector3.zero : transform.localPosition; 


            if (p_beh.can_run && Input.GetKeyDown(KeyCode.E)) // Отпускание мусора при повторном нажантии на клавишу, если тот поднят
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");


                transform.SetParent(null);
                trash_rb.AddForce(new Vector3(horizontal, vertical, 0) * Time.deltaTime * 2, ForceMode2D.Impulse);
                trash_rb.gravityScale = 0.4f;
                StartCoroutine("gravity");
                trash_is_put = !trash_is_put;
                coll_2d.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.CompareTag("region"))
        {
            StopCoroutine(destroy());
            if (gameObject.GetComponent<add_trash_into_array>() == null)
            {
                gameObject.AddComponent<add_trash_into_array>();
            }
            gameObject.layer = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {

        if (!trash_is_put)
        {
            if (col.CompareTag("region"))
            {
                StartCoroutine(destroy());
                Destroy(gameObject.GetComponent<add_trash_into_array>());
            }
        }
    }


    IEnumerator gravity()
    {
        yield return new WaitForSeconds(0.025f);
        trash_rb.gravityScale = 0;
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(3);
        if (gameObject.GetComponent<add_trash_into_array>() == null)
        {
            Destroy(gameObject);
        }
    }
}
