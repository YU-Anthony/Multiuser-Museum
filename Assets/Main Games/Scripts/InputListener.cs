using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputListener : MonoBehaviour
{
    List<InputDevice> devices;
    public XRNode controllerNode;

    private void Awake()
    {
        devices = new List<InputDevice>();
    }


    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetDevice();
    }

    // Update is called once per frame
    void Update()
    {
        GetDevice();
        foreach (var device in devices)
        {
            Debug.Log("Device found with name: " + device.name);
            bool inputValue;
            if(device.TryGetFeatureValue(CommonUsages.triggerButton, out inputValue) && inputValue)
            {
                Debug.Log("You pressed the trigger button");
            }
        }
    }
}
