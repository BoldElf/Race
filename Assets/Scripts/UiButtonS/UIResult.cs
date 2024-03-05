using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour,IDependencies<RaceStateTracker>,IDependencies<RaceResultTime>
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text textRecord;
    [SerializeField] private Text textCurrent;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private RaceResultTime raceResultTime;
    public void Construct(RaceResultTime obj) => raceResultTime = obj;

    private void Start()
    {
        raceStateTracker.Completed += OnRaceCompleted;
    }

    private void OnDestroy()
    {
        raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceCompleted()
    {
        resultPanel.SetActive(true);

        textRecord.text = StringTime.SecondToTimeString(raceResultTime.PlayerRecordTime);
        textCurrent.text = StringTime.SecondToTimeString(raceResultTime.CurrentTime);

        if(raceResultTime.PlayerRecordTime == 0)
        {
            textRecord.text = StringTime.SecondToTimeString(raceResultTime.CurrentTime);
        }
    }
}
