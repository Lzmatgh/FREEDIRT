using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

/*
 * Camera Commands hold all the information about the cameras in use as one object
 * including GameObject name, number in the public list, and the GameObject itself and
 * all of those properties.
 * They can be made and used in the CameraController to change the properties of scene cameras. 
 */
public class CameraCommand
{
    Camera cameraGameObject = null;
    int cameraNum = 0;
    string cameraPlace = null;

    public CameraCommand(Camera cam, int num)
    {
        cameraGameObject = cam;
        cameraNum = num;
        cameraPlace = cam.name; 
    }

    public new string ToString
    {
        get
        {
            string info = cameraNum + " " + cameraPlace;
            return info;
        }
    }
}
