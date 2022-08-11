using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;
using System.ComponentModel;
using UnityEngine.UI;
using TMPro;

public class RobotController : MonoBehaviour
{
    public ArduinoController arduino;
    public Button forwardBtn;
    public Button backwardBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Button stopBtn;
    private char commandChar = '!';

    private void Update()
    {
        arduino.WriteSocket(commandChar);
    }

    public void MoveForward()
    {
        print("Sending arduino MoveForward (char == f)");
        commandChar = 'f';
        arduino.WriteSocket('f');
  
    }

    public void MoveBackward()
    {
        print("Sending arduino MoveBackward (char == b)");
        commandChar = 'b';
        arduino.WriteSocket('b');

    }

    public void MoveLeft()
    {
        print("Sending arduino MoveLeft (char == l)");
        commandChar = 'l';
        arduino.WriteSocket('l');
    }

    public void MoveRight()
    {
        print("Sending arduino MoveRight (char == r)");
        commandChar = 'r';
        arduino.WriteSocket('r');
    }

    public void MoveStop()
    {
        print("Sending arduino MoveForward (char == s)");
        commandChar = 's';
        arduino.WriteSocket('s');
    }
}
