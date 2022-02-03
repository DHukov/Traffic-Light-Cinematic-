using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLightState_X : TrafficState_Green
{
    public GreenLightState_X(TrafficLightManager _trafic) : base(_trafic)    {    }
    public override void Enter()
    {
        for (int i = 0; i <= traffic.GreenTextureLights_X.Length-1; i++)
            traffic.GreenTextureLights_X[i].GetComponent<MeshRenderer>().material = traffic.material_green;
        for (int i = 0; i <= traffic.GreenPointLight_X.Length - 1; i++)
            traffic.GreenPointLight_X[i].gameObject.SetActive(true);
        base.Enter();
    }
    public override void Exit()
    {
        for (int i = 0; i <= traffic.GreenTextureLights_X.Length-1; i++)
            traffic.GreenTextureLights_X[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenPointLight_X.Length - 1; i++)
            traffic.GreenPointLight_X[i].gameObject.SetActive(false);
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
