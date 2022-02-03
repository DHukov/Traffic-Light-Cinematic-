using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineGreenArrowSwitcher : MonoBehaviour
{
    public TrafficState_GreenArrow CurrentState { get; set; }

    public void Initialize(TrafficState_GreenArrow startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(TrafficState_GreenArrow newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
