using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    private bool hasStarted = false;
    
    [SerializeField] ParticleSystem particle = null;
    [SerializeField] ParticleSystem particle2 = null;
    
    public GameObject TimeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {

            elapsedTime = Time.time - startTime;
            
            
            TimeText.GetComponent<Text>().text = "Time: " + elapsedTime.ToString();

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        hasStarted = true;
        startTime = Time.time;
        
        particle.Play();
        
        particle2.Play();
    }
}
