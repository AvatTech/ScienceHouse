using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalController : MonoBehaviour
{
    [SerializeField] private GameObject potassiumObject;
    [SerializeField] private GameObject fireObject;

    private bool _hasPotassium;
    private bool _hasAcetone;
    private bool _hasAcid = true;

    private bool _isFireDone;


    private void Start()
    {
        potassiumObject.SetActive(false);
        fireObject.SetActive(false);
    }


    private void Update()
    {
        if (!_isFireDone && CanFire())
        {
            StartFire();
        }
    }


    private bool CanFire()
    {
        return _hasPotassium && _hasAcid && _hasAcetone;
    }


    private void StartFire()
    {
        fireObject.SetActive(true);
        _isFireDone = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        // Spoon
        if (other.TryGetComponent<SpoonController>(out SpoonController sp))
        {
            Debug.Log("Spoon is here");
            if (sp.hasElement)
            {
                potassiumObject.SetActive(true);
                sp.hasElement = false;
                _hasPotassium = true;
                Debug.Log("Potassium Added!");
            }
            
            
        }

        // Acetone
        if (other.CompareTag("Acetone"))
        {
            _hasAcetone = true;
            Debug.Log("Acetone Added!");
        }


        // Acid
        if (other.CompareTag("Acid"))
        {
            Debug.Log("Acid Added!");
            _hasAcid = true;
        }
    }
}