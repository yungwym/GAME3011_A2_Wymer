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
    public float activeAreaRotationSpeed = 5.0f;

    public float gamePinRotationSpeed = 5.0f;

    public float timeRemaining;

    public Transform pivotPoint;

    public List<GameObject> loops;
    public List<GameObject> activeAreas;
    public List<GameObject> playerPins;
    public List<GameObject> gamePins;

    private bool gameOver = false;
    public bool gameWin = false;
    public bool gameLose = false;

    public AudioManager audioManager;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //InitialLockSetup();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(FailedLockPick());
        }

       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateActiveAreaLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateActiveAreaRight();
        }

        if (Input.GetKeyDown(KeyCode.Space) && lockpickChances > 0)
        {
            PinPicked();
        }


        if (!gameOver && index <= numOfTiers)
        {
            playerPins[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), playerPinRotationSpeed * Time.deltaTime);
            gamePins[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), gamePinRotationSpeed * Time.deltaTime);
        }
       
    }

    public void RotateActiveAreaLeft()
    {
        if (!gameOver && index <= numOfTiers)
        {
            activeAreas[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), activeAreaRotationSpeed * Time.deltaTime);
        }
    }

    public void RotateActiveAreaRight()
    {
        if (!gameOver && index <= numOfTiers)
        {
            activeAreas[index].transform.RotateAround(pivotPoint.position, new Vector3(0, 0, -1), activeAreaRotationSpeed * Time.deltaTime);
        }
    }

    public void SetGamePinRotation()
    {
        int rand = Random.Range(0, 2);

        switch (rand)
        {
            case 0:
                Debug.Log("0");

                playerPinRotationSpeed = -200.0f;
                gamePinRotationSpeed = 100.0f;

                break;
            case 1:

                Debug.Log("1");

                playerPinRotationSpeed = 200.0f;
                gamePinRotationSpeed = -100.0f;

                break;

            default:
                break;
        }
    }


    public void PinPicked()
    {
        if (activeAreas[index].GetComponent<ActiveAreaController>().isCollidingWithGamePin &&
            activeAreas[index].GetComponent<ActiveAreaController>().isCollidingWithPlayerPin &&
            playerPins[index].GetComponent<PlayerPinController>().isColldingWithActiveArea &&
            playerPins[index].GetComponent<PlayerPinController>().isColldingWithGamePin)
        {
            Debug.Log("PinPicked");

            index += 1;

            if (index <= numOfTiers)
            {
                audioManager.Play("Select");

                Debug.Log(index);

                loops[index].SetActive(true);
                activeAreas[index].SetActive(true);
                playerPins[index].SetActive(true);
                gamePins[index].SetActive(true);

                playerPins[index].GetComponent<SpriteRenderer>().color = pinColor;
                activeAreas[index].GetComponent<SpriteRenderer>().color = activeAreaColor;

                SetGamePinRotation();
            }
            else if (index > numOfTiers)
            {
                audioManager.Play("Select");

                StartCoroutine(SuccessfulLockPick());
            }
        }
        else if (!activeAreas[index].GetComponent<ActiveAreaController>().isCollidingWithGamePin ||
             !playerPins[index].GetComponent<PlayerPinController>().isColldingWithGamePin)
        {
            Debug.Log("Missed Game Pin");

            lockpickChances -= 1;

            audioManager.Play("Error");

            if (lockpickChances == 0)
            {
                StartCoroutine(FailedLockPick());
            }
        }
    }

    IEnumerator SuccessfulLockPick()
    {  
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Lock Complete");

        for (int i = 0; i <= numOfTiers; i++)
        {
            loops[i].SetActive(false);
            activeAreas[i].SetActive(false);
            playerPins[i].SetActive(false);
            gamePins[i].SetActive(false);
        }

        gameOver = true;
        gameWin = true;

    }

    IEnumerator FailedLockPick()
    {
        yield return new WaitForSeconds(1.0f);

        Debug.Log("Game Over");

        for (int i = 0; i < numOfTiers; i++)
        {
            loops[i].SetActive(false);
            activeAreas[i].SetActive(false);
            playerPins[i].SetActive(false);
            gamePins[i].SetActive(false);
        }

        gameLose = true;

    }
    
    public void SetDifficultyToEasy()
    {
        lockType = LockType.EASY;
        numOfTiers = 1;
        lockpickChances = 5;
        timeRemaining = 30.0f;
        pinColor = easyColor;
        activeAreaColor = easyColor;
        activeAreaColor.a = 0.5f;
    }

    public void SetDifficultyToMedium()
    {
        lockType = LockType.MEDIUM;
        numOfTiers = 2;
        lockpickChances = 4;
        timeRemaining = 20.0f;
        pinColor = mediumColor;
        activeAreaColor = mediumColor;
        activeAreaColor.a = 0.5f;
    }

    public void SetDifficultyToHard()
    {
        lockType = LockType.HARD;
        numOfTiers = 3;
        lockpickChances = 3;
        timeRemaining = 15.0f;
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

    public LockType GetLockDifficulty()
    {
        return lockType;
    }

    public int GetRemainingAttempts()
    {
        return lockpickChances;
    }
}
