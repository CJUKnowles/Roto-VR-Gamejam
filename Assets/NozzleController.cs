using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;
using Unity.VRTemplate;
using System.Numerics;
using System.Collections;
using Unity.VisualScripting;
using Unity.Mathematics;

public class ControllerInput : MonoBehaviour
{
    public GameObject nozzle;
    public float nozzleStrength;
    public float nozzleRotationStrength;
    public float rotationThreshold;

    private void FixedUpdate()
    {
        List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            if(device.role.ToString() == "LeftHanded") {
                Boolean triggerValue = false;
                if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) {
                    useNozzle();
                }
            }
        }
    }


    private void useNozzle() {
        // Spray the smoke
        nozzle.GetComponent<LaunchProjectile>().Fire();
        movePlayer1();
    }

    private void movePlayer1() {
        // Move the Player
        //Debug.Log(transform.eulerAngles.y - nozzle.transform.eulerAngles.y);
        GetComponent<Rigidbody>().AddForce(-nozzle.transform.forward * nozzleStrength);

        float angle = UnityEngine.Vector3.SignedAngle(transform.forward, nozzle.transform.right, UnityEngine.Vector3.up);
        float betterAngle = angle + 0;

        if(betterAngle > 90) {
            betterAngle = 180-betterAngle;
        }

        if(betterAngle < -90) {
            betterAngle = -180-betterAngle;
        }

        //Debug.Log(math.sin(angle));
        Debug.Log(betterAngle);
        if(math.abs(betterAngle) > rotationThreshold) {
            GetComponent<Rigidbody>().AddTorque(0, betterAngle * nozzleRotationStrength, 0);
        }
    }

    private void movePlayer2() {
        UnityEngine.Vector3 torque = UnityEngine.Vector3.Cross(transform.position, -nozzle.transform.position);
        torque.y = 0;
        GetComponent<Rigidbody>().AddForceAtPosition(torque, transform.position, ForceMode.Impulse);
    }

    private void movePlayer3() {
        nozzle.GetComponent<Rigidbody>().AddForce(UnityEngine.Vector3.right * nozzleStrength);
    }
}