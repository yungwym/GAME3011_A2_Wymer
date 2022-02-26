using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LockType
{
    NONE,
    EASY,
    MEDIUM,
    HARD
}

public class Lock : MonoBehaviour
{
    //Lock Member Variables 
    public LockType lockType;

    public Color pinColor;
    public Color activeAreaColor;

    public Color easyColor;
    public Color mediumColor;
    public Color hardColor;

    public int numOfTiers;
    public int maxNumOfTiers = 4;

    public int lockpickChances;


    public GameObject activeArea;
    public GameObject playerPin;

    public float playerPinRotationSpeed = 5.0f;

    public Transform pivotPoint;

    public List<GameObject> loops;
    public List<GameObject> activeAreas;
    public List<GameObject> playerPins;
    public List<GameObject> gamePins;

    private bool gameOver = false;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //InitialLockSetup();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateActiveAreaLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateActiveAreaRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PinPicked();
        }


        if (!gameOver)
        {
            playerPins[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), playerPinRotationSpeed * Time.deltaTime);
        }
       
    }

    public void RotateActiveAreaLeft()
    {
        if (!gameOver)
        {
            activeAreas[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), playerPinRotationSpeed * Time.deltaTime);
        }
    }

    public void RotateActiveAreaRight()
    {
        if (!gameOver)
        {
            activeAreas[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, -1), playerPinRotationSpeed * Time.deltaTime);
        }
    }

    public void SetGamePinRotation()
    {
        float randomRotation = Random.Range(-90, 180);

        gamePins[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), randomRotation);
    }




    public void PinPicked()
    {
        if (activeAreas[index].GetComponent<ActiveAreaController>().isCollidingWithGamePin &&
            playerPins[index].GetComponent<PlayerPinController>().isColldingWithGamePin)
        {
            Debug.Log("PinPicked");

            index += 1;

            if (index <= numOfTiers)
            {


                Debug.Log(index);


                loops[index].SetActive(true);
                activeAreas[index].SetActive(true);
                playerPins[index].SetActive(true);
                gamePins[index].SetActive(true);

                playerPins[index].GetComponent<SpriteRenderer>().color = pinColor;
                activeAreas[index].GetComponent<SpriteRenderer>().color = activeAreaColor;

                SetGamePinRotation();
            }

        }

        if (!activeAreas[index].GetComponent<ActiveAreaController>().isCollidingWithGamePin ||
             !playerPins[index].GetComponent<PlayerPinController>().isColldingWithGamePin)
        {
            Debug.Log("Missed Game Pin");

            lockpickChances -= 1;

            if (lockpickChances == 0)
            {
                Debug.Log("Game Over");
            }
        }


            if (index > numOfTiers)
            {
                Debug.Log("Lock Complete");
                gameOver = true;
            }



    }
    


    public void SetDifficultyToEasy()
    {
        lockType = LockType.EASY;
        numOfTiers = 1;
        lockpickChances = 5;
        pinColor = easyColor;
        activeAreaColor = easyColor;
        activeAreaColor.a = 0.5f;
    }

    public void SetDifficultyToMedium()
    {
        lockType = LockType.MEDIUM;
        numOfTiers = 2;
        lockpickChances = 4;
        pinColor = mediumColor;
        activeAreaColor = mediumColor;
        activeAreaColor.a = 0.5f;
    }

    public void SetDifficultyToHard()
    {
        lockType = LockType.HARD;
        numOfTiers = 3;
        lockpickChances = 3;
        pinColor = hardColor;
        activeAreaColor = hardColor;
        activeAreaColor.a = 0.5f;
    }

    public void SetupLock()
    {
        pinColor.a = 1.0f;
       
        for (int i = 0; i < 1; i++)
        {
            loops[i].SetActive(true);
            activeAreas[i].SetActive(true);
            playerPins[i].SetActive(true);
            gamePins[i].SetActive(true);

            playerPins[i].GetComponent<SpriteRenderer>().color = pinColor;
            activeAreas[i].GetComponent<SpriteRenderer>().color = activeAreaColor;

            SetGamePinRotation();
        }
    }


}
