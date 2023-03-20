using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MutlipleDisplays : MonoBehaviour
{
    public Camera[] myCams = new Camera[2];
    void Start()
    {
        //Get Main Camera
        myCams[0] = GameObject.Find("Editor Camera").GetComponent<Camera>();

        //Find All other Cameras
        myCams[1] = GameObject.Find("Main Camera").GetComponent<Camera>();

        //Call function when new display is connected
        Display.onDisplaysUpdated += OnDisplaysUpdated;

        //Map each Camera to a Display
        mapCameraToDisplay();
    }

    void mapCameraToDisplay()
    {
        //Loop over Connected Displays
        for (int i = 0; i < Display.displays.Length; i++)
        {
            myCams[i].targetDisplay = i; //Set the Display in which to render the camera to
            Display.displays[i].Activate(); //Enable the display
        }
    }

    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }
}
