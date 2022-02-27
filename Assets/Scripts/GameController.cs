using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    //Ui Variables 
    public GameObject selectCanvas;
    public GameObject startCanvas;
    public GameObject gameCanvas;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI lockPickAttemptsText;

    public TextMeshProUGUI timeNumText;


    public GameObject lockObject;

    public GameObject lockParentObject;
   
    private Lock lockController;

    private bool gameReady = false;
    private bool gameInProgress;


    private void Start()
    {
        Debug.Log("GameController Start");

        gameInProgress = false;
        
        lockController = lockObject.GetComponent<Lock>();

        ShowDifficultyUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (lockController.gameWin)
        {
            ShowWinUI();
        }
        else if (lockController.gameLose)
        {
            ShowLoseUI();
        }

        if (Input.GetKeyDown(KeyCode.S) && gameReady && !gameInProgress)
        {
            Debug.Log("Game Started");
            gameInProgress = true;
            StartGame();
        }

        SetDifficultyAndAttemptsText();

        int time = (int)lockController.timeRemaining;
        timeNumText.text = time.ToString();
    }

    void ShowDifficultyUI()
    {
        selectCanvas.SetActive(true);
        startCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        lockObject.SetActive(false);
    }

   void ShowStartUI()
    {
        selectCanvas.SetActive(false);
        startCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        gameReady = true;

        SetDifficultyAndAttemptsText();
    }

    void StartGame()
    {
        selectCanvas.SetActive(false);
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        lockObject.SetActive(true);

        lockController.SetupLock();
    }

    void ShowWinUI()
    {
        selectCanvas.SetActive(false);
        startCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        lockObject.SetActive(false);

        lockParentObject.SetActive(false);

    }

    void ShowLoseUI()
    {
        selectCanvas.SetActive(false);
        startCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(true);
        lockObject.SetActive(false);

        lockParentObject.SetActive(false);
    }



    public void OnEasyClicked()
    {
        Debug.Log("Lock Set to Easy");
        lockController.SetDifficultyToEasy();
        ShowStartUI();
    }

    public void OnMediumClicked()
    {
        Debug.Log("Lock Set to Medium");
        lockController.SetDifficultyToMedium();
        ShowStartUI();
    }

    public void OnHardClicked()
    {
        Debug.Log("Lock Set to Hard");
        lockController.SetDifficultyToHard();
        ShowStartUI();
    }


    public void SetDifficultyAndAttemptsText()
    {
        switch (lockController.GetLockDifficulty())
        {
            case LockType.NONE:
                difficultyText.text = "Difficulty: None";
                break;
            case LockType.EASY:
                difficultyText.text = "Difficulty: Easy";
                break;
            case LockType.MEDIUM:
                difficultyText.text = "Difficulty: Medium";
                break;
            case LockType.HARD:
                difficultyText.text = "Difficulty: Hard";
                break;
            default:
                break;
        }
        lockPickAttemptsText.text = lockController.GetRemainingAttempts().ToString();
    }

}
