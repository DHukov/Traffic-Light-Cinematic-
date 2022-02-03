using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrafficState_CrossWalk
{
    protected TrafficLightManager traffic;
    protected TrafficState_CrossWalk(TrafficLightManager _traffic)
    {
        traffic = _traffic;
    }
    public virtual void Enter()
    {
    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {

    }
}
