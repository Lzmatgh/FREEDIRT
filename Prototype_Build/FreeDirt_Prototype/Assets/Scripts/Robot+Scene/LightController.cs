using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public List<Light> lightsList = new List<Light>();
    public Light adjustableLight;
    public List<float> lightLevels = new List<float>{ 0f, .5f, 1f, 1.5f, 2f };
    private void Start()
    {
        int counter = 0;
        foreach(Light light in lightsList) {
            LightCommand lightCommand = new LightCommand(light, counter);
;        }
    }

    //Accepts a light number and enables/disables it depending on
    //the previous state of the Light game object. 
    public void ToggleLight(int lightNum)
    {
        if (lightNum <= lightsList.Count && lightNum > 0) {
            if (lightsList[lightNum].enabled == true) {
                lightsList[lightNum].enabled = false;
            }
            else {
                lightsList[lightNum].enabled = true;
            }
        }
        else {
            Debug.Log("User tried to switch the light to an invalid number");
        }
    }

    //Accepts a light number as an in, and the condition on-off
    //and toggles the light to whichever condition is sent. 
    public void ToggleLight(int lightNum, string condition)
    {
        if (lightNum <= lightsList.Count && lightNum > 0) {
            if (condition == "off") {
                lightsList[lightNum].enabled = false;
            }
            else if (condition == "on"){
                lightsList[lightNum].enabled = true;
            }
            else {
                Debug.Log("User sent an invalid light conditon.");
            }
        }
        else {
            Debug.Log("User tried to switch the light to an invalid number");
        }
    }

    //LightLevel is going to take the public list of light levels
    //and allow the chatter to enter a command at any level that is 
    //declared in the game scene. 0 will be off. 

    public void LightLevel(int level)
    {
        float FLevel = (float) level;
        //if(level >= 0 && level < 5) {
        //    adjustableLight.intensity = FLevel * .5f;
        //}

        if(level >= 0 && level < lightLevels.Count) {
            adjustableLight.intensity = lightLevels[level];
        }
    }

    public void Brighten() { 

    }

    public void Darken()
    {

    }


}
