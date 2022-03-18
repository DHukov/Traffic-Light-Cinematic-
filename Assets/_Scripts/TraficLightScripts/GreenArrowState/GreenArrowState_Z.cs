using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowState_Z : TrafficState_GreenArrow
{
    public GreenArrowState_Z(TrafficLightManager _traffic) : base(_traffic)    {    }
    public override void Enter()
    {
        for (int i = 0; i <= traffic.GreenArrowPointLight_Z.Length-1; i++)
            traffic.GreenArrowPointLight_Z[i].gameObject.SetActive(true);
        for (int i = 0; i <= traffic.GreenTextureArrow_Z.Length - 1; i++)
            traffic.GreenTextureArrow_Z[i].GetComponent<MeshRenderer>().material = traffic.material_green;
        base.Enter();
    }
    public override void Exit()
    {
        for (int i = 0; i <= traffic.GreenTextureArrow_Z.Length-1; i++)
            traffic.GreenTextureArrow_Z[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenArrowPointLight_Z.Length - 1; i++)
            traffic.GreenArrowPointLight_Z[i].gameObject.SetActive(false);
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
