using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class tank_behaviour : MonoBehaviour
{
    private GameObject player;
    private Player_behaviour p_beh;

    public TextMeshPro text;


    private GameObject trash_empty;
    private Transform trash_in_the_hand;

    private stretch_trash_status sts;


    [Header("tank_status")]
    public List<GameObject> object_inside = new List<GameObject>();
    private GameObject rnd_object_in_the_tank;
    public int fill_tank_status = 0;
    public float activity_distance;
    public int fill_tank_max = 10;
    public string trash_type;

    [Header("tank_clearing")]
    private GameObject inspector;
    public Object[] objects;
    public bool clearing_tank = false;
    public float time;
    public float trash_speed;

    [Header("add_money")]
    private GameObject money;


    [Header("animation")]
    public bool text_animate = false;
    public List<string> anim_good_text_list = new List<string>();
    public List<string> anim_bad_text_list = new List<string>();
    public float anim_speed;

    private incentives inc_script;
    // Start is called before the first frame update
    public void Start()
    {

        objects = Resources.LoadAll($"trash", typeof(GameObject));


        player = GameObject.FindGameObjectWithTag("Player");
        trash_empty = GameObject.FindGameObjectWithTag("trash_empty");

        if (GameObject.FindGameObjectWithTag("inspector") != null)
        {
            inspector = GameObject.FindGameObjectWithTag("inspector");
        }

        money = GameObject.FindGameObjectWithTag("money");


        anim_good_text_list.AddRange(new string[] { "�����", "�������", "�������!","��� �������!" });
        anim_bad_text_list.AddRange(new string[] { "�����", "������������", "�� ����!" });
        text.text = "";


        p_beh = player.GetComponent<Player_behaviour>();
        sts = GameObject.FindGameObjectWithTag("stretch_status_element").GetComponent<stretch_trash_status>();
        text.rectTransform.localScale = Vector3.zero;

       // inc_script = GameObject.FindGameObjectWithTag("incentives_interface").GetComponent<incentives>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y); // z-�������

        float player_distance = Vector2.Distance(player.transform.position, transform.position);

        //������, ����� ������� ������ �����
        if (trash_empty.transform.childCount > 0) {
            trash_in_the_hand = GameObject.FindGameObjectWithTag("trash_empty").transform.GetChild(0);
        }

        // ��������� ����������� ���� � ���� �� �� ��������, ��������� ������������ �� ��������� ���� ������, ������� � ���� ������ �����
        if (p_beh.can_run && player_distance < activity_distance && Input.GetKeyUp(KeyCode.F) && trash_in_the_hand != null && stats.tank_fill_status_max > fill_tank_status)
        {
            fill_tank_status++;
            trash_in_the_hand.transform.localPosition = new Vector3(1000, 1000, 1000);
            trash_in_the_hand.GetComponent<Collider2D>().enabled = false;
            object_inside.Add(trash_in_the_hand.gameObject);
            trash_in_the_hand.SetParent(null);
            sts.trash.Remove(trash_in_the_hand.gameObject);

            if (trash_in_the_hand.CompareTag(trash_type))
            {
                text.color = new Color32(101, 240, 105,255);
                text.text = anim_good_text_list[Random.Range(0, anim_good_text_list.Count)];
                text_animate = true;
            } else
            {
                text.color = new Color32(252, 45, 45 ,255);
                text.text = anim_bad_text_list[Random.Range(0, anim_bad_text_list.Count)];
                text_animate = true;
            }


        } else if (fill_tank_status >= fill_tank_max)
        {
            text.color = Color.white;
            text.text = "���������";
            text_animate = true;
        }

        //����� ������
        if (inspector != null)
        {
            float inspector_distance = Vector2.Distance(inspector.transform.position, transform.position);
            if (p_beh.can_run && inspector.GetComponent<Inspector>().on_close && player_distance <= 0.2f && inspector_distance <= 0.2f && !clearing_tank && Input.GetKeyUp(KeyCode.E))
            {
                StartCoroutine("hand_over_the_trash", time);
                clearing_tank = true;
            }
        }

        //�������� ������
        if (fill_tank_status < fill_tank_max) {
            if (text_animate && text.rectTransform.localScale.x < 0.97)
            {
                float scale = Mathf.Lerp(text.rectTransform.localScale.x, 1, Time.deltaTime * anim_speed);
                text.rectTransform.localScale = new Vector3(scale, scale, text.rectTransform.localScale.z);
            }
            else
            {
                float scale = Mathf.Lerp(text.rectTransform.localScale.x, 0, Time.deltaTime * anim_speed);
                text.rectTransform.localScale = new Vector3(scale, scale, text.rectTransform.localScale.z);
                text_animate = false;
            }
        } else
        {
            float scale = Mathf.Lerp(text.rectTransform.localScale.x, 1, Time.deltaTime * anim_speed);
            text.rectTransform.localScale = new Vector3(scale, scale, text.rectTransform.localScale.z);
        }
    }

    public IEnumerator hand_over_the_trash(float time)
    {
        while (fill_tank_status > 0)
        {
            rnd_object_in_the_tank = object_inside[Random.Range(0, object_inside.Count)];

            if (rnd_object_in_the_tank.CompareTag(trash_type))
            {
                moneyEx.inst(inspector.transform);

                //inc_script.hand_over_trash_count++;
            }

            rnd_object_in_the_tank.transform.position = transform.position;
            rnd_object_in_the_tank.gameObject.AddComponent<trash_hand_over>();
            object_inside.Remove(rnd_object_in_the_tank);
            fill_tank_status--;
            yield return new WaitForSeconds(time);
        }

        clearing_tank = false;
    }
}
