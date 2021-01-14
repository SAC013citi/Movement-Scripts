using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthFill;
    public FloatValue playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = playerHealth.initialValue;
    }

    public void UpdateHealth()
    {
        slider.value = playerHealth.initialValue;
        healthFill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
