using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrafficState_GreenArrow
{
    protected TrafficLightManager traffic;
    protected TrafficState_GreenArrow(TrafficLightManager _traffic)
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
