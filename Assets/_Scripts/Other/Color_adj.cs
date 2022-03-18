using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;


public class Color_adj : MonoBehaviour
{
    private Volume volume;
    private ColorAdjustments color_adj;
    private Bloom bloom;
    public float parametres;
    float time;

    public void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<ColorAdjustments>(out color_adj);
    }
    public void Update()
    {
        time = Time.deltaTime;
        parametres -= time;
        color_adj.postExposure.value = parametres;

        if (parametres <= 0)
            parametres = 0;
    }

}
