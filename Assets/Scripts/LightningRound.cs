using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRound : MonoBehaviour
{
    public GameObject[] categories = new GameObject[3];
    public bool[] isLocked = new bool[3];
    public bool[] isMove = new bool[3];
    private Vector3[] originalPosition = new Vector3[3];
    private Vector3 distanceX = new Vector3(50, 0, 0);
    private float speed = 8.0f, revertBoundary = 81.2f, increaseSpeed = 0.0f, decreaseSpeed = -0.0001f;
    private string objectName = "";
    private bool canRevert = false, FillTimer = false;
    private Ray ray;
    private RaycastHit rayHit;
    private CircleTimer circleTimer;
    private RoundReplaceItems roundReplaceItems;

    void Start()
    {
        circleTimer = GameObject.Find("Lightning Round").GetComponent<CircleTimer>();
        roundReplaceItems = GameObject.Find("PointSystem").GetComponent<RoundReplaceItems>();
        for (int i = 0; i < 3; i++)
        {
            originalPosition[i] = categories[i].transform.position;
            categories[i].transform.position -= new Vector3(160, 0, 0);
        }
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayHit))
            {
                objectName = rayHit.collider.gameObject.name;
                Debug.Log(rayHit.collider.gameObject.name);
            }
        }

        if ((Input.GetKey("space") && circleTimer.timerActive) || canRevert)
        {
            Debug.Log("Category Reverted");
            canRevert = true;
            revertCategories();
        }
        else
        {
            moveCategories();
        }

        if (Input.GetKey("space") && (isMove[0] || isMove[1] || isMove[2]) && !circleTimer.timerActive)
        {
            Debug.Log("Timer");
            circleTimer.totaltime = 60f;
            circleTimer.timerActive = true;
            roundReplaceItems.questionsCount++;
        }
        Input.ResetInputAxes();
        if (FillTimer == true)
        {
            circleTimer.progressbar.fillClockwise = false;
            increaseSpeed += 0.4f;
            circleTimer.progressbar.fillAmount = (increaseSpeed - decreaseSpeed) * Time.fixedDeltaTime;
            if (circleTimer.progressbar.fillAmount == 1f) 
            {
                circleTimer.progressbar.fillClockwise = true;
                circleTimer.timerobj.text = "60";
                FillTimer = false;
                circleTimer.timerActive = false;
            }
        }
    }

   


    void moveCategories()
    {

        if (objectName == "L Category 1" && !isLocked[0] && categories[1].transform.position.x > -70.0f)
        {
            speed += 2f;
            categories[1].transform.position = Vector3.MoveTowards(categories[1].transform.position, categories[1].transform.position - distanceX, speed * Time.fixedDeltaTime);
            categories[2].transform.position = Vector3.MoveTowards(categories[2].transform.position, categories[2].transform.position - distanceX, speed * Time.fixedDeltaTime);
            isMove[0] = true;
        }
        else if (objectName == "L Category 2" && !isLocked[1] && categories[0].transform.position.x > -70.0f)
        {
            speed += 2f;
            categories[0].transform.position = Vector3.MoveTowards(categories[0].transform.position, categories[0].transform.position - distanceX, speed * Time.fixedDeltaTime);
            categories[2].transform.position = Vector3.MoveTowards(categories[2].transform.position, categories[2].transform.position - distanceX, speed * Time.fixedDeltaTime);
            isMove[1] = true;
        }
        else if (objectName == "L Category 3" && !isLocked[2] && categories[0].transform.position.x > -70.0f)
        {
            speed += 2f;
            categories[0].transform.position = Vector3.MoveTowards(categories[0].transform.position, categories[0].transform.position - distanceX, speed * Time.fixedDeltaTime);
            categories[1].transform.position = Vector3.MoveTowards(categories[1].transform.position, categories[1].transform.position - distanceX, speed * Time.fixedDeltaTime);
            isMove[2] = true;
        }
    }
    
    void revertCategories()
    {
        if (isMove[0] && categories[1].transform.position.x < 81.2f) 
        {
            speed -= 1.99f;
            categories[1].transform.position = Vector3.MoveTowards(categories[1].transform.position, originalPosition[1], speed * Time.fixedDeltaTime);
            categories[2].transform.position = Vector3.MoveTowards(categories[2].transform.position, originalPosition[2], speed * Time.fixedDeltaTime);
            Debug.Log("test");
            FillTimer = true;
            isLocked[0] = true;
        } else if (isMove[1] && categories[0].transform.position.x < 81.2f) {
            speed -= 1.99f;
            categories[0].transform.position = Vector3.MoveTowards(categories[0].transform.position, originalPosition[0], speed * Time.fixedDeltaTime);
            categories[2].transform.position = Vector3.MoveTowards(categories[2].transform.position, originalPosition[2], speed * Time.fixedDeltaTime);
            FillTimer = true;
            isLocked[1] = true;
        } else if (isMove[2] && categories[0].transform.position.x < 81.2f) {
            speed -= 1.99f;
            categories[0].transform.position = Vector3.MoveTowards(categories[0].transform.position, originalPosition[0], speed * Time.fixedDeltaTime);
            categories[1].transform.position = Vector3.MoveTowards(categories[1].transform.position, originalPosition[1], speed * Time.fixedDeltaTime);
            FillTimer = true;
            isLocked[2] = true;
        } else {
            canRevert = false;
        }
    }
}
