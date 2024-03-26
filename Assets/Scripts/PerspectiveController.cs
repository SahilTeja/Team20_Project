using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveController : MonoBehaviour

{
    [SerializeField] private float speed;
    [SerializeField] Camera MainCam;
    private Transform cameraTransform;
    private CharacterController CC;
    private CharacterMovement CM;
    private XRCardboardController XRCC;
    public GameObject menu;
    public bool active;

    private MenuManager menuMan;


    void Start()
    {
        cameraTransform = MainCam.transform;
        enabled = true;
        active = true;
        menuMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuManager>();
    }
    void Awake()
    {
        CM = gameObject.GetComponent<CharacterMovement>();
        CC = gameObject.GetComponent<CharacterController>();
        XRCC = gameObject.GetComponentInChildren<XRCardboardController>();
    }

    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop && Input.GetKey(KeyCode.Space))
        {
            CM.enabled = false;
            XRCC.enabled = false;
            CC.enabled = false;
            float xMovement = -speed * Input.GetAxis("Vertical");
            float zMovement = speed * Input.GetAxis("Horizontal");
            Vector3 inputDirection = new Vector3(xMovement, 0, zMovement);
            cameraTransform.transform.Rotate(xMovement, zMovement, 0.0f);
            float z = cameraTransform.eulerAngles.z;
            cameraTransform.transform.Rotate(0, 0, -z);
            Physics.SyncTransforms();
        }
        else
        {
            Physics.SyncTransforms();
            CM.enabled = active;
            CC.enabled = active;
            Physics.SyncTransforms();
        }

        if (SystemInfo.deviceType == DeviceType.Desktop && !Input.GetKeyDown(KeyCode.JoystickButton3))
            return;
        else if (SystemInfo.deviceType == DeviceType.Handheld && !Input.GetKeyDown(KeyCode.JoystickButton7))
            return;
        menuMan.openMainMenu(menu);
        
    }

    public void SetCharacterController(bool b)
    {
        active = b;
        CM.enabled = b;
        CC.enabled = b;
    }
}
