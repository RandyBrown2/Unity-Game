using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuzzerSound : MonoBehaviour
{
    public AudioSource buzzerNoise;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("x"))
        {
            Debug.Log("Working!");
            buzzerNoise.Play();
        }
    }
}
