using System;
using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;

public class PourSubstanceController : MonoBehaviour
{
    public ObiEmitter ObiEmitter;


    public bool isPour = false;


    private void Update()
    {
        if (!ObiEmitter.enabled && isPour)
        {
            this.ObiEmitter.enabled = true;
            isPour = true;
            
        }else if (this.ObiEmitter.enabled && !isPour)
        {
            this.ObiEmitter.enabled = false;
            isPour = false;
        }
    }
}
