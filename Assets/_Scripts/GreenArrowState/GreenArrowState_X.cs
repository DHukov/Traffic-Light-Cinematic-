using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenArrowState_X : TrafficState_GreenArrow
{
    public GreenArrowState_X(TrafficLightManager _traffic) : base(_traffic)    {    }
    public override void Enter()
    {
        for (int i = 0; i <= traffic.GreenTextureArrow_X.Length-1; i++)
            traffic.GreenTextureArrow_X[i].GetComponent<MeshRenderer>().material = traffic.material_green;
        for (int i = 0; i <= traffic.GreenArrowPointLight_X.Length - 1; i++)
            traffic.GreenArrowPointLight_X[i].gameObject.SetActive(true);
        base.Enter();
    }
    public override void Exit()
    {
        for (int i = 0; i <= traffic.GreenTextureArrow_X.Length-1; i++)
            traffic.GreenTextureArrow_X[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenArrowPointLight_X.Length - 1; i++)
            traffic.GreenArrowPointLight_X[i].gameObject.SetActive(false);
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
