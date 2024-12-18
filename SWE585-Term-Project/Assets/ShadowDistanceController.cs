using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
using TMPro;

public class ShadowDistanceController : MonoBehaviour
{
    public Volume volume; 
    public Slider shadowSlider;
    public TextMeshProUGUI distanceText;
    private HDShadowSettings shadowSettings; 

    void Start()
    {

        if (volume.profile.TryGet(out shadowSettings))
        {
            shadowSlider.value = shadowSettings.maxShadowDistance.value;
            UpdateDistanceText(shadowSlider.value);
            shadowSlider.onValueChanged.AddListener(UpdateShadowDistance);
        }
        else
        {
            Debug.LogError("No Shadows override found in the Volume profile!");
        }
    }

    void UpdateShadowDistance(float value)
    {

            shadowSettings.maxShadowDistance.value = value;
            UpdateDistanceText(value);
    }

    void UpdateDistanceText(float value)
    {
        distanceText.text = $"{value:F1}"; 
    }
}
