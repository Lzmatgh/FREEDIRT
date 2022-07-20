using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using MarksAssets.LaunchURLWebGL;
/*
 * This is for testing webconnections and robot controls. This script is 
 * bound to buttons in the WebTesting Scene and send signals to the webpages
 * in order to move the robot. As we build out we can also test parameters 
 * here for distance/speed/timing for the robot without having to use
 * Twitch commands. 
 */

public class WebAccessTest:MonoBehaviour 
{
    public string unitySite = "https://unity.com/";
    public string youtube = "https://www.youtube.com/";
    public string twitch = "https://www.twitch.tv/stingreay99";
    public LaunchURLWebGL launcher;

    public TMP_Text url1;
    public TMP_Text url2;
    public TMP_Text url3;

    public string forwardURL = "";
    public string backwardURL = "";
    public string leftURL = "";
    public string rightURL = "";
    public string stopURL = "";

    UnityWebRequest webHandler;

    public TMP_Text robotCommandText;

    void Start()
    {
        url1 = null;
        url2 = null;
        url3 = null;
        
    }

    public void TestPrint(string testmessage)
    {
        print(testmessage);
    }

    // These are problematic because they open a new tab every command, which we don't want.
    // We'll have to access the webpage without loading it with php or something. 
    public void OpenBrowserURL(string url)
    {
        if (url1 != null) {
            TestPrint("Attemptng to open: " + url1.text);
            Application.OpenURL(url1.text); 
        }
        else {
            TestPrint("Attemptng to open: https://unity.com/");
            Application.OpenURL(unitySite);
        }
    }

    public void TestAccess()
    {
        if (url3 != null) {
            TestPrint("Attemptng to access: " + url3.text);
            //Application.ExternalEval("window.open('" + url3.text + "','_self')");

            //launcher.launchURLSelf(url3.text);
            launcher.OpenURL(url3.text);
        }
        else {
            TestPrint("Attemptng to open: https://twitch.tv/");
            //launcher.OpenURL(twitch);
            launcher.launchURLBlank(twitch);
            //Application.ExternalEval("window.open('" + twitch + "','_self')");
        }
    }

    public void AccessURL(string url)
    {
        Application.OpenURL(url);
        //launcher.launchURLSelf(url);
        //webHandler.url = url;
        //TestPrint("Attempting to access: " + url);
        //webHandler.SendWebRequest();
    }

    //IEnumerator TestRequest(string url)
    //{
    //    //using (UnityWebRequest webHandler = new UnityWebRequest.Get(url)) ;
    //    webHandler.url = url;

    //    yield return webHandler.SendWebRequest();

    //    if(webHandler.isNetworkError || webHandler.isHttpError) {
    //        Debug.Log(webHandler.error);
    //    }
    //}

    public void TestForwardMovement()
    {
        AccessURL(forwardURL);  
        robotCommandText.text = "Forward";
        print("Testing move forward");
    }

    public void TestBackwardMovement()
    {
        AccessURL(backwardURL);
        robotCommandText.text = "Backward";
        print("Testing move backwards");
    }

    public void TestTurnLeft()
    {
        AccessURL(leftURL);
        robotCommandText.text = "Left";
        print("Testing turn left.");
    }

    public void TestTurnRight()
    {
        AccessURL(rightURL);
        robotCommandText.text = "Right";
        print("Testing turn right.");
    }

    public void TestStop()
    {
        AccessURL(stopURL);
        robotCommandText.text = "Stop";
        print("Testing stop all movement");
    }
}
