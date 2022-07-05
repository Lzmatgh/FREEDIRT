using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public GameObject ball;
    Material objectMaterial;
    string command;
    public Material material1;
    public Material material2;
    TwitchChat chat;

    void Start()
    {
        objectMaterial = ball.GetComponent<Renderer>().material;
        chat = gameObject.GetComponent<TwitchChat>();
    }


    public void ActivateCommand(string command) 
    {
        if(command == "!commands") {
            WriteCommands();
        }
        if(command == "!blue") {
            ColorBlue();
        } 
        else if(command ==  "!red") {
            ColorRed();
        }
        else if(command == "!bounce") {
            Bounce();
        }
        else if(command == "!camera") {
            CameraSwitch();
        }
        else if(command == "!up") {
            Move(1);
        }
        else if(command == "!down") {
            Move(-1);
        }
        else if(command == "!right") {
            Move(-2);
        }
        else if(command == "!left") {
            Move(2);
        }
        print("Command Executed: " + command);
    }

    public void WriteCommands()
    {
        print("Writing Commands");
        string commandList = "Commands: \nChange Colors: \n!blue \n!red \nMovement: \n!bounce";
        print(commandList);
        chat.WriteToChat(commandList);
    }

    public void ColorBlue()
    {
        objectMaterial.color = Color.blue;
    }

    public void ColorRed()
    {
        objectMaterial.color = Color.red;
    }

    public void Bounce()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        bool grounded = true;
        if(rb.velocity.y == 0){
            grounded = true;
        } else {
            grounded = false;
        }
        if(grounded) {
           rb.AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse); 
           grounded = false;
        }
    }

    public int moveForce = 10;
    public void Move(int dir) 
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();        
        int x = 0;
        int z = 0;
        if(dir == 1){
            x = moveForce;
        } else if(dir == -1) {
            x = -moveForce;
        } else if(dir == 2) {
            z = moveForce; 
        } else if(dir == -2) {
            z = -moveForce;
        }

        rb.AddForce(new Vector3(x, 0f, z), ForceMode.Impulse);

    }

    public Camera cam1;
    public Camera cam2;
    public void CameraSwitch()
    {
        if(cam1.enabled) {
            cam2.enabled = true;
            cam1.enabled = false;
        }
        else if(cam2.enabled){
            cam1.enabled = true;
            cam2.enabled = false;
        }
    }
}
