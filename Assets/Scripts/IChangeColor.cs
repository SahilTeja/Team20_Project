using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IChangeColor : Interaction
{
    Color lerpedColor;
    public float time = 1f;
    private float startTime = 0;

    public Color[] colors;
    private int colorIndex = 0;

    private Color toColor;
    private Color fromColor;
    public override void interact()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton1))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton2))
            return;
        fromColor = lerpedColor;
        toColor = colors[colorIndex = (colorIndex + 1) % (colors.Length)];
        startTime = Time.time;
    }

    public void Start()
    {
        lerpedColor = colors[colorIndex];
        startTime = Time.time;

        toColor = colors[colorIndex];
        fromColor = GetComponent<Renderer>().material.color;
    }

    public void Update()
    {
        lerpedColor = Color.Lerp(fromColor, toColor, Mathf.Clamp(Time.time - startTime, 0, time) / time);
        //lerpedColor = Color.Lerp(fromColor, toColor, Mathf.PingPong(Mathf.Clamp(Time.time - startTime, 0, 1), time));
        GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
    }

}
