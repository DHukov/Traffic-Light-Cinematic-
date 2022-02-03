using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightState_X : TrafficState_Red
{
    public RedLightState_X(TrafficLightManager _traffic) : base(_traffic)    {   }
    public override void Enter()
    {
        for(int i = 0; i <= traffic.RedTextureLights_X.Length-1; i++)
            traffic.RedTextureLights_X[i].GetComponent<MeshRenderer>().material = traffic.material_red;
        for (int i = 0; i <= traffic.RedPointLight_X.Length - 1; i++)
            traffic.RedPointLight_X[i].gameObject.SetActive(true);
        base.Enter();
    }
    public override void Exit()
    {
        for (int i = 0; i <= traffic.RedTextureLights_X.Length-1; i++)
            traffic.RedTextureLights_X[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.RedPointLight_X.Length - 1; i++)
            traffic.RedPointLight_X[i].gameObject.SetActive(false);
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
