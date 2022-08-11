using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCommand : MonoBehaviour
{
    Light lightGameObj = null;
    int lightNum = 0;
    string lightLoc = null;

    public LightCommand(Light light, int num)
    {
        lightGameObj = light;
        lightNum = num;
    }

    public new string ToString
    {
        get
        {
            string info = lightNum + " " + lightLoc;
            return info;
        }
    }
}
