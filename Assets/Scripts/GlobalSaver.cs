using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSaver : MonoBehaviour,IDependencies<RaceResultTime>
{
    private RaceResultTime raceResultTime;
    public void Construct(RaceResultTime obj) => raceResultTime = obj;

    public static string SaveMark = "_player_best_time";
    public static float GlobalRecord_01;
    public static float GlobalRecord_02;

    [SerializeField] private GameObject track_02;
    [SerializeField] private GameObject track_03;

    [SerializeField] private int Track_01_GoldTime;
    [SerializeField] private int Track_02_GoldTime;

    private void Start()
    {
        track_02.SetActive(false);
        track_03.SetActive(false);

        //GlobalRecord_01 = PlayerPrefs.GetFloat(SaveMark + 1, 0);
        //GlobalRecord_01 = PlayerPrefs.GetFloat("abc");
        GlobalRecord_01 = PlayerPrefs.GetFloat("test_race" + SaveMark, 0);
        GlobalRecord_02 = PlayerPrefs.GetFloat("race_02" + SaveMark, 0); // test_race заменить
        //Debug.Log(GlobalRecord_01);
        //Debug.Log(GlobalRecord_02);
    }

    private void Update()
    {
        
        if (GlobalRecord_01 < Track_01_GoldTime && GlobalRecord_01 > 0)
        {
            track_02.SetActive(true);
        }
        if(GlobalRecord_02 < Track_02_GoldTime && GlobalRecord_02 > 0)
        {
            track_03.SetActive(true);
        }
        
        
    }
}
