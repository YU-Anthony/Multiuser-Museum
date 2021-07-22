using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class InputListenerTriggerButton : MonoBehaviour
{

    List<InputDevice> devices;
    public XRNode controllerNode;

    [Tooltip("Event when the button starts being pressed")]
    public UnityEvent onPress;

    [Tooltip("Event when the button starts is released")]
    public UnityEvent OnRelease;

    // Keep track of whether we are pressing the button
    bool isPressed = false;

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
            Debug.Log(device.name + "------" + device.characteristics);
            if (device.isValid)
            {
                bool inputValue;

                if (device.TryGetFeatureValue(CommonUsages.triggerButton, out inputValue) && inputValue)
                {
                    
                    if (!isPressed)
                    {
                        Debug.Log("----------------");
                        isPressed = true;
                        Debug.Log("onPress event is called");
                        onPress.Invoke();
                    }
                }
                else if(isPressed)
                {
                    Debug.Log("***************");
                    isPressed = false;
                    OnRelease.Invoke();
                    Debug.Log("OnRelease event is called");
                }
            }
        }
    }
}
