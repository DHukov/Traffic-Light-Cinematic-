using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLightState_Off : TrafficState_Yellow
{
    public YellowLightState_Off(TrafficLightManager _trafic) : base(_trafic)     {    }
    public override void Enter()
    {
        YellowTurnOff();
        base.Enter();
    }
    public override void Exit()
    {
        YellowTurnOff();
        base.Exit();
    }
    private void YellowTurnOff()
    {
        for (int i = 0; i < traffic.YellowTextureLights.Length - 1; i++)
            traffic.YellowTextureLights[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.YellowPointLight.Length - 1; i++)
            traffic.YellowPointLight[i].gameObject.SetActive(false);
    }


    public override void Update()
    {
        base.Update();
    }
}
