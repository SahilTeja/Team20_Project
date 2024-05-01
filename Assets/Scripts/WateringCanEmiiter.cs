using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanEmiiter : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem water;

    // Start is called before the first frame update
    void Start()
    {
        var emission = water.emission;
         emission.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && (!Input.GetKey(KeyCode.JoystickButton1) && !Input.GetKey(KeyCode.B)))
            {StopWater();return;}
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKey(KeyCode.JoystickButton2))
            {StopWater();return;}

        var emission = water.emission;
        emission.rateOverTime = 30;

        Debug.Log("Watering");

       
    }

    void StopWater()
    {
        var emission = water.emission;
        emission.rateOverTime = 0;
    }
}
