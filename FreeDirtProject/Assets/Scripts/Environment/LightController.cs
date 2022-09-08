using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public RobotController robotController;
    public List<Light> lightsList = new List<Light>();
    public Light adjustableLight;
    public List<float> lightLevels = new List<float>{ 0f, .5f, 1f, 1.5f, 2f };
    public List<int> robotLightLevels = new List<int> { 0, 75, 125, 175, 225 };
    int currentLevel = 0;

    private void Start()
    {
        adjustableLight.intensity = lightLevels[2];
        currentLevel = lightLevels.IndexOf(adjustableLight.intensity);
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

    public void SetLightLevel(int level)
    {
        if(level >= 0 && level < lightLevels.Count) {
            adjustableLight.intensity = lightLevels[level];
            robotController.ChangeLightLevel(robotLightLevels[level]);
            Debug.Log("Changing light level to: " + level);
        }
        currentLevel = lightLevels.IndexOf(adjustableLight.intensity);
    }

    //If no arguement is sent with the !brightness command, the light level
    //cycles up until it reaches max and then it cycles back down. 
    public void CycleLightLevel() 
    {
        if(currentLevel < (lightLevels.Count - 1)) {
            adjustableLight.intensity = lightLevels[(currentLevel + 1)];
            robotController.ChangeLightLevel(robotLightLevels[currentLevel + 1]);
            currentLevel++;
        }
        else {
            adjustableLight.intensity = lightLevels[0];
            robotController.ChangeLightLevel(robotLightLevels[0]);
            currentLevel = 0;
        }
    }
}
