using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanitizerReaction : MonoBehaviour
{
    
    public FloatValue playerHygiene;
    public Signal hygieneSignal;

    public void Use(int amountToIncrease)
    {
        playerHygiene.RuntimeValue += amountToIncrease;
        hygieneSignal.Raise();
    }
}
