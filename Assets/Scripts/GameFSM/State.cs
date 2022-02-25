using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateId
{
    BeginState,
    GameState,
    EndState
}

public interface State
{
    StateId GetId();
    void Enter(GameController gameController);
    void Update(GameController gameController);
    void Exit(GameController gameController);
}
