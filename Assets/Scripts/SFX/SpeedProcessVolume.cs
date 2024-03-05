using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SpeedProcessVolume : MonoBehaviour
{
    [SerializeField] private Car car;

    private PostProcessVolume postProcessVolume;
    private Vignette vignette;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out vignette);
    }
     private float t;
    private void Update()
    {
       
        if (car.LinearVelocity >= 200.0f)
        {
            vignette.intensity.value = 0.2f;
        }
        if (car.LinearVelocity >= 240.0f)
        {
            vignette.intensity.value = 0.3f;
        }
        if (car.LinearVelocity >= 260.0f)
        {
            vignette.intensity.value = 0.4f;
        }
        if(car.LinearVelocity < 200.0f)
        {
            vignette.intensity.value = 0f;
        }
    }
}
