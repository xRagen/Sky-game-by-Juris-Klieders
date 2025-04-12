using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObstacle : MonoBehaviour
{
    void OnCollisionEnter()
    {
        OnHit();
    }

    internal virtual void OnHit()
    {
        GameEvents.CallTakeDamage();
        Debug.Log("obstacle was hit!");
    }

}
