using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_X_Z : TrafficState_CrossWalk
{
    public Red_X_Z(TrafficLightManager _traffic) : base(_traffic)    {   }
    public override void Enter()
    {

        for (int i = 0; i <= traffic.RedTextureCrasswalk_X.Length - 1; i++)
            traffic.RedTextureCrasswalk_X[i].GetComponent<MeshRenderer>().material = traffic.material_red;
        for(int i = 0; i <= traffic.RedTextureCrasswalk_Z.Length - 1; i++)
            traffic.RedTextureCrasswalk_Z[i].GetComponent<MeshRenderer>().material = traffic.material_red;

        for (int i = 0; i <= traffic.CrasswalkPointLightRed_X.Length - 1; i++)
            traffic.CrasswalkPointLightRed_X[i].gameObject.SetActive(true);
        for (int i = 0; i <= traffic.CrasswalkPointLightRed_Z.Length - 1; i++)
            traffic.CrasswalkPointLightRed_Z[i].gameObject.SetActive(true);

        base.Enter();
    }
    public override void Exit()
    {
        for (int i = 0; i <= traffic.RedTextureCrasswalk_X.Length - 1; i++)
            traffic.RedTextureCrasswalk_X[i].GetComponent<MeshRenderer>().material = traffic.material_grey;
        for (int i = 0; i <= traffic.RedTextureCrasswalk_Z.Length - 1; i++)
            traffic.RedTextureCrasswalk_Z[i].GetComponent<MeshRenderer>().material = traffic.material_grey;

        for (int i = 0; i <= traffic.CrasswalkPointLightRed_X.Length - 1; i++)
            traffic.CrasswalkPointLightRed_X[i].gameObject.SetActive(false);
        for (int i = 0; i <= traffic.CrasswalkPointLightRed_Z.Length - 1; i++)
            traffic.CrasswalkPointLightRed_Z[i].gameObject.SetActive(false);

        base.Exit();
    }
    public override void Update()
    {
        base.Update();
    }
}
