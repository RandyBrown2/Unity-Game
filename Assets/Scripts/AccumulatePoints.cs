using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulatePoints : MonoBehaviour
{
    public int points = 0;
    public bool canSetPoints = false;
    private int Team1;
    private int Team2;

    // Update is called once per frame
    void Update()
    {
        addPoints();
    }

    void addPoints()
    {
          if (Input.GetKey("a") && canSetPoints)
          {
                Team1 += points; //Get Points from script.
                Debug.Log("Team 1 Points: " + Team1);
                canSetPoints = false;
          }
          else if (Input.GetKey("d") && canSetPoints)
          {
                Team2 += points; //Get Points from script.
                Debug.Log("Team 2 Points: " + Team2);
                canSetPoints = false;
          }
    }
}
