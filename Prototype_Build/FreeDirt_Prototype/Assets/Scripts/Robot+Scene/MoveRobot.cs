using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This script is attached to the Robot GameObject. This moves the 
 * physical robot and is controlled by the CommandManager script. 
 * Rotation takes degPerSec which sets rotation speed, and converts 
 * user inputted degrees into seconds into rotation. 
 * Translation does the same with movement.
 * The user inputs the command in units (meters by default) and MoveRobot
 * converts that into seconds of movement at the predefined speed. 
 */
public class MoveRobot : MonoBehaviour
{
    //public GameObject targetLocation;
    GameObject robot;
    
    public float dist;
    public float distPerSec;
    public float degrees;
    public float degPerSec;

    private const int DEFAULT_INCREMENT = 6;

    private float distanceRemaining;
    private float rotationRemaining;

    Vector3 direction;
    float translateTime;
    bool movable;
    bool moving;

    float rotateTime;
    int rotateDir;
    bool rotatable = true;
    bool rotating = false;

    Rigidbody robotRB;

    void Start()
    {
        robot = new GameObject();
    }

    public void FixedUpdate()
    {
        
        if (movable)
        {
            if (translateTime > 0)
            {
                transform.Translate(direction * (Time.deltaTime * distPerSec));
                //Countdown timer to stop the rotation after a certain number of seconds (degrees).
                translateTime -= Time.deltaTime;
            }
        }

        if (rotatable)
        {
            if (rotateTime > 0)
            {
                //This sets the rotation speed in degrees per second. Defaulted to 180 degrees per second.
                transform.Rotate(Vector3.up * (rotateDir * (Time.deltaTime * degPerSec)));
                //Countdown timer to stop the rotation after a certain number of seconds (degrees).
                rotateTime -= Time.deltaTime;
            }
        }
        
    }

    //Forces the robot to stop all movement upon contact with restricted area via collider. 
    private void OnTriggerEnter(Collider col)
    {
        movable = false;
        rotatable = false;
        Translate("backward", 0.25f);
    }

    private void OnTriggerExit(Collider col)
    {
        movable = true;
        rotatable = true;
    }

    /* Helper function for ExecuteMove() */
    public void Translate(string dirString, float dist)
    {
        if (dirString == "forward")
        {
            direction = new Vector3(1, 0, 0);
        }
        else if (dirString == "backward")
        {
            direction = new Vector3(-1, 0, 0);
        }
        movable = true;
        translateTime = dist / distPerSec;
        Debug.Log("Moved the object " + direction + " " + dist + " units");
    }
    
    /* Helper function for ExecuteMove() */
    public void Rotate(string comRotateDirection, float degrees)
    {
        if(comRotateDirection == "right")
        {
            rotateDir = 1;
        }
        else if (comRotateDirection == "left")
        {
            rotateDir = -1;
        }
        rotatable = true;
        rotateTime = degrees / degPerSec;
        Debug.Log("Rotated the object " + direction + " " + degrees + " units");
    }

    // Executes
    public void ExecuteMove(string direction = "forward", float increment = DEFAULT_INCREMENT)
    {
        Debug.Log("ExecuteMove() - Direction: '" + direction + "' Units: " + increment);
        if (direction == "forward" || direction == "backward")
        {
            Translate(direction, increment);
        }
        else if (direction == "left" || direction == "right")
        {
            Rotate(direction, increment);
        }
        else {
            Debug.Log(direction+  " is not a valid input.");
        }
    }
}
