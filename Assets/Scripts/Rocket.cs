﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource thrust;
    [SerializeField] float thrustSpeed = 100f;
    [SerializeField] float rotationSpeed = 100f;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        thrust = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        Control();
        ThrustAudio();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
            print("Okay");
            break;

            case "Fuel":
            print("Fueling");
            break;
            
            default:
            print("Dead");
            break;
        }    
    }  

    private void Control()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustSpeed);
        }

        rb.freezeRotation = true; // halt physics and allow manual rotation
        float rcsThrust = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(Vector3.forward * rcsThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(-Vector3.forward * rcsThrust);
        }

        rb.freezeRotation = false; //resume physics
    }

    private void ThrustAudio()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            thrust.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            thrust.Stop();
        }
    }    
}
