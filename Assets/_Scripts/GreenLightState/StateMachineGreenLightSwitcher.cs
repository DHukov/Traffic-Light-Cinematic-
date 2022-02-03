using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineGreenLightSwitcher : MonoBehaviour
{
    public TrafficState_Green CurrentState { get; set; }

    public void Initialize(TrafficState_Green startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(TrafficState_Green newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
