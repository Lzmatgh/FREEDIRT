using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public List<Light> lightsList = new List<Light>();
    public Light adjustableLight;
    // Start is called before the first frame update
    public void ToggleLight(int lightNum)
    {

        if (lightNum <= lightsList.Count && lightNum > 0) {
            foreach (Light light in lightsList) {
                if (light.enabled) {
                    light.enabled = false;
                }
                else {
                    light.enabled = true;
                }
            }
            lightsList[lightNum - 1].enabled = true;
        }
        else {
            Debug.Log("User tried to switch the light to an invalid number");
        }
    }
}
