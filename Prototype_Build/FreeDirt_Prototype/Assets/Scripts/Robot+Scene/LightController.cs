using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public List<Light> lightsList = new List<Light>();
    public Light adjustableLight;

    private void Start()
    {
        int counter = 0;
        foreach(Light light in lightsList) {
            LightCommand lightCommand = new LightCommand(light, counter);
;        }
    }
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

    public void LightLevel(int level)
    {
        float FLevel = (float) level;
        if(level >= 0 && level < 5) {
            adjustableLight.intensity = FLevel * .5f;
        }
    }
}
