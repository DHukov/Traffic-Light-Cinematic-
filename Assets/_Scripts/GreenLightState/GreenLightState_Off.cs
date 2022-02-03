using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLightState_Off : TrafficState_Green
{
    public GreenLightState_Off(TrafficLightManager _traffic) : base(_traffic)    {    }
    public override void Enter()
    {
        OffGreenLight();
        base.Enter();
    }
    public override void Exit()
    {
        OffGreenLight();
        base.Exit();
    }

    private void OffGreenLight()
    {
        for (int i = 0; i <= traffic.GreenTextureLights_X.Length - 1; i++)
            traffic.GreenTextureLights_X[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenTextureLights_Z.Length - 1; i++)
            traffic.GreenTextureLights_Z[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenPointLight_Z.Length - 1; i++)
            traffic.GreenPointLight_Z[i].gameObject.SetActive(false);
        for (int i = 0; i <= traffic.GreenPointLight_X.Length - 1; i++)
            traffic.GreenPointLight_X[i].gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
    }
}
