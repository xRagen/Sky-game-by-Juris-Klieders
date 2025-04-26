using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboards : MonoBehaviour
{
    [SerializeField] private List<float> results = new List<float>();

    void Start()
    {
        results.Clear();
        for (int i = 0; i < 5; i++)
        {
            float toAdd = PlayerPrefs.GetFloat("time" + i, 99999);
            results.Add(toAdd);
        }
    }

    public void AddResults(float time)
    {
        results.Add(time);
        results.Sort();
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat("time" + i, results[i]);
        }
        PlayerPrefs.Save();
    }
}
