using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lvl1_hints : MonoBehaviour
{
    private GameObject player;
    private Player_behaviour pl_beh;

    public TextMeshPro hint_text;
    public TextMeshPro continue_text;

    public int hint_index;

    private float max_size = 1f;

    public float pulse_animation_speed;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pl_beh = player.GetComponent<Player_behaviour>();

        gameObject.SetActive(true);
    }

    void Start()
    {
        continue_text.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space)) {
            hint_index++;
        }

        switch (hint_index)
        {
            case 1:
                hint_text.text = "здесь грязновато, давай приберемся";
                break;
            case 2:
                hint_text.text = "подойди к пустой пластиковой бутылке и подбери ее (клавиша e)";
                break;
            case 3:
                hint_text.text = "отлично, теперь отправляйся к желтому баку и скинь бутылку (клавиша f)";
                gameObject.SetActive(false);
                break;
            case 4:
                hint_text.text = "отлично, теперь отправляйся к желтому баку и скинь бутылку (клавиша f)";
                break;
            case 5:
                hint_text.text = "а теперь собери все бутылки";
                gameObject.SetActive(false);
                break;
            case 6:
                hint_text.text = "а теперь собери все бутылки";
                break;
            case 7:
                hint_text.text = "молодец. отправяйся на улицу, нужно отправить мусор на переработку";
                gameObject.SetActive(false);
                break;
            case 8:
                hint_text.text = "молодец. отправяйся на улицу, нужно отправить мусор на переработку";
                break;
            case 9:
                hint_text.text = "подойди к баку и начни его толкать. докати его к инспектору, который сидит около твоего участка";
                gameObject.SetActive(false);
                break;
            case 10:
                hint_text.text = "подойди к баку и начни его толкать. докати его к инспектору, который сидит около твоего участка";
                break;
            case 11:
                hint_text.text = "поговори с инспектором(клавиша 'е') и сдай мусор";
                gameObject.SetActive(false);
                break;
            case 12:
                hint_text.text = "поговори с инспектором(клавиша 'е') и сдай мусор";
                break;
            case 13:
                hint_text.text = "инспектор дал тебе пару жетонов переработки, которые ты можешь обменять у экоактивиста на улучшения (клавиша 'е'), который сидит в твоей беседке";
                gameObject.SetActive(false);
                break;
            case 14:
                hint_text.text = "инспектор дал тебе пару жетонов переработки, которые ты можешь обменять у экоактивиста на улучшения (клавиша 'е'), который сидит в твоей беседке";
                break;
            case 15:
                hint_text.text = "лучше не оставлять бак на дороге. Отвези бак обратно.";
                break;
            case 16:
                gameObject.SetActive(false);
                break;
            case 17:
                hint_text.text = "у тебя на газоне лежат разные типы мусора. его нужно сортировать. пластик в желтый конейнер, стекло в зеленый";
                break;
            case 18:
                hint_text.text = "в верхнем правом углу ты можешь узнать, какой тип мусора ты держишь";
                GameObject obj_in_the_hand_inteface = GameObject.FindGameObjectWithTag("object_in_the_hand_interface");
                obj_in_the_hand_inteface.transform.localPosition = new Vector3(obj_in_the_hand_inteface.transform.localPosition.x, obj_in_the_hand_inteface.transform.localPosition.y, 11000);
                break;
            case 19:
                hint_text.text = "лучше не класть мусор в баки непредназначенные для него, кончено, если вы не хотите получать меньше жетонов";
                break;
            case 20:
                hint_text.text = "в верхнем левом углу ты можешь увидеть насколько заполнен статус загрязнения твоего участка, лучше не допускать, чтобы он поднялся до самого конца";
                GameObject obj_in_the_hand_inteface1 = GameObject.FindGameObjectWithTag("object_in_the_hand_interface");
                GameObject poll_status = GameObject.FindGameObjectWithTag("pollution_status_interface");
                poll_status.transform.localPosition = new Vector3(poll_status.transform.localPosition.x, poll_status.transform.localPosition.y, 5);
                obj_in_the_hand_inteface1.transform.localPosition = new Vector3(obj_in_the_hand_inteface1.transform.localPosition.x, obj_in_the_hand_inteface1.transform.localPosition.y, 21000);
                break;
            case 21:
                hint_text.text = "пора убраться на участке";
                GameObject poll_statu1 = GameObject.FindGameObjectWithTag("pollution_status_interface");
                poll_statu1.transform.localPosition = new Vector3(poll_statu1.transform.localPosition.x, poll_statu1.transform.localPosition.y, 5);
                break;
            case 22:
                hint_text.text = "Отлично, теперь отправляй мусор на переработку";
                gameObject.SetActive(false);
                break;
            case 23:
                hint_text.text = "Отлично, теперь отправляй мусор на переработку";
                break;
            case 24:
                hint_text.text = "Ух ты, кажется у тебя появились соседи, надеюсь ты с ними подружишься";
                gameObject.SetActive(false);
                break;
            case 25:
                hint_text.text = "Ух ты, кажется у тебя появились соседи, надеюсь ты с ними подружишься";
                break;
            case 26:
                gameObject.SetActive(false);
                break;
            default:
                break;
        }

        Vector3 current_size = continue_text.transform.localScale;
        continue_text.transform.localScale = new Vector3(Mathf.Lerp(current_size.x, max_size, Time.deltaTime * pulse_animation_speed), Mathf.Lerp(current_size.y, max_size, Time.deltaTime * pulse_animation_speed), 0);
    }

    private void OnEnable()
    {
        pl_beh.can_run = false;
        StartCoroutine("anim_reverse");
    }


    private void OnDisable()
    {
        pl_beh.can_run = true;
        StopCoroutine("anim_reverse");
    }

    IEnumerator anim_reverse()
    {
        max_size = (max_size == 1) ? 0.9f : 1f;

        yield return new WaitForSeconds(2.5f);

        StartCoroutine("anim_reverse");
    }
}
