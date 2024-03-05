using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountDownTimer : MonoBehaviour,IDependencies<RaceStateTracker>
{
    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;
    

    [SerializeField] private Text text;
    


    private void Start()
    {
        raceStateTracker.PreparationStarted += OnPreparationStarted;
        raceStateTracker.Started += OnRaceStarted;

        text.enabled = false;
    }

    private void OnDestroy()
    {
        raceStateTracker.PreparationStarted -= OnPreparationStarted;
        raceStateTracker.Started -= OnRaceStarted;
    }
    private void OnPreparationStarted()
    {
        enabled = true;
        text.enabled = true;
    }

    private void OnRaceStarted()
    {
        enabled = false;
        text.enabled = false;
    }

    private void Update()
    {
        text.text = raceStateTracker.CountDownTimer.Value.ToString("F0");

        if(text.text == "0")
        {
            text.text = "Go!";
        }
    }
} 
