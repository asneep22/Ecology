using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(add_trash_into_array))]
public class pick_up_trash : MonoBehaviour
{

    private GameObject player;
    private Transform trash_empty;
    private Rigidbody2D trash_rb;
    private Collider2D coll_2d;


    private bool trash_is_put = false;
    public float activity_distance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        trash_rb = transform.GetComponent<Rigidbody2D>();
        coll_2d = GetComponent<Collider2D>();
        trash_empty = player.transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position); // ��������� ����� �� � �������



        if (!trash_is_put) // ���� ����� �� ������
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 3);

            if (distance < activity_distance && Input.GetKeyDown(KeyCode.E) && trash_empty.transform.childCount < 1)
            {

                transform.SetParent(trash_empty); // ������������� �������� ������. ���� �������� ��������� ����� ��
                trash_is_put = !trash_is_put; // ������ ��������� ������ �� ���������������
                coll_2d.enabled = false; // ��������� ���������
            }
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
            transform.localPosition = (transform.parent == trash_empty) ? Vector3.zero : transform.localPosition; 


            if (Input.GetKeyDown(KeyCode.E)) // ���������� ������ ��� ��������� �������� �� �������, ���� ��� ������
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

    IEnumerator gravity()
    {
        yield return new WaitForSeconds(0.025f);
        trash_rb.gravityScale = 0;
    }
}
