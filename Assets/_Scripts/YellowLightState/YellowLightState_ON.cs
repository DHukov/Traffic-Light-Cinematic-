using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLightState_ON : TrafficState_Yellow
{
    public YellowLightState_ON(TrafficLightManager _traffic) : base(_traffic)      {    }
    public override void Enter()
    {
        for (int i = 0; i < traffic.YellowTextureLights.Length; i++)
            traffic.YellowTextureLights[i].GetComponent<MeshRenderer>().material = traffic.material_yellow;
        for (int i = 0; i <= traffic.YellowPointLight.Length - 1; i++)
            traffic.YellowPointLight[i].gameObject.SetActive(true);
        base.Enter();

    }
    public override void Exit()
    {
        for (int i = 0; i < traffic.YellowTextureLights.Length; i++)
            traffic.YellowTextureLights[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.YellowPointLight.Length - 1; i++)
            traffic.YellowPointLight[i].gameObject.SetActive(false);
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
