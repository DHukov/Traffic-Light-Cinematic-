using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrafficState_Red
{
    protected TrafficLightManager traffic;
    protected TrafficState_Red(TrafficLightManager _trafic)
    {
        traffic = _trafic;
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
