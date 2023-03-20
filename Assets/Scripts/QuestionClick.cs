using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionClick : MonoBehaviour
{
    //Public is accessed outside the class.
    public int gamePoints;

    public string answerString;
    public string questionString;

    public GameObject panelQuestion;
    public GameObject image;

    public TMP_Text questionText;
    public TMP_Text categoryText;

    public bool imageForQuestion = false;

    private GameObject setScore;
    private AccumulatePoints accumulatePoints;
    private RoundReplaceItems roundReplaceItems;

    private float expandBounds = 190.0f, originalBounds = 31.0f;
    public static int counter = 0;
    private float distance, distanceMultiplier = 0.749f;
    private bool panelSelected = false, showAnswer = false, locked = false, timerActive = false, showQuestion = false;

    private Vector3 middleOfBoard = new Vector3(177.7f, -300f, -50.0f);
    private Vector3 scale = new Vector3(4.0f, 2.2139f, 0f);
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    { 
        questionText.text = "$" + gamePoints;
        accumulatePoints = GameObject.Find("PointSystem").GetComponent<AccumulatePoints>();
        roundReplaceItems = GameObject.Find("PointSystem").GetComponent<RoundReplaceItems>();
    }

    //FixedUpdate is called objects together once per every frame update
    void FixedUpdate()
    {
        panelTransition();
    }

    //This does something when the button is clicked on an object.
    void OnMouseDown()
    {
        if (!panelSelected && !locked)
        {
            Debug.Log(panelQuestion.name + " has been pressed.");
            panelSelected = true;
            originalPosition = panelQuestion.transform.position;
            questionText.text = categoryText.text;
            accumulatePoints.points = gamePoints;
            distance = distanceMultiplier * Vector3.Distance(originalPosition, middleOfBoard);
        } else if (!showQuestion) {
            getQuestion();
        } else if (!showAnswer) {
            getAnswer();
        } else {
            Debug.Log(panelQuestion.name + " has been reverted.");
            questionText.text = "";
            panelSelected = false;
            locked = true;
            questionText.fontSize = 50f;
        }
    }
    
    void panelTransition()
    {
        //If panel selected, move to screen.
        //If panel is selected again, go back.
        if (panelSelected)
        {
            panelQuestion.transform.position = Vector3.MoveTowards(panelQuestion.transform.position, middleOfBoard, distance * Time.deltaTime);
            if (panelQuestion.transform.localScale.y < expandBounds)
            {
                panelQuestion.transform.localScale += scale;
            }
        } else if(locked) {

            panelQuestion.transform.position = Vector3.MoveTowards(panelQuestion.transform.position, originalPosition, distance * Time.deltaTime);
            if (panelQuestion.transform.localScale.y > originalBounds)
            {
                panelQuestion.transform.localScale -= scale;
            }
        }
    }

    void getQuestion()
    {
        if(imageForQuestion)
        {
            image = GameObject.Find("C Column/" + panelQuestion.name + "/Question Image");
            Debug.Log("C Column/" + panelQuestion.name + "/Question Image");
            Debug.Log(image);
            image.SetActive(true);
        }
        questionText.text = questionString;
        questionText.fontSize = 37f;
        showQuestion = true;
        Debug.Log("Image Played");
        
    }
    void getAnswer()
    {
        if(imageForQuestion) 
        {
            image.SetActive(false);
        }
            showAnswer = true;
            questionText.text = answerString;
            accumulatePoints.canSetPoints = true;
            roundReplaceItems.questionsCount = counter++;
            Debug.Log(counter);
    }
}
