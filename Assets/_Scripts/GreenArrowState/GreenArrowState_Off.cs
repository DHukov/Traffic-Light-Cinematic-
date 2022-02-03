using UnityEngine;

public class GreenArrowState_Off : TrafficState_GreenArrow
{
    public GreenArrowState_Off(TrafficLightManager _traffic) : base(_traffic)    {    }
    public override void Enter()
    {
        GreenArrowTurnOff();
        base.Enter();
    }
    public override void Exit()
    {
        GreenArrowTurnOff();
        base.Exit();
    }

    private void GreenArrowTurnOff()
    {
        for (int i = 0; i <= traffic.GreenTextureLights_X.Length - 1; i++)
            traffic.GreenTextureLights_X[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenTextureLights_Z.Length - 1; i++)
            traffic.GreenTextureLights_Z[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.GreenArrowPointLight_X.Length - 1; i++)
            traffic.GreenArrowPointLight_X[i].gameObject.SetActive(false);
        for (int i = 0; i <= traffic.GreenArrowPointLight_Z.Length - 1; i++)
            traffic.GreenArrowPointLight_Z[i].gameObject.SetActive(false);
    }
    public override void Update()
    {
        base.Update();
    }
}
