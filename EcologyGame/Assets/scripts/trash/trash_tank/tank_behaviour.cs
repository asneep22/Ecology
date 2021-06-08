using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class tank_behaviour : MonoBehaviour
{
    private GameObject player;

    public TextMeshPro text;


    private GameObject trash_empty;
    private Transform trash_in_the_hand;

    private stretch_trash_status sts;


    [Header("tank_status")]
    public List<GameObject> object_inside = new List<GameObject>();
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
    private List<GameObject> money_array = new List<GameObject>();


    [Header("animation")]
    public bool text_animate = false;
    public List<string> anim_good_text_list = new List<string>();
    public List<string> anim_bad_text_list = new List<string>();
    public float anim_speed;

    public bool penalty;
    // Start is called before the first frame update
    void Start()
    {
        objects = Resources.LoadAll($"trash", typeof(GameObject));


        player = GameObject.FindGameObjectWithTag("Player");
        trash_empty = GameObject.FindGameObjectWithTag("trash_empty");
        inspector = GameObject.FindGameObjectWithTag("inspector");

        money = GameObject.FindGameObjectWithTag("money");


        anim_good_text_list.AddRange(new string[] { "круто", "отлично", "молодец!","так держать!" });
        anim_bad_text_list.AddRange(new string[] { "плохо", "внимательней", "не сюда!" });
        text.text = "";


        sts = GameObject.FindGameObjectWithTag("stretch_status_element").GetComponent<stretch_trash_status>();
        text.rectTransform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y); // z-позияци

        float player_distance = Vector2.Distance(player.transform.position, transform.position);

        //Узнаем, какой предметдержит игрок
        if (trash_empty.transform.childCount > 0) {
            trash_in_the_hand = GameObject.FindGameObjectWithTag("trash_empty").transform.GetChild(0);
        }

        // Проверяем вместимость бака и если он не заполнен, проверяем соответсвует ли контейнер типу мусора, который в него кладет игрок
        if (player_distance < activity_distance && Input.GetKeyUp(KeyCode.F) && trash_in_the_hand != null && fill_tank_max > fill_tank_status)
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
            text.text = "заполнено";
            text_animate = true;
        }

        //Сдача мусора
        float inspector_distance = Vector2.Distance(inspector.transform.position, transform.position);
        if (player_distance <= 0.2f && inspector_distance <= 0.2f && !clearing_tank && Input.GetKeyUp(KeyCode.E))
        {
            StartCoroutine("hand_over_the_trash", time);
            StartCoroutine("money_inst", time);
            clearing_tank = true;
        }

        //Анимация текста
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

    IEnumerator hand_over_the_trash(float time)
    {
        while (fill_tank_status > 0)
        {
            GameObject rnd_object = object_inside[Random.Range(0, object_inside.Count)];
            rnd_object.transform.position = transform.position;
            rnd_object.gameObject.AddComponent<trash_hand_over>();
            object_inside.Remove(rnd_object);
            fill_tank_status--;

            GameObject money_to_array = Instantiate(money);
            money_to_array.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            money_to_array.transform.localPosition = inspector.transform.localPosition;
            money_array.Add(money_to_array);
            money_to_array.AddComponent<money_script>();
            yield return new WaitForSeconds(time);
        }

        clearing_tank = false;
    }

    IEnumerator money_inst(float time)
    {
        while (fill_tank_status > 0)
        {
            GameObject money_to_array = Instantiate(money);
            money_to_array.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            money_to_array.transform.localPosition = inspector.transform.localPosition;
            money_array.Add(money_to_array);
            money_to_array.AddComponent<money_script>();
            yield return new WaitForSeconds(time / 2);
        }

        clearing_tank = false;
    }
}
