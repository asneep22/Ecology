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

    [HideInInspector]
    public int hint_index = 1;

    private float max_size = 1f;

    private bool animation_reverse = false;
    public float pulse_animation_speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pl_beh = player.GetComponent<Player_behaviour>();

        continue_text.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        pl_beh.can_run = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space)) {
            hint_index++;
        } else if (player.transform.GetChild(0) != null)
        {

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
                gameObject.SetActive(false);
                break;
            case 4:
                hint_text.text = "отлично, теперь отправляйся к желтому баку и скинь бутылку (клавиша f)";
                break;
            case 5:
                gameObject.SetActive(false);
                break;
            case 6:
                hint_text.text = "а теперь собери все бутылки";
                break;
            case 7:
                gameObject.SetActive(false);
                break;
            case 8:
                hint_text.text = "молодец. отправяйся на улицу, нужно отправить мусор на переработку";
                break;


            default:
                break;
        }

        Vector3 current_size = continue_text.transform.localScale;
        continue_text.transform.localScale = new Vector3(Mathf.Lerp(current_size.x, max_size, Time.deltaTime * pulse_animation_speed), Mathf.Lerp(current_size.y, max_size, Time.deltaTime * pulse_animation_speed), 0);
    }

    private void OnEnable()
    {
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
