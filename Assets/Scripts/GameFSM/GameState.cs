using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    public StateId GetId()
    {
        return StateId.GameState;
    }

    public void Enter(GameController gameController)
    {
        Debug.Log("Entered Game State");

    }

    public void Update(GameController gameController)
    {

    }

    public void Exit(GameController gameController)
    {

    }
}
