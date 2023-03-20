using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryTransitions : MonoBehaviour
{
    public new Camera[] camera = new Camera[1];
    public GameObject[] LCategories = new GameObject[3];
    public GameObject timeObject;
    public float clicks = 0f;
    private RoundReplaceItems roundReplaceItems;
    private Vector3 distanceX = new Vector3(50, 0, 0);
    private bool slide = false;
    private bool FillTimer = false;
    private float timer = 0.0f;
    private float speed = 0.61f;
    private float expandBounds = 100f;
    private float scale = 1f;
    private float distance = 1.0f, distanceMultiplier = 0.749f;
    private Vector3 middleOfBoard = new Vector3(177.7f, -300f, -150.0f);
    private Vector3 originalPosition;
    private CircleTimer circleTimer;
    private InputTextToGameBoard inputTextToGameBoard;

    // Start is called before the first frame update
    void Start()
    {
        roundReplaceItems = GameObject.Find("PointSystem").GetComponent<RoundReplaceItems>();
        if (roundReplaceItems.section == 2f || roundReplaceItems.section == 4f)
        {
            camera[0].transform.localPosition = new Vector3(-1.660294f, -30.11948f, -150f);
            camera[0].orthographicSize = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (roundReplaceItems.section == 1) OnRoundOne();
        if (roundReplaceItems.section == 2) OnRoundTwo();
        if (roundReplaceItems.section == 3) OnRoundThree();
        if (roundReplaceItems.section == 4) OnRoundFour();
    }


    void OnRoundOne()
    {
        if (Input.GetKey("space"))
        {
            if (!slide)
            {
                clicks += 1f;
                Debug.Log(clicks);
                slide = true;
                Debug.Log("true");
                originalPosition = camera[0].transform.position;
                distance = distanceMultiplier * Vector3.Distance(originalPosition, middleOfBoard);
            }
        }
        if (slide && clicks <= 6f)
        {
            speed += 0.61f;
            timer += 1f;
            camera[0].transform.position = Vector3.MoveTowards(camera[0].transform.position, camera[0].transform.position + distanceX, (speed - 0.25f) * Time.fixedDeltaTime);
            if (timer >= 97f)
            {
                slide = false;
                timer = 0f;
                speed = 0.61f;
            }
        }
        if (slide && clicks >= 7f)
        {
            camera[0].transform.position = Vector3.MoveTowards(camera[0].transform.position, middleOfBoard, distance * Time.deltaTime);
            if (camera[0].orthographicSize < expandBounds)
            {
                camera[0].orthographicSize += scale;
                speed = 0.5f;
            }
        }
    }

    void OnRoundTwo()
    {
        if (Input.GetKey("space") && clicks <= 10)
        {
            slide = true;
            speed = 0.9f;
            clicks++;
        }
        if (clicks == 8 && LCategories[0].transform.position.x < 81.2f && slide)
        {
            speed += 1.5f;
            LCategories[0].transform.position = Vector3.MoveTowards(LCategories[0].transform.position, LCategories[0].transform.position + distanceX, speed * Time.fixedDeltaTime);
        }
        if (clicks == 9 && LCategories[1].transform.position.x < 81.2f && slide)
        {
            speed += 1.5f;
            LCategories[1].transform.position = Vector3.MoveTowards(LCategories[1].transform.position, LCategories[1].transform.position + distanceX, speed * Time.fixedDeltaTime);
        }
        if (clicks == 10 && LCategories[2].transform.position.x < 81.2f && slide)
        {
            speed += 1.5f;
            LCategories[2].transform.position = Vector3.MoveTowards(LCategories[2].transform.position, LCategories[2].transform.position + distanceX, speed * Time.fixedDeltaTime);
            Debug.Log("test2");
            if (LCategories[2].transform.position.x >= 81.2f)
            {
                slide = false;
                clicks++;
            }
        }
    }

    void OnRoundThree()
    {
        if (clicks == 11)
        {
            camera[0].transform.localPosition = new Vector3(-207f, 49.8f, -150f);
            camera[0].orthographicSize = 17;
            speed = 0.61f;
        }
        if ((Input.GetKey("space")))
        {
            if (!slide)
            {
                clicks += 1f;
                Debug.Log(clicks);
                slide = true;
                Debug.Log("true");
                originalPosition = camera[0].transform.position;
                distance = distanceMultiplier * Vector3.Distance(originalPosition, middleOfBoard);
            }
        }
        if (slide && clicks <= 17f)
        {
            speed += 0.61f;
            timer += 1f;
            camera[0].transform.position = Vector3.MoveTowards(camera[0].transform.position, camera[0].transform.position + distanceX, (speed - 0.25f) * Time.fixedDeltaTime);
            if (timer >= 97f)
            {
                slide = false;
                timer = 0f;
                speed = 0.61f;
            }
        }
        if (slide && clicks >= 18f)
        {
            camera[0].transform.position = Vector3.MoveTowards(camera[0].transform.position, middleOfBoard, distance * Time.deltaTime);
            if (camera[0].orthographicSize < expandBounds)
            {
                camera[0].orthographicSize += scale;
                speed = 0.5f;
            }
        }
    }

    void OnRoundFour()
    {
        if (clicks == 18)
        {
            timeObject.SetActive(true);
            camera[0].transform.localPosition = new Vector3(-1.660294f, -30.11948f, -150.73125f);
            camera[1].transform.localPosition = new Vector3(-1.660294f, -30.11948f, -82);
            speed = 0.4f;
            circleTimer = GameObject.Find("Timer").GetComponent<CircleTimer>();
            inputTextToGameBoard = GameObject.Find("StudentPollRound").GetComponent<InputTextToGameBoard>();
            clicks++;
        }
        if (clicks == 19 || clicks == 21)
        {
            if (Input.GetKey("space"))
            {
                //!circleTimer.timerActive && 
                Debug.Log("Timer");
                circleTimer.totaltime = 60f;
                circleTimer.timerActive = true;
                roundReplaceItems.questionsCount++;
                clicks++;
                Input.ResetInputAxes();
            }
        }
        if (clicks == 20)
        {
            if (Input.GetKey("space"))
            {
                FillTimer = true;
                circleTimer.timerActive = false;
                Input.ResetInputAxes();
            }
            if (FillTimer == true)
            {
                circleTimer.progressbar.fillClockwise = false;
                speed += 0.4f;
                circleTimer.progressbar.fillAmount = speed * Time.fixedDeltaTime;
                if (circleTimer.progressbar.fillAmount == 1f)
                {
                    clicks++;
                    circleTimer.progressbar.fillClockwise = true;
                    circleTimer.timerobj.text = "60";
                    FillTimer = false;
                    circleTimer.timerActive = false;
                }
            }
        }
        if (clicks == 22 && inputTextToGameBoard.num == 6 && circleTimer.totaltime <= 0f)
        {
            if (Input.GetKey("space"))
            {
                Destroy(GameObject.Find("Timer"));
                clicks++;
                camera[1].transform.localPosition = new Vector3(-1.660294f, -30.11948f, 4);
            }
        }
        if (clicks == 23 && inputTextToGameBoard.num == 16)
        {
            if (Input.GetKey("space"))
            {
                Destroy(GameObject.Find("2nd Board"));
                clicks++;
            }
        }
        if (clicks == 24 && inputTextToGameBoard.num == 21)
        {
            if (Input.GetKey("space"))
            {
                Destroy(GameObject.Find("3rd Board"));
                clicks++;
            }
        }
    }
}