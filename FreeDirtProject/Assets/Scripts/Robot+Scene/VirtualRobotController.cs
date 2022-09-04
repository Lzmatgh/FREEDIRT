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
public class VirtualRobotController : MonoBehaviour
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
    bool movable = false;

    float rotateTime;
    int rotateDir;
    bool rotatable = false;
    Rigidbody robotRB;

    private Vector3 robotVelocity;
    private float axisMove;
    public float manualSpeed;
    void Start()
    {
        robotRB = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        
        if (movable)
        {
            if (translateTime > 0)
            {
                robotRB.transform.Translate(direction * (Time.deltaTime * distPerSec));
                //Countdown timer to stop the rotation after a certain number of seconds (degrees).
                translateTime -= Time.deltaTime;
            }
        }

        if (rotatable)
        {
            if (rotateTime > 0)
            {
                //This sets the rotation speed in degrees per second. Defaulted to 180 degrees per second.
                robotRB.transform.Rotate(Vector3.up * (rotateDir * (Time.deltaTime * degPerSec)));
                //Countdown timer to stop the rotation after a certain number of seconds (degrees).
                rotateTime -= Time.deltaTime;
            }
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        robotRB.transform.Translate(move * Time.deltaTime * manualSpeed);
        // Right movement (Positive horizontal direction)
    }

    //Forces the robot to stop all movement upon contact with restricted area via collider. 
    private void OnTriggerEnter(Collider col)
    {
        movable = false;
        rotatable = false;
        DriveRobot("backward", 0.25f);
    }

    private void OnTriggerExit(Collider col)
    {
        movable = true;
        rotatable = true;
    }

    /* Helper function for ExecuteMove() */
    public void DriveRobot(string dirString, float dist)
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
    public void TurnRobot(string comRotateDirection, float degrees)
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
            DriveRobot(direction, increment);
        }
        else if (direction == "left" || direction == "right")
        {
            ExecuteTurn(direction, increment);
        }
        else {
            Debug.Log(direction+  " is not a valid input.");
        }
    }

    public void ExecuteTurn(string direction = "right", float increment = 90)
    {
        Debug.Log("ExecuteMove() - Direction: '" + direction + "' Units: " + increment);
        if (direction == "left" || direction == "right")
        {
            TurnRobot(direction, increment);
        }
        else
        {
            Debug.Log(direction + " is not a valid input.");
        }
    }
}
