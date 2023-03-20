using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CircleTimer : MonoBehaviour
{
    public Image progressbar;
    public TMP_Text timerobj;
    public float totaltime = 60f;
    public bool timerActive = false;
    public AudioSource buzzer;

    void Start()
    {
        Debug.Log(buzzer);
    }

    void Update()
    {
        if(timerActive && totaltime > -0.1f)
        {
            totaltime -= Time.deltaTime;
            if (totaltime > 0)
            {
                timerobj.text = totaltime.ToString("0");
                progressbar.fillAmount -= 1.0f / 60 * Time.deltaTime;
            }
            else
            {
                buzzer.Play();
                timerobj.text = "0";
                timerActive = true;
            }
        }
    }
}


