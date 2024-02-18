using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonController : MonoBehaviour
{


    [SerializeField] private GameObject potassiumObject;

    public bool hasElement;
    

    private void Start()
    {
        hasElement = false;
        potassiumObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potassium"))
        {
            potassiumObject.SetActive(true);
            hasElement = true;
        }
        else if(other.CompareTag("Container"))
            potassiumObject.SetActive(false);
    }
}