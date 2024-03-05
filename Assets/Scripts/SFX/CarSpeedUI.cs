using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpeedUI : MonoBehaviour
{
    [SerializeField] private Text speedText;
    [SerializeField] private CarChassis chassis;

   
    void Update()
    {
        if(chassis.LinearVelocity > 1.0)
        {
            speedText.text = chassis.LinearVelocity.ToString();
        }
        else
        {
            speedText.text = "000";
        }
    }
}
