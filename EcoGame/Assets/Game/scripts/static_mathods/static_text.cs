using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public static class static_text
{


    public static IEnumerator PrintTextMeshProByPrinMachine(string text, TextMeshPro TMpro, float delayTime)
    {

        char[] chars = text.ToCharArray();

        foreach (char word in chars)
        {
            TMpro.text += word;
            yield return new WaitForSeconds(delayTime);
        }

    }


}
