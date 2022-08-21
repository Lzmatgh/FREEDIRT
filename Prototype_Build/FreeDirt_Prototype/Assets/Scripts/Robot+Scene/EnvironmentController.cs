using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    float timer;
    bool isRising = true;
    public float dayCycleHours = 8; //The total hour cycle. This is sun to sun up. 
    public float[] cycleIntensity = { 0.1f, 0.2f, .5f, .8f, 1.0f}; //The stages of 'day time' intensity
    public float noonIntensity = 1f;
    public float nightIntensity = 0.1f;
    private int intensityCounter = 0;
    public float lightingFlashSpeed = 0.5f;
    public Light lightingLight;
    public Light sunLight;
    
    public GameObject rainObject;

    void Start()
    {
        print("Day cycle starting: " + dayCycleHours + " hours.");
        dayCycleHours = dayCycleHours / 2; //Converts the dayCycleHours to have the zenith point
        dayCycleHours = dayCycleHours * 3600; //Converts the dayCycleHours to seconds, which the timer is counting.
        dayCycleHours = dayCycleHours / cycleIntensity.Length; //Creates the increment period between light intensity changes.
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= dayCycleHours) {
            LightCycle();
            timer = 0;
        }
    }

    //Takes  the !rain command with no argument to toggle it to the 
    //opposite state. 
    public void ToggleRain()
    {
        if(rainObject.activeSelf) { 
            rainObject.SetActive(false);
        }
        else {
            rainObject.SetActive(true);
        }
    }
    
    //Allows for the viewer to call toggle rain to a specific status.
    //This could also be used to 
    public void ToggleRain(string status)
    {
        if(status == "off") {
            rainObject.SetActive(false);
        }
        else if(status == "on") {
            rainObject.SetActive(true);
        }
        else {
            Debug.Log("Invalid state asked for.");
        }
    }

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
