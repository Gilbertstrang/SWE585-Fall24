using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;
using UnityEngine.Rendering.HighDefinition;


public class TestController : MonoBehaviour
{   
    [SerializeField] private Light directionalLight;
    private List<Light> spotLights = new();
    private List<Light> pointLights = new();
   

    private void Start()
    {
        var lights = FindObjectsOfType<Light>().ToList();
        spotLights = lights.Where(light => light.type == LightType.Spot).ToList();
        pointLights = lights.Where(light => light.type == LightType.Point).ToList();
    }

    public void EnableDirectionalLightMode()
    {
        EnableDirectionalLight(true);
        EnablePointLights(false);
        EnableSpotLights(false);
        
    }

    public void EnableSpotLightMode()
    {
        EnableDirectionalLight(false);
        EnablePointLights(false);
        EnableSpotLights(true);

    }

    public void EnablePointLightMode()
    {
        EnableDirectionalLight(false);
        EnablePointLights(true);
        EnableSpotLights(false);

    }

    public void EnableLowShadowResolution()
    {
        SetShadowResolution(LightShadowResolution.Low);
    }

    public void EnableMediumShadowResolution()
    {
        SetShadowResolution(LightShadowResolution.Medium);
    }

    public void EnableHighShadowResolution()
    {
        SetShadowResolution(LightShadowResolution.High);
    }

    private void SetShadowResolution(LightShadowResolution shadowResolution)
    {
        var resolution = 256;
        switch(shadowResolution)
        {
            case LightShadowResolution.Low:
                break;
            case LightShadowResolution.Medium:
                resolution = 512;
                break;
            case LightShadowResolution.High:
                resolution = 1024;
                break;
            default:
                break;
        }

        directionalLight.GetComponent<HDAdditionalLightData>().SetShadowResolution(resolution);
        foreach (var light in spotLights) { light.GetComponent<HDAdditionalLightData>().SetShadowResolution(resolution); }
        foreach (var light in pointLights) { light.GetComponent<HDAdditionalLightData>().SetShadowResolution(resolution); }
        Debug.Log(shadowResolution);

    }


    private void EnableSpotLights(bool isEnabled)
    {
        foreach(var light in spotLights) { light.enabled = isEnabled; }
    }

    private void EnablePointLights(bool isEnabled)
    {
        foreach (var light in pointLights) { light.enabled = isEnabled; }
    }

    private void EnableDirectionalLight(bool isEnabled)
    {
         directionalLight.enabled = isEnabled;
    }
}
