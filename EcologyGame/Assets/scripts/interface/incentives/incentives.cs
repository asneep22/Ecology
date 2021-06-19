using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class incentives : MonoBehaviour
{
    private GameObject player;

    [Header("interface")]
    private bool is_create;
    public GameObject inc_interface_palace;
    public GameObject inc_interface_prefab;
    public GameObject inc_interface_obj;
    public int hand_over_trash_count;

    [Header("money_incentives")]
    public int min_trash_count_for_money;
    public int max_trash_count_for_money;

    public float min_money = 5;
    public float max_money = 30;



    public TextMeshPro text;
    public List<string> text_variables = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        text = inc_interface_prefab.GetComponentInChildren<TextMeshPro>();
        text.text = text_variables[Random.Range(0, text_variables.Count)];
        
        player.GetComponent<Player_behaviour>().can_run = false;
    }

    // Update is called once per frame
    void Update()
    {
        int random_int = Random.Range(min_trash_count_for_money, max_trash_count_for_money);

        if (hand_over_trash_count >= random_int)
        {

            if (!is_create)
            {
                is_create = true;

                inc_interface_obj = Instantiate(inc_interface_prefab, transform);
                inc_interface_obj.transform.localPosition = Vector3.zero;
                hand_over_trash_count = 0;
            }
        }

        if (is_create)
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                float additional_money = Random.Range(min_money, max_money);

                for (int i = 0; i < additional_money; i++)
                {
                    moneyEx.inst(player.transform);
                }

                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_behaviour>().can_run = true;
                Destroy(inc_interface_obj.gameObject);
            }
        }
    }
}
