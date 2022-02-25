using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{
    public StateId GetId()
    {
        return StateId.EndState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered End State");

    }

    public void Update(GameController gameController)
    {

    }

    public void Exit(GameController gameController)
    {

    }
}
