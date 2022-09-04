using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;
using System.ComponentModel;
using UnityEngine.UI;
using TMPro;
using Uduino;

public class RobotController : MonoBehaviour
{
    public Uduino.UduinoManager uduinoManager;
    private State high = State.HIGH;
    private State low = State.LOW;
    
    //Used pins: gpio0-D3, gpio13-D7, gpio16-D0, gpio2-D4
    //Lights D5, D6, S3 (pwm)
    //Pins are declared by pin number itself. 
    int leftForward = 0; //D3
    int rightForward = 16; //D0
    int leftBackward = 13;  //D4
    int rightBackward = 2; //D7

    int light1 = 14; //D5
    int light2 = 12; //D6
    int lightPmw = 10; //SD3

    //Increments are measured in seconds.
    const int DEFAULT_INCREMENT = 5;
    float moveTime = 0;
    bool moving = false;

    //Idles the robot to keep everything awake.
    public float DEFAULT_TIME_TIL_IDLE = 10; //Sets the amount of time before it performs an idle movement;
    public float DEFAULT_IDLE_DURATION = 3;
    float timeUntilIdle;
    float idleTimer; 
    bool idling = false;
    bool turningLeft = false;

    float lightTimer = 20;
    bool dimming = true;
    int idleLightPulseLevelLow = 50;
    int idleLightLevelCurrent = 150;
    int idleLightPulseLevelHigh = 150;


    //public void digitalWrite(int pin, State state = State.LOW, string bundle = null)
    private void Update()
    {
        if (moveTime > 0) {
            moveTime -= Time.deltaTime;
            moving = true;
        }
        else if(moveTime <= 0 && moving == true){
            Reset();
            moveTime = 0;
            moving = false;
        }

        //if(idling) {
        //    idleTimer -= Time.deltaTime;
        //    //Turn back right
        //    if(idleTimer <= 0 && idleTimer > -2.0f) {
        //        if(turningLeft) {
        //            MoveStop();
        //            TurnRobot("right", 2.0f);
        //            //Debug.Log("Idling robot right");
        //            turningLeft = false;
        //        }
        //    }
        //    if (idleTimer <= -2.0f) 
        //    {
        //        MoveStop();
        //        idling = false;
        //        timeUntilIdle = DEFAULT_TIME_TIL_IDLE;
        //        idleTimer = DEFAULT_IDLE_DURATION;
        //        Debug.Log("Stopping idle");
        //    }

        //}

        ////When timer is up, start idle movement.
        //if(timeUntilIdle > 0 && !idling) {
        //    timeUntilIdle -= Time.deltaTime;
        //    idling = false;
        //}
        //else if(timeUntilIdle <= 0) {
        //    idleTimer = 2.0f;
        //    idling = true;
        //    TurnRobot("left", 2.0f);
        //    Debug.Log("Starting idle movement");
        //    turningLeft = true;
        //}

    }

    private void PulseIdleLight()
    {
        if(lightTimer > 0 && dimming) {
            lightTimer -= Time.deltaTime;
            dimming = false;
        }
        if(!dimming) {
            lightTimer += Time.deltaTime;
            
        }

    }

    private void Start()
    {
        uduinoManager.pinMode(leftForward, PinMode.Output);
        uduinoManager.pinMode(rightForward, PinMode.Output);
        uduinoManager.pinMode(leftBackward, PinMode.Output);
        uduinoManager.pinMode(rightBackward, PinMode.Output);
        uduinoManager.pinMode(light1, PinMode.Output);
        uduinoManager.pinMode(light2, PinMode.Output);
        uduinoManager.pinMode(lightPmw, PinMode.PWM);

        //Set the light to the correct default outputs. Changing lightPmw
        //will control the brightness, between 0-255. 
        uduinoManager.digitalWrite(light1, high);
        uduinoManager.digitalWrite(light2, low);
        uduinoManager.digitalWrite(lightPmw, 155);

        timeUntilIdle = DEFAULT_TIME_TIL_IDLE;
        idleTimer = DEFAULT_IDLE_DURATION;
    }

    public void MoveForward()
    {
        Debug.Log("Sending arduino MoveForward");
        uduinoManager.digitalWrite(leftBackward, low);
        uduinoManager.digitalWrite(rightBackward, low);
        uduinoManager.digitalWrite(leftForward, high);
        uduinoManager.digitalWrite(rightForward, high);

    }

    public void MoveBackward()
    {
        Debug.Log("Sending arduino MoveBackward");
        uduinoManager.digitalWrite(leftForward, low);
        uduinoManager.digitalWrite(rightForward, low);
        uduinoManager.digitalWrite(leftBackward, high);
        uduinoManager.digitalWrite(rightBackward, high);
    }

    public void MoveLeft()
    {
        Debug.Log("Sending arduino MoveLeft");
        uduinoManager.digitalWrite(leftForward, low);
        uduinoManager.digitalWrite(rightBackward, low);
        uduinoManager.digitalWrite(rightForward, high);
        uduinoManager.digitalWrite(leftBackward, high);


    }

    public void MoveRight()
    {
        Debug.Log("Sending arduino MoveRight");
        uduinoManager.digitalWrite(leftBackward, low);
        uduinoManager.digitalWrite(rightForward, low);
        uduinoManager.digitalWrite(leftForward, high);
        uduinoManager.digitalWrite(rightBackward, high);
    }

    public void MoveStop()
    {
        Debug.Log("Sending arduino Stop");
        uduinoManager.digitalWrite(leftForward, low);
        uduinoManager.digitalWrite(rightForward, low);
        uduinoManager.digitalWrite(leftBackward, low);
        uduinoManager.digitalWrite(rightBackward, low);
    }


    /* Resets all pins to State.LOW */
    public void Reset()
    {
        Debug.Log("Resetting");
        uduinoManager.digitalWrite(leftForward, high);
        uduinoManager.digitalWrite(rightForward, high);
        uduinoManager.digitalWrite(leftBackward, high);
        uduinoManager.digitalWrite(rightBackward, high);
        MoveStop();
    }

    public void ExecuteMove(string direction = "forward", float increment = DEFAULT_INCREMENT)
    {
        Debug.Log("ExecuteMove() - Direction: '" + direction + "' Units: " + increment);
        if (direction == "forward" || direction == "backward") {
            DriveRobot(direction, increment);
        }
        else if (direction == "left" || direction == "right") {
            ExecuteTurn(direction, increment);
        }
        else {
            Debug.Log(direction + " is not a valid input.");
        }
    }

    public void ExecuteTurn(string direction = "right", float increment = 90)
    {
        Debug.Log("ExecuteMove() - Direction: '" + direction + "' Units: " + increment);
        if (direction == "left" || direction == "right") {
            TurnRobot(direction, increment);
        }
        else {
            Debug.Log(direction + " is not a valid input.");
        }
    }

    /* Helper function for ExecuteMove() */
    public void DriveRobot(string moveDirection, float time)
    {
        if(moveDirection == "forward") {
            MoveForward();
        }
        else if (moveDirection == "backward") {
            MoveBackward();
        }
        else {
            Debug.Log("Recieved invalid move direction.");
        }
        moveTime = time;
        moving = true;
        Debug.Log("Moved the robot " + moveDirection + " " + time + " units");
    }

    /* Helper function for ExecuteMove() */
    public void TurnRobot(string rotateDirection, float time)
    {
        if (rotateDirection == "right") {
            MoveRight();
        }
        else if (rotateDirection == "left") {
            MoveLeft();
        }
        else {
            Debug.Log("Recieved invalid turn direction.");
        }
        moveTime = time;
        moving = true;
        Debug.Log("Rotated the robot " + rotateDirection + " " + time + " units");
    }
}
