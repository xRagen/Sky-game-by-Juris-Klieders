using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float acceleration = 100, turnSpeed = 100, minSpeed = 0, maxSpeed = 100, maxAcceleration = 300, minAcceleration = -100;
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private Transform groupPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float knockBackForce = 300, knockUpForce = 400;
    private float speed = 0;
    private Animator animator;
    private bool isHurt = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameEvents.TakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        GameEvents.TakeDamage -= TakeDamage;
    }

    private void TakeDamage()
    {
        rb.AddForce(-transform.forward * knockBackForce);
        rb.AddForce(transform.up * knockUpForce);
        Debug.Log("Player was hurt");
        isHurt = true;
        Invoke("Recover", 1.5f);
    }

    private void Recover()
    {
        isHurt = false;
    }

    private void FixedUpdate()
    {
        if (isHurt)
            return;
        float angle = Mathf.Abs(transform.eulerAngles.y - 180);
        acceleration = Remap(0, 90, minAcceleration, maxAcceleration, angle);
        //Debug.Log($"angle {angle} acceleration {acceleration}");
        speed += acceleration * Time.fixedDeltaTime;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        Vector3 velocity = speed * transform.forward * Time.fixedDeltaTime;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        animator.SetFloat("playerSpeed", speed);
    }


    void Update()
    {
        bool isGraunded = Physics.Linecast(transform.position, groupPoint.position, groundLayer);
        if (isGraunded && !isHurt) 
        {
            if (Input.GetKey(leftInput) && transform.eulerAngles.y < 269)
            {
                transform.Rotate(new Vector3(0, turnSpeed * Time.deltaTime, 0), Space.Self);
            }
            if (Input.GetKey(rightInput) && transform.eulerAngles.y > 91)
            {
                transform.Rotate(new Vector3(0, -turnSpeed * Time.deltaTime, 0), Space.Self);
            }


        }
        

    }

    

    // remaps a number from a given range into a new range
    private float Remap(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }

}
