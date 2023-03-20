using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputTextToFinalScore : MonoBehaviour
{
    public TextMeshPro[] displayAnswers = new TextMeshPro[2];
    public TextMeshProUGUI inputName;
    private string answer = "";
    public int num = 1;

    //On Mouse Click.
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && num <= 2)
        {
            answer = inputName.text;
            if (answer != " ")
            {
                displayAnswers[num - 1].text += answer;
                num++;
                Debug.Log(answer + "for box" + num);
            }
        }
        Input.ResetInputAxes();
    }
}
