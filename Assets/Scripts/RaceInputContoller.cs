using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceInputContoller : MonoBehaviour,IDependencies<CarInputControl>,IDependencies<RaceStateTracker>
{
    private CarInputControl carContol;
    public void Construct(CarInputControl obj) => carContol = obj;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;


    private void Start()
    {
        raceStateTracker.Started += OnRaceStarted;
        raceStateTracker.Completed += OnRaceFinished;
        carContol.enabled = false;
    }

    private void OnDestroy()
    {
        raceStateTracker.Started -= OnRaceStarted;
        raceStateTracker.Completed -= OnRaceFinished;
    }

    

    private void OnRaceStarted()
    {
        carContol.enabled = true;
    }

    private void OnRaceFinished()
    {
        carContol.enabled = false;
        carContol.Stop();
    }
}
