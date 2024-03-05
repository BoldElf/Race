using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarChassis : MonoBehaviour
{
    [SerializeField] private WheelAxle[] wheelAxles;
    [SerializeField] private float wheelBaseLenth;

    [SerializeField] private Transform centerOfMass;

    public float MotorTorque;
    public float BreakTorque;
    public float SteerAngel;

    [Header("Down Force")]
    [SerializeField] private float downForceMin;
    [SerializeField] private float downForceMax;
    [SerializeField] private float downForceFactor;

    [Header("AngularDrug")]
    [SerializeField] private float angularDrugMin;
    [SerializeField] private float angularDrugMax;
    [SerializeField] private float angularDrugFactor;

    private new Rigidbody rigidbody;
    public Rigidbody Rigidbody => rigidbody == null ? GetComponent<Rigidbody>() : rigidbody;

    public float LinearVelocity => rigidbody.velocity.magnitude * 3.6f;
    
     private void Start()
     {
        rigidbody = GetComponent<Rigidbody>();

        if(centerOfMass != null)
        {
            rigidbody.centerOfMass = centerOfMass.localPosition;
        }

        for(int i = 0; i < wheelAxles.Length;i++)
        {
            wheelAxles[i].ConfigurateVehicleSubsteps(50, 50, 50);
        }
     }


    private void FixedUpdate()
    {
        UpdateAngularGrug();

        UpdateDownForce();

        UpgateWheelAxles();
    }

    public float GetAverageRpm()
    {
        float sum = 0;

        for(int i = 0; i <wheelAxles.Length;i++)
        {
            sum += wheelAxles[i].GetAvarageRpm();
        }
        return sum / wheelAxles.Length;
    }

    public float GetWheelSpeed()
    {
        return GetAverageRpm() * wheelAxles[0].GetRadius() * 2 * 0.1885f;
    }

    private void UpdateDownForce()
    {
        float downForce = Mathf.Clamp(downForceFactor * LinearVelocity, downForceMin, downForceMax);
        rigidbody.AddForce(-transform.up * downForce);
    }

    private void UpdateAngularGrug()
    {
        rigidbody.angularDrag = Mathf.Clamp(angularDrugFactor * LinearVelocity,angularDrugMin,angularDrugMax);
    }

    private void UpgateWheelAxles()
    {
        int amountMotorWheel = 0;

        for(int i = 0; i < wheelAxles.Length;i++)
        {
            if( wheelAxles[i].IsMotor == true)
            {
                amountMotorWheel += 2;
            }
           
        }


        for (int i = 0; i < wheelAxles.Length; i++)
        {
            wheelAxles[i].Update();
            wheelAxles[i].ApplyBreakTorque(BreakTorque);
            wheelAxles[i].ApplyMotorTorque(MotorTorque / amountMotorWheel);
            wheelAxles[i].ApplySteerAngle(SteerAngel, wheelBaseLenth);
        }
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

    }
}
