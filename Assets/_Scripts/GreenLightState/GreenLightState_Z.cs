using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLightState_Z : TrafficState_Green
{
    public GreenLightState_Z(TrafficLightManager _trafic) : base(_trafic)    {    }
    public override void Enter()
    {
        for (int i = 0; i <= traffic.GreenTextureLights_Z.Length-1; i++)
            traffic.GreenTextureLights_Z[i].GetComponent<MeshRenderer>().material = traffic.material_green;
        for (int i = 0; i <= traffic.GreenPointLight_Z.Length - 1; i++)
            traffic.GreenPointLight_Z[i].gameObject.SetActive(true);
        base.Enter();
    }
    public override void Exit()
    {
        for (int i = 0; i <= traffic.GreenTextureLights_Z.Length-1; i++)
            traffic.GreenTextureLights_Z[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenPointLight_Z.Length - 1; i++)
            traffic.GreenPointLight_Z[i].gameObject.SetActive(false);
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
