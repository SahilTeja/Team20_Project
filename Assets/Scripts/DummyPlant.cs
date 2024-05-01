using UnityEngine;

public class DummyPlant : MonoBehaviour
{
    public int WaterLevel;
    public ParticleSystem water;
    private Material soilMaterial;
    public float maxWater;
    public int neededWater;
    public Vector3 initialScale; // Store the initial scale of the object

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        soilMaterial = renderer.material;
        WaterLevel = 0;
        initialScale = transform.localScale; // Store the initial scale
    }

    void Update()
    {
        soilMaterial.SetFloat("_WaterLevel", 5*WaterLevel/maxWater);
    }

    void OnParticleCollision(GameObject other)
    {
        if (WaterLevel < 20)
            WaterLevel++;
    }
}
