using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundReplaceItems : MonoBehaviour
{
    public int questionsCount = 0;
    public int section = 1;
    public GameObject[] Board = new GameObject[4];

    private int roundNumber = 1;
    private QuestionClick questionClick;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("z"))
        {
            switch (questionsCount)
            {
                case 29:
                    Board[0].SetActive(false);
                    Board[1].SetActive(true);
                    section++; roundNumber++; questionsCount++;
                    break;
                case 32:
                    Board[1].SetActive(false);
                    Board[2].SetActive(true);
                    section++; roundNumber++; questionsCount++;
                    break;
                case 59:
                    Board[2].SetActive(false);
                    Board[3].SetActive(true);
                    section++; roundNumber++; questionsCount++;
                    break;
                case 62:
                    Board[2].SetActive(false);
                    Board[3].SetActive(true);
                    roundNumber++; questionsCount++;
                    break;
                case 65:
                    Board[4].SetActive(true);
                    roundNumber++; questionsCount++;
                    break;
                default:
                    Debug.Log("Default Called");
                    break;
            }
        }
    }
}
