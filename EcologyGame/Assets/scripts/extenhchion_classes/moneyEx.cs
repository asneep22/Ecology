using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyEx : MonoBehaviour
{
    public static void inst(Transform start_position)
    {
        GameObject money = GameObject.FindGameObjectWithTag("money");
        GameObject money_to_array = Instantiate(money);
        money_to_array.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        money_to_array.transform.localPosition = start_position.transform.localPosition;
        money_to_array.AddComponent<money_script>();
        money_to_array.GetComponent<money_script>().target = start_position.gameObject;
    }
}
