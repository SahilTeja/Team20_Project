using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlant : MonoBehaviour
{

    private int WaterLevel;
    public ParticleSystem water;
    public Color initial;
    public Color final;
    public float maxWater;

    // Start is called before the first frame update
    void Start()
    {
        WaterLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //float lerp = Mathf.PingPong(Mathf.Clamp(WaterLevel , 0f, maxWater), maxWater) / maxWater;
        //Color lerpedColor = Color.Lerp(initial, final, lerp);
        Color lerpedColor = Color.Lerp(initial, final, Mathf.Clamp(WaterLevel, 0f, maxWater) / maxWater);
        GetComponent<Renderer>().material.SetColor("_Color", lerpedColor);
    }

    void OnParticleCollision(GameObject other)
    {
        if(WaterLevel <= 20)
            WaterLevel++;
    }
}
