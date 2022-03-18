using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineYellowLightSwitcher
{
    public TrafficState_Yellow CurrentState { get; set; }

    public void Initialize(TrafficState_Yellow startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(TrafficState_Yellow newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
