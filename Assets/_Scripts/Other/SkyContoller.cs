using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyContoller : MonoBehaviour
{
    public Material mat;
    public float time;
    public float SkySpeed = 1;
    float Sky_Num;

    void Update()
    {
        time = Time.time;
        mat.SetFloat("_Rotation", Sky_Num + time * SkySpeed);
    }
}
