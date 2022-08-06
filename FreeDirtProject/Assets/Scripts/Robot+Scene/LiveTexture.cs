using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTexture : MonoBehaviour
{
    public Renderer LiveCam;
    public Renderer MobileCam;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name + i);
        }

        Renderer rend = this.GetComponentInChildren<Renderer>();

        print("Webcam available: " + devices[0].name );
        WebCamTexture cam = new WebCamTexture("NexiGo N60 FHD Webcam", 1920, 1080, 30);
        LiveCam.material.mainTexture = cam;
        cam.Play();
        
        print("Webcam available: " + devices[2].name);
        WebCamTexture mobile = new WebCamTexture(devices[2].name, 1920, 1080, 30);
        MobileCam.material.mainTexture = mobile;
        mobile.Play();
    }
}