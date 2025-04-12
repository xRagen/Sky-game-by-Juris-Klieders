using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private float raceTime = 0;
    private bool raceRuning = false;

    // Update is called once per frame
    private void Update()
    {
        if(raceRuning)
            raceTime += Time.deltaTime;
    }

    private void OnEnable()
    {
        GameEvents.RaceStart += StartRace;
        GameEvents.RaceFinish += FinishRace;
    }

    private void OnDisable()
    {
        GameEvents.RaceStart -= StartRace;
        GameEvents.RaceFinish -= FinishRace;
    }

    private void StartRace()
    {
        raceTime = 0;
        raceRuning = true;
        Debug.Log("Race start!");
    }


    private void FinishRace()
    {
        raceRuning = false;
        Debug.Log("Finish! Time: "+ raceTime);
    }
}
