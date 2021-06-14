using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inspector : MonoBehaviour
{
    private Animator anim;
    private GameObject player; // —оздаем переменную с классом "GameObject", у которого есть методы, с которыми нам нужно будет работать.

    public float activity_distance; // создаем переменную минимальной дистанции, при которой инспектор будет вставать.

    [Header("reviever")]
    public bool is_create;
    public bool on_close;
    public GameObject reviever_prefab;
    private GameObject reviever_obj;
    public Transform inst_point;
    public Transform stop_point;
    public Transform destr_point;
    public TextMeshPro inspector_text;
    public float rev_speed = 5;
    public float stop_time = 30;
    public float reviever_distance = 100;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // ”казываем на элемент сцены unity, которому дадим методы класса "GameObject". ¬ данном случае мы нашли элемент через тег, который уже висит на персонаже.
        inspector_text.text = "нажмите 'е', чтобы вызвать грузовик";
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(player.transform.position, transform.position); // —оздаем переменную текущей дистанции между игроком и инспектором

        if (distance < activity_distance) // » собственно сама анимаци€
        {
            anim.SetBool("Down", false);
            anim.SetBool("UP", true);

        } else
        {
            anim.SetBool("UP", false);
            anim.SetBool("Down", true);
        }

        //reviever

        if (distance < activity_distance && Input.GetKeyUp(KeyCode.E))
        {
            inspector_text.text = (is_create) ? "грузовик ещЄ не уехал" : "грузовик вызван";

            if (!is_create)
            {
                reviever_obj = Instantiate(reviever_prefab, inst_point);
                reviever_obj.AddComponent<reviever>();
                reviever_obj.GetComponent<reviever>().stop_point = stop_point;
                reviever_obj.GetComponent<reviever>().dest_point = destr_point;
                reviever_obj.GetComponent<reviever>().stop_time = stop_time;
                reviever_obj.GetComponent<reviever>().inspector_script = this;

                inspector_text.text = "грузовик вызван";

            }

            is_create = true;
        }

        // ѕроверка дистанции между грузовиком и инспектором
        if (reviever_obj != null)
        {
            reviever_distance = Vector2.Distance(reviever_obj.transform.position, transform.position);
        }
        on_close = (reviever_distance < 0.8f);

    }
    // “ак же в окне аниматора € убрал один булевых операнад - stay, и убрал услови€ на стрелочках где их не должно быть.
}
