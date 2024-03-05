using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarGearUI : MonoBehaviour
{
    [SerializeField] private Text gearText;
    [SerializeField] private Car car;
    [SerializeField] private Image engine;

    // Update is called once per frame
    void Update()
    {
        gearText.text = (car.SelectedGearIndex + 1).ToString();
        engine.fillAmount = (car.EngineRPM / car.EngineMaxRPM);

        if(car.EngineRPM > 5500)
        {
            engine.color = Color.red;
        }
        if(car.EngineRPM > 4000 && car.EngineRPM < 5500)
        {
            engine.color = Color.yellow;
        }
        if (car.EngineRPM < 4000)
        {
            engine.color = Color.white;
        }
    }
}
