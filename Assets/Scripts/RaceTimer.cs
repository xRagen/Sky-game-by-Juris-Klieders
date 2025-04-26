using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    private float raceTime = 0;
    private bool raceRuning = false;
    [SerializeField] private Leaderboards leaderboards;


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
        GameEvents.PenaltyFlag += PenaltyFlag;
    }

    private void OnDisable()
    {
        GameEvents.RaceStart -= StartRace;
        GameEvents.RaceFinish -= FinishRace;
        GameEvents.PenaltyFlag -= PenaltyFlag;
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
        GameData.Instance.racesCompleted++;
        leaderboards.AddResults(raceTime);
        Debug.Log("Finish! Time: "+ raceTime);
        Debug.Log("Races completed: "+ GameData.Instance.racesCompleted);
    }

    private void PenaltyFlag()
    {
        raceTime += 2;
        Debug.Log("Penalty flag");
    }
}
