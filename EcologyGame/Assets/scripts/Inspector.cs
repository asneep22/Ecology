using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector : MonoBehaviour
{
    private Animator anim;
    private GameObject player; // Создаем переменную с классом "GameObject", у которого есть методы, с которыми нам нужно будет работать.

    public float activity_distance; // создаем переменную минимальной дистанции, при которой инспектор будет вставать.

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // Указываем на элемент сцены unity, которому дадим методы класса "GameObject". В данном случае мы нашли элемент через тег, который уже висит на персонаже.
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position); // Создаем переменную текущей дистанции между игроком и инспектором

        if (distance < activity_distance) // И собственно сама анимация
        {
            anim.SetBool("Down", false);
            anim.SetBool("UP", true);

        } else
        {
            anim.SetBool("UP", false);
            anim.SetBool("Down", true);
        }
    }

    // Так же в окне аниматора я убрал один булевых операнад - stay, и убрал условия на стрелочках где их не должно быть.
}
