using System;
using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class MonitorManager : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro hintText;
    [SerializeField] private ChemicalExperiment chemicalExperiment;

    private void Start()
    {
        OnNextStepTrigger();
    }


    public void OnNextStepTrigger()
    {
        if (chemicalExperiment.TryGetNextStep(out Step step))
        {
            Debug.Log($"Step: {step.HintText}");
            UpdateText(step.HintText);
        }
        else
            Debug.Log("Experiment Finished!");
    }

    private void UpdateText(string text)
    {
        hintText.text = text;
    }
}