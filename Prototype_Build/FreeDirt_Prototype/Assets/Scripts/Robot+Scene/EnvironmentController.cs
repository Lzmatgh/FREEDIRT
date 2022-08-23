using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnvironmentController : MonoBehaviour
{
    private float timer;
    private bool isRising = true;
    public float dayCycleHours = 8; //The total hour cycle. This is sun to sun up. 
    public float[] cycleIntensity = { 0.1f, 0.2f, .5f, .8f, 1.0f}; //The stages of 'day time' intensity
    public float noonIntensity = 1f;
    public float nightIntensity = 0.1f;
    private int intensityCounter = 0;
    public Light sunLight;
    
    public GameObject rainObject;
    public Light lightningLight;
    private float lightningTimer = 0;
    private bool isRaining = true;
    private bool striking = false;
    private float strikingTimer = 0;
    private float lightningIncrement; //Time between lightning flashes.
    public float maxLightningIncrement = 600; //Max seconds between last lightning flash and next.
    public float flashSpeed = 0.5f;

    void Start()
    {
        lightningLight.enabled = false;
        lightningIncrement = maxLightningIncrement;
        print("Day cycle starting: " + dayCycleHours + " hours.");
        dayCycleHours = dayCycleHours / 2; //Converts the dayCycleHours to have the zenith point
        dayCycleHours = dayCycleHours * 3600; //Converts the dayCycleHours to seconds, which the timer is counting.
        dayCycleHours = dayCycleHours / cycleIntensity.Length; //Creates the increment period between light intensity changes.
    }

    void Update()
    {
        timer += Time.deltaTime;
        lightningTimer += Time.deltaTime;
        strikingTimer += Time.deltaTime;

        if(timer >= dayCycleHours) {
            LightCycle();
            timer = 0;
        }
        if(isRaining) {
            if(lightningTimer >= lightningIncrement) {
                LightningFlash();
                lightningTimer = 0;
            }
            if(strikingTimer >= flashSpeed) {
                lightningLight.enabled = false;
            }
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
            Debug.Log("Invalid state asked for.");
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

    void LightningFlash()
    {
        print("Lightening strike.");
        lightningLight.enabled = true;
        strikingTimer = 0.0f;
        lightningIncrement = (1 * Random.Range(0f, maxLightningIncrement));
        //print(lightningIncrement);
    }


    //public IEnumerator LightningFlash()
    //{
    //    float waitTime = flashSpeed / 2;
    //    // Get half of the seconds (One half to get brighter and one to get darker)
    //    while(lightningLight.intensity < maxIntensity) {
    //        lightningLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
    //        yield return null;
    //    }
    //    while(lightningLight.intensity > 0) {
    //        lightningLight.intensity -= Time.deltaTime / waitTime;        //Decrease intensity
    //        yield return null;
    //    }
    //    yield return null;
    //}

    void LightCycle()
    {
        //Adjusting daylight cycle.
        //If isRising, light will brighten from 0 to 5.
        if(isRising) {
            intensityCounter++;
            if(intensityCounter >= (cycleIntensity.Length - 1)) {
                isRising = false;
            }
        }
        else { 
            intensityCounter--;
            if(intensityCounter <= 0) {
                isRising = true;
            }
        }
        sunLight.intensity = cycleIntensity[intensityCounter];
    }
}
