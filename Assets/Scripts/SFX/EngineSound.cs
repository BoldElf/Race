using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EngineSound : MonoBehaviour
{
    [SerializeField] Car car;
    [SerializeField] private float pitchModifier;
    [SerializeField] private float volumeModifier;
    [SerializeField] private float rpmModifire;

    [SerializeField] private float basePitch = 1.0f;
    [SerializeField] private float baseVolume = 0.4f;

    private AudioSource engineAudioSource;

    private void Start()
    {
        engineAudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        engineAudioSource.pitch = basePitch + pitchModifier * ((car.EngineRPM / car.EngineMaxRPM) * rpmModifire);
        engineAudioSource.volume = baseVolume + volumeModifier * (car.EngineRPM / car.EngineMaxRPM);
    }
}
