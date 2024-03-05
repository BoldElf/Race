using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMusic : MonoBehaviour
{
    
    [SerializeField] private Car car;
    //private AudioSource winde;
    [SerializeField] private GameObject sound;

    private void Start()
    {
        //winde = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(car.LinearVelocity >= 200.0f)
        {
            //winde.Play();
            sound.SetActive(true);
        }
        else
        {
            sound.SetActive(false);
        }
        
    }
}
