using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelEffect : MonoBehaviour
{
    bool isSlip = false;

    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private ParticleSystem[] wheelsSmoke;

    [SerializeField] private float forwardSlipLimit;
    [SerializeField] private float SidewaySlipLimit;

    [SerializeField] private new AudioSource audio;

    [SerializeField] private GameObject skidPrefab;

    private WheelHit wheelHit;
    private Transform[] skidTrail;


    private void Start()
    {
        skidTrail = new Transform[wheels.Length];
    }
    private void Update()
    {
        for(int i = 0; i < wheels.Length;i++)
        {
            wheels[i].GetGroundHit(out wheelHit);

            wheelHit.forwardSlip = Mathf.Abs(wheelHit.forwardSlip);
            wheelHit.sidewaysSlip = Mathf.Abs(wheelHit.sidewaysSlip);

            if (wheels[i].isGrounded == true)
            {
                if(wheelHit.forwardSlip > forwardSlipLimit || wheelHit.sidewaysSlip > SidewaySlipLimit)
                {
                    if(skidTrail[i] == null)
                    {
                        skidTrail[i] = Instantiate(skidPrefab).transform;
                    }
                

                    if(audio.isPlaying == false)
                    {
                        audio.Play();
                    }

                    if(skidTrail[i] != null)
                    {
                        skidTrail[i].position = wheels[i].transform.position - wheelHit.normal * wheels[i].radius;
                        skidTrail[i].position += new Vector3(0, 0.4f, 0);
                        skidTrail[i].forward = -wheelHit.normal;

                        wheelsSmoke[i].transform.position = skidTrail[i].position;
                        wheelsSmoke[i].Emit(10);
                    }
                    isSlip = true;
                    continue;
                }
                    skidTrail[i] = null;
                    wheelsSmoke[i].Stop();
            }
            
        }
        if(isSlip == false)
        {
            audio.Stop();
        }
    }
}
