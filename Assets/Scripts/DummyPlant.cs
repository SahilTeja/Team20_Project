using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlant : MonoBehaviour
{

    private int WaterLevel;
    public ParticleSystem water;

    // Start is called before the first frame update
    void Start()
    {
        WaterLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(WaterLevel);
    }

    void OnParticleCollision(GameObject other)
    {
        WaterLevel++;
    }
}
