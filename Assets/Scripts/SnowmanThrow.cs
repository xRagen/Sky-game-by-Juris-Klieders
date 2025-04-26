﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    public int throwSpeed;
    private bool justThown = false;
    private GameObject target;
    private Vector3 throwAngle = new Vector3(0, 0.33f, 0);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 5 == 0) 
        {
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

            if (distanceToTarget < throwDistance && justThown == false)
            {
                justThown = true;
                GameObject tempSnowBall = Instantiate(snowBall, transform.position, transform.rotation);
                Rigidbody tempRb = tempSnowBall.GetComponent<Rigidbody>();
                Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);

                //Add a small throw angle
                targetDirection += throwAngle;
                tempRb.AddForce(targetDirection * throwSpeed);
                Invoke("ThrowOver", 0.1f);
            }
        }
    }

    void ThrowOver()
    {
        justThown = false;
    }
}
