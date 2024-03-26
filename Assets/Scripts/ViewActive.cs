using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewActive : MonoBehaviour
{

    public LayerMask mask;
    public float distance = 50;
    private LineRenderer lineRenderer;
    public Vector3 offset = new Vector3(-0.5f, -0.5f, 0);
    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        active = true;

        // Create a gradient with green at the start and red at the end
        lineRenderer.material.color = new Color(0,1,0,0.25f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, out var hit, distance, mask))
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position+transform.TransformDirection(offset));
            lineRenderer.SetPosition(1, hit.point);
            //Debug.Log("Object Looked At");
            if (active)
            {
                hit.collider.gameObject.GetComponent<OutlineManager>().viewed();
            }     
        }
        else
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position + transform.TransformDirection(offset));
            lineRenderer.SetPosition(1, transform.position + transform.forward*distance);
        }
    }
}
