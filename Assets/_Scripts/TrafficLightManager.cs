using System.Collections;
using UnityEngine;

public enum ButtonState { XButton, ZButton, Neutral }
public enum LightState { Red, Yellow, Green }

public class TrafficLightManager : MonoBehaviour
{
    public GameObject[] RedPointLight_X;
    public GameObject[] RedPointLight_Z;
    public GameObject[] YellowPointLight;
    public GameObject[] GreenPointLight_X;
    public GameObject[] GreenPointLight_Z;
    public GameObject[] GreenArrowPointLight_X;
    public GameObject[] GreenArrowPointLight_Z;

    public GameObject[] CrasswalkPointLightGreen_X;
    public GameObject[] CrasswalkPointLightRed_X;
    public GameObject[] CrasswalkPointLightGreen_Z;
    public GameObject[] CrasswalkPointLightRed_Z;

    public GameObject[] GreenTextureCrasswalk_X;
    public GameObject[] GreenTextureCrasswalk_Z;
    public GameObject[] RedTextureCrasswalk_X;
    public GameObject[] RedTextureCrasswalk_Z;

    public GameObject[] RedTextureLights_X;
    public GameObject[] RedTextureLights_Z;
    public GameObject[] YellowTextureLights;
    public GameObject[] GreenTextureLights_X;
    public GameObject[] GreenTextureLights_Z;
    public GameObject[] GreenTextureArrow_X;
    public GameObject[] GreenTextureArrow_Z;


    #region

    public Material material_red;
    public Material material_yellow;
    public Material material_green;
    public Material material_grey;

    private StateMachineRedLightSwitcher SM_Red;
    private StateMachineGreenLightSwitcher SM_Green;
    private StateMachineYellowLightSwitcher SM_Yellow;
    private StateMachineGreenArrowSwitcher SM_GreenArrow;
    private StateMachineCrasswalkLightSwitcher SM_Crosswalk;

    private Red_XGreen_Z red_XGreen_Z;
    private Red_ZGreen_X red_ZGreen_X;
    private Red_X_Z red_X_Z;

    private RedLightState_X redLightState_X;
    private RedLightState_Z redLightState_Z;
    private YellowLightState_ON yellowLightState_On;
    private YellowLightState_Off yellowLightState_Off;

    private GreenLightState_X greenLightState_X;
    private GreenLightState_Z greenLightState_Z;
    private GreenLightState_Off greenLightState_Off;

    private GreenArrowState_X greeArrowState_X;
    private GreenArrowState_Z greeArrowState_Z;
    private GreenArrowState_Off greeArrowState_Off;
    #endregion

    float startTime;
    const float yellowTime = 3;
    private float greenCycleTime;
    public float timeCycleOfTraffic;

    public LightState lightState;
    public ButtonState crosswalkButton;

    private bool wasGreen;

    private void Start()
    {
        crosswalkButton = ButtonState.Neutral;
        startTime = timeCycleOfTraffic;
        greenCycleTime = (timeCycleOfTraffic - yellowTime * 2) / 2;

        #region
        SM_Crosswalk = new StateMachineCrasswalkLightSwitcher();
        SM_GreenArrow = new StateMachineGreenArrowSwitcher();
        SM_Yellow = new StateMachineYellowLightSwitcher();
        SM_Red = new StateMachineRedLightSwitcher();
        SM_Green = new StateMachineGreenLightSwitcher();


        red_XGreen_Z = new Red_XGreen_Z(this);
        red_ZGreen_X = new Red_ZGreen_X(this);
        red_X_Z = new Red_X_Z(this);

        greeArrowState_X = new GreenArrowState_X(this);
        greeArrowState_Z = new GreenArrowState_Z(this);
        greeArrowState_Off = new GreenArrowState_Off(this);
        greenLightState_Off = new GreenLightState_Off(this);
        redLightState_X = new RedLightState_X(this);
        redLightState_Z = new RedLightState_Z(this);
        greenLightState_X = new GreenLightState_X(this);
        greenLightState_Z = new GreenLightState_Z(this);
        yellowLightState_On = new YellowLightState_ON(this);
        yellowLightState_Off = new YellowLightState_Off(this);
        greeArrowState_Off = new GreenArrowState_Off(this);
        greeArrowState_Z = new GreenArrowState_Z(this);
        greeArrowState_X = new GreenArrowState_X(this);

        SM_Red.Initialize(redLightState_X);
        SM_Crosswalk.Initialize(red_X_Z);
        SM_Yellow.Initialize(yellowLightState_Off);
        SM_Green.Initialize(greenLightState_Z);
        SM_GreenArrow.Initialize(greeArrowState_Off);

        #endregion
    }

    private void Update()
    {
        timeCycleOfTraffic -= Time.deltaTime;
        TraficManager();
        Crosswalk();
    }

    void TraficManager()
    {
        // Cycle starting Red light on X axis and Green light on Z axis
        if (lightState == LightState.Red) 
        {
            if (timeCycleOfTraffic <= startTime - greenCycleTime)
                lightState = LightState.Yellow;

            wasGreen = false;
            if (timeCycleOfTraffic <= startTime - 1)
                SM_GreenArrow.ChangeState(greeArrowState_X);

            SM_Yellow.ChangeState(yellowLightState_Off);
            SM_Red.ChangeState(redLightState_X);
            SM_Green.ChangeState(greenLightState_Z);

        }
        if (lightState == LightState.Yellow) 
        {
            if (timeCycleOfTraffic <= startTime - greenCycleTime - 3 && !wasGreen)
                lightState = LightState.Green;
            else if (wasGreen && timeCycleOfTraffic <= 0)
            {
                lightState = LightState.Red;
                timeCycleOfTraffic = startTime;
            }
            SM_GreenArrow.ChangeState(greeArrowState_Off);
            SM_Yellow.ChangeState(yellowLightState_On);
            SM_Green.ChangeState(greenLightState_Off);
            SM_Crosswalk.ChangeState(red_X_Z);

        }
        if (lightState == LightState.Green) 
        {
            wasGreen = true;
            if (timeCycleOfTraffic <= 3) 
                lightState = LightState.Yellow;

            if (timeCycleOfTraffic <= startTime - greenCycleTime - yellowTime - 1)
                SM_GreenArrow.ChangeState(greeArrowState_Z);
            SM_Red.ChangeState(redLightState_Z);
            SM_Green.ChangeState(greenLightState_X);
            SM_Yellow.ChangeState(yellowLightState_Off);

        }
    }
    private void Crosswalk()
    {
        if (crosswalkButton == ButtonState.XButton && lightState == LightState.Green)
            if (timeCycleOfTraffic >= yellowTime + 7)
                StartCoroutine(ForSecond());
        if (crosswalkButton == ButtonState.ZButton && lightState == LightState.Red)
            if (timeCycleOfTraffic >= startTime - greenCycleTime + 7)
                StartCoroutine(ForSecond());
    }
    IEnumerator ForSecond()
    {
        yield return new WaitForSeconds(2);
        if (lightState == LightState.Green)
            SM_Crosswalk.ChangeState(red_ZGreen_X);
        else if (lightState == LightState.Red)
            SM_Crosswalk.ChangeState(red_XGreen_Z);
    }

    public void LeftButton_Z() => crosswalkButton = ButtonState.XButton;
    public void RightButton_X() => crosswalkButton = ButtonState.ZButton;    
}
