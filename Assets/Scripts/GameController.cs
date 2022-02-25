using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{

   


    //State Machine Variables 
    public StateMachine stateMachine;
    public StateId initialState;

    //Ui Variables 
    public Canvas startCanvas;
    public Canvas selectCanvas;
    public Canvas gameCanvas;
    public Canvas endCanvas;

    private void Start()
    {
        Debug.Log("GameController Start");

        //State Machine Setup
        stateMachine = new StateMachine(this);
        stateMachine.RegisterState(new BeginState());
        stateMachine.RegisterState(new GameState());
        stateMachine.RegisterState(new EndState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void OnEasyClicked()
    {
        
    }

    public void OnMediumClicked()
    {
       
    }

    public void OnHardClicked()
    {
        
    }



}
