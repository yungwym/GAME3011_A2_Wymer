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
    public GameObject endCanvas;

    public GameObject lockObject;
   
    private Lock lockController;

    private bool gameReady = false;

    private void Start()
    {
        Debug.Log("GameController Start");

        
        lockController = lockObject.GetComponent<Lock>();

        ShowDifficultyUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && gameReady)
        {
            Debug.Log("Game Started");
            StartGame();
        }
    }

    void ShowDifficultyUI()
    {
        selectCanvas.SetActive(true);
        startCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        endCanvas.SetActive(false);
        lockObject.SetActive(false);
    }

   void ShowStartUI()
    {
        selectCanvas.SetActive(false);
        startCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        endCanvas.SetActive(false);

        gameReady = true;
    }

    void StartGame()
    {
        selectCanvas.SetActive(false);
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        endCanvas.SetActive(false);
        lockObject.SetActive(true);

        lockController.SetupLock();
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



}
