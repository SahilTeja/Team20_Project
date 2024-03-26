using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{

    Outline outline = null;
    float lastLookedAt = 0;
    public float timeDelay = 0.2f;
    private Interaction[] interactions;
    // Start is called before the first frame update
    void Start()
    {
        outline = this.gameObject.GetComponent<Outline>();
        interactions = GetComponents<Interaction>();
    }

    public void viewed()
    {
        lastLookedAt = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastLookedAt <= timeDelay)
        {
            outline.enabled = true;
            if (interactions.Length != 0)
            {
                foreach (Interaction interaction in interactions)
                {
                    interaction.interact();
                }
            }
        }
        else
        {
            outline.enabled = false;
        }
    }
}
