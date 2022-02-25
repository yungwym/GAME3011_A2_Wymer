using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : State
{
    public StateId GetId()
    {
        return StateId.BeginState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Begin State");

        gameController.startCanvas.enabled = true;
        gameController.selectCanvas.enabled = false;
        gameController.gameCanvas.enabled = false;
        gameController.endCanvas.enabled = false;

    }

    public void Update(GameController gameController)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameController.startCanvas.enabled = false;
            gameController.selectCanvas.enabled = true;
        }
    }

    public void Exit(GameController gameController)
    {

    }
}
