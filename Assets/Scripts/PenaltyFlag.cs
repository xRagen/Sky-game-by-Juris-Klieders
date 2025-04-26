using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.CallRacePenaltyFlag();
    }
}
