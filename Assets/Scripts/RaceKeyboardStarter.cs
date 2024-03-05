using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceKeyboardStarter : MonoBehaviour,IDependencies<RaceStateTracker>
{
    [SerializeField] private GameObject TextEnter;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Start()
    {
        TextEnter.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return )== true)
        {
            raceStateTracker.LaunchPreparationStarted();
            TextEnter.SetActive(false);
        }
    }
}
