using System.Collections;
using UnityEngine;
using TMPro;

public class VoltageMeter : MonoBehaviour
{
    public TextMeshPro voltageText;

    public float targetVoltage = 53f;
    public float speed = 15f;

    private float currentVoltage = 0f;
    private bool measuring = false;

    public void StartMeasuring()
    {
        if (!measuring)
            StartCoroutine(Measure());
    }

    IEnumerator Measure()
    {
        measuring = true;

        while (currentVoltage < targetVoltage)
        {
            currentVoltage += Time.deltaTime * speed;

            if (currentVoltage > targetVoltage)
                currentVoltage = targetVoltage;

            voltageText.text = currentVoltage.ToString("F1") + " V";

            yield return null;
        }
    }

    public void ResetMeter()
    {
        StopAllCoroutines();
        currentVoltage = 0f;
        measuring = false;
        voltageText.text = "0.0 V";
    }
}