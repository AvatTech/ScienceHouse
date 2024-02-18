using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu(menuName = "Chemical Reaction")]
public class ChemicalExperiment : ScriptableObject
{
    public List<Step> steps = new();

    public bool IsFinished;

    private int currentStep = -1;

    private void OnEnable()
    {
        currentStep = -1;
    }

    public bool TryGetNextStep(out Step step)
    {
        Debug.Log("Step count is " + steps.Count);
        if (currentStep >= steps.Count)
        {
            step = null;
            return false;
        }

        currentStep++;
        step = steps[currentStep];

        if (currentStep == steps.Count - 1)
            IsFinished = true;

        return true;
    }
}


[Serializable]
public class Step
{
    [TextArea] public string HintText;
    public bool IsDone;

    public Step(string hintText)
    {
        HintText = hintText;
    }
}