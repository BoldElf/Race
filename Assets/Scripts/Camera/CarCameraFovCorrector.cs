using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraFovCorrector : CarCameraComponent
{
    [SerializeField] private float minFieldOfView;
    [SerializeField] private float maxFieldOfView;

    private float defaultFieldOfView;

    private void Start()
    {
        camera.fieldOfView = defaultFieldOfView;
    }

    private void Update()
    {
        camera.fieldOfView = Mathf.Lerp(minFieldOfView, maxFieldOfView, car.NormalizeLinearVelocity);
    }
}
