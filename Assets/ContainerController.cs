using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    [SerializeField] private GameObject waterParticleSystem;
    [SerializeField] private GameObject spillPos;
    

    public ParticleSystem pouringParticles;
    public float pourAngleThreshold = 90; // Adjust this value as needed

    void Update()
    {
        waterParticleSystem.transform.position = spillPos.transform.position;
        
        if (IsPouring())
        {
            pouringParticles.Play();
        }
        else
        {
            pouringParticles.Stop();
        }
    }

    bool IsPouring()
    {
        // Check if the object's rotation around the X-axis meets the pouring criteria
        float angle = Mathf.Abs(transform.rotation.eulerAngles.x);

        if (angle >= 360f - pourAngleThreshold || angle <= pourAngleThreshold)
        {
            return true; // Object's rotation resembles pouring
        }
        else
        {
            return false; // Object's rotation does not resemble pouring
        }
    }
}