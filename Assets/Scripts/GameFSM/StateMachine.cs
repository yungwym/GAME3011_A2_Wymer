using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] states;
    public GameController gameController;
    public StateId currentState;

    public StateMachine(GameController gameController)
    {
        this.gameController = gameController;
        int numStates = System.Enum.GetNames(typeof(StateId)).Length;

        states = new State[numStates];
    }

    public void RegisterState(State state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }

    public State GetState(StateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(gameController);
    }

    public void ChangeState(StateId newGameState)
    {
        GetState(currentState)?.Exit(gameController);
        currentState = newGameState;
        GetState(currentState)?.Enter(gameController);
    }
}
