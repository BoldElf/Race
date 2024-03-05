using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraShaker : CarCameraComponent
{
    [SerializeField] private float shakeAmount;
    [SerializeField] [Range(0.0f, 1.0f)] private float normilizeSpeedShake;

    private void Update()
    {
        if(car.NormalizeLinearVelocity >= normilizeSpeedShake)
        {
            transform.localPosition += Random.insideUnitSphere * shakeAmount * Time.deltaTime;
        }
    }
}
