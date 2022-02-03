using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineCrasswalkLightSwitcher
{
    public TrafficState_CrossWalk CurrentState { get; set; }

    public void Initialize(TrafficState_CrossWalk startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(TrafficState_CrossWalk newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
