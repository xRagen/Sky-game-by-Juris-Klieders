using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.CallRaceStart();
        Debug.Log("Start!");
    }
}
