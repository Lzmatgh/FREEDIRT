using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;


public class ConfigManager : MonoBehaviour
{
    public TMP_InputField channelName;
    public TMP_InputField userName;
    public TMP_InputField oauthPass;

    public TMP_Text cameras;

    string _newPath = "Assets/connection_info.txt";
    string _defaultPath = "Assets/connection_info_default.txt";

    public TwitchConnectionTest connectionTest;
    public Toggle defaultToggle;

    void Start()
    {
        defaultToggle.onValueChanged.AddListener(delegate {
            SwitchInputs(defaultToggle);
        });
        WriteDefaultValues();
        WriteCameras();
    }
    
    void SwitchInputs(bool defaultVals)
    {
        if(defaultToggle.isOn) {
            print("Setting default values.");
            WriteDefaultValues();
        }
        else {
            print("Writing custom values.");
            WriteConfig();
        }
    }

    public void WriteDefaultValues()
    {
        StreamWriter writer = new StreamWriter(_newPath, false);
        StreamReader reader = new StreamReader(_defaultPath);
        channelName.text = reader.ReadLine();
        userName.text = reader.ReadLine();
        oauthPass.text = reader.ReadLine();
        writer.WriteLine(channelName.text);
        writer.WriteLine(userName.text);
        writer.WriteLine(oauthPass.text);
        reader.Close();
        writer.Close();
    }

    public void WriteConfig()
    {
        print("Writing config file.");
        print(channelName.text);
        print(userName.text);
        print(oauthPass.text);

        StreamWriter writer = new StreamWriter(_newPath, false);
        writer.WriteLine(channelName.text);
        writer.WriteLine(userName.text);
        writer.WriteLine(oauthPass.text);
        writer.Close();
    }   

    public void Connect()
    {
        print("Connecting to Twitch using info in config file.");
        if(defaultToggle.isOn) {
            WriteDefaultValues();
        }
        else {
            WriteConfig();
        }
        connectionTest.Connect();
    }

    void WriteCameras()
    {
        print("Finding cameras and printing them to the screen.");
        WebCamDevice[] devices = WebCamTexture.devices;

        for (int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name + i);
            cameras.text += (devices[i].name + "\n");
        }
    }

    void SceneChange()
    {
        print("Starting FREE DIRT.");
    }
}
