using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineRedLightSwitcher
{
    public TrafficState_Red CurrentState { get; set; }

    public void Initialize(TrafficState_Red startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(TrafficState_Red newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
