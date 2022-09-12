using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using TMPro;

public class EnvironmentController : MonoBehaviour
{
    public float dayCycleHours = 8; //The total hour cycle. This is sun to sun up. 
    public float intensityIncrement = .01f;
    private float intensityInterval = 0;
    public float noonIntensity = 1f;
    public float nightIntensity = 0.1f;
    private bool afterNoon = true;
    public Light sunLight;
    public TMP_Text intensityText;
    
    //Storm variables
    public GameObject rainObject;
    public Light lightningLight;
    public float lightningIntensity = 1;
    private float lightningTimer = 0;
    private bool isRaining = true;
    private bool striking = false;
    private float lightningIncrement; //Time between lightning flashes.
    public float maxLightningIncrement = 600; //Max seconds between last lightning flash and next.

    void Start()
    {
        lightningLight.enabled = false;
        lightningIncrement = maxLightningIncrement;
        print("Day cycle starting: " + dayCycleHours + " hours.");
        dayCycleHours = dayCycleHours / 2; //Converts the dayCycleHours to have the zenith point
        dayCycleHours = dayCycleHours * 3600; //Converts the dayCycleHours to seconds, which the timer is counting.
        intensityInterval = dayCycleHours / ((noonIntensity - nightIntensity) /intensityIncrement) ; //How often to increment the sun intensity in seconds. 
        StartCoroutine(DayCycle());
        lightningIncrement = (1 * Random.Range(0f, maxLightningIncrement));
    }

    void Update()
    {
        if(isRaining) {
            
        }

        intensityText.text = sunLight.intensity + "";
    }

    private IEnumerator DayCycle()
    {
        while(true) {
            if(afterNoon) {
                sunLight.intensity -= intensityIncrement;
                if(sunLight.intensity <= nightIntensity) {
                    afterNoon = false;
                }
            }
            else {
                sunLight.intensity += intensityIncrement;
                if(sunLight.intensity >= noonIntensity) {
                    afterNoon = true;
                }
            }
            yield return new WaitForSeconds(intensityInterval);
        }
        
    }

    //Takes  the !rain command with no argument to toggle it to the 
    //opposite state. 
    public void ToggleRain()
    {
        if(rainObject.activeSelf) {
            ResetRain();
        }
        else {
            rainObject.SetActive(true);
            isRaining = true;
            LightningFlash();
            print("Starting rain.");
        }
    }
    
    //Allows for the viewer to call toggle rain to a specific status.
    //This could also be used to 
    public void ToggleRain(string status)
    {
        if(status == "stop") {
            ResetRain();
        }
        else if(status == "start") {
            LightningFlash();
            rainObject.SetActive(true);
        }
        else {
            Debug.Log("Invalid rain state requested.");
        }
    }

    void ResetRain()
    {
        print("Stopping rain.");
        rainObject.SetActive(false);
        isRaining = false;
        lightningLight.enabled = false;
        lightningTimer = 0;
    }

    IEnumerator LightningSequence()
    {
        // Get half of the seconds (One half to get brighter and one to get darker)
        while(lightningLight.intensity < lightningIntensity) {

        }
        while(lightningLight.intensity > 0) {

        }
        yield return null;
    }

    IEnumerator LightningFlash()
    {
        while(striking) {
            if(lightningLight.intensity == 0) {
                striking = false;
            }
            else {
                lightningLight.intensity -= 0.05f;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

}
