using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * The CommandManager is what takes the twitch commands, validates them, and sends them to the respective class to be executed.
 * 
 * To add commands, the trigger string is added to the addCommands method list. Then add an ExecuteCommand line to trigger
 * the actual class for that command. Finally, create a class and method for the command to be carried out. 
 */
public class CommandManager : MonoBehaviour 
{
    public MoveRobot robotController;
    public CameraController cameraController;
    public TwitchChat twitchChat;
    public List<string> validCommands;

    void Start()
    {    
        validCommands = new List<string>();
        validCommands = addCommands();
        if(validCommands.Count > 0) {
            Debug.Log("Controller is accepting: '" + validCommands.Count + "' commands.");
        }
        else {
            Debug.Log("No commands marked as valid");
        }
    }

    /* Instantiates the list of valid Twitch commands. */
    public List<string> addCommands()
    {
        List<string> commands = new List<string>
        {
            "!move",
            "!m",
            "!camera",
            "!c",
            "!color",
            "!co"
        };
        return commands;
    }

    
    // Listens to the Twitch Chat for a user message with a command denoted by '!'
    public void Update()
    {

    }

    public void ReadFromTwitch(ChatMessage chatMessage)
    {
        if (chatMessage != null) {
            if (validCommands.Contains(chatMessage.command)) {
                Command cmdFromTwitch = new Command(chatMessage);
                Debug.Log("Message with valid command recieved: " + cmdFromTwitch.message);
                //Debug.Log("Twitch read message+command: " + cmdFromTwitch.message);
                ExecuteCommand(cmdFromTwitch);
            }
            else {
                Debug.Log("Message with invalid command recieved.");
            }
        }
        else {
            Debug.Log("No message Recieved");
        }
    }
    
    /*
    // Takes in a chat message when one with a potential command is picked up with '!' and verifies its a command.
    // It then sends off that command by parsing through the message string after the '!' and sending it to be executed.
    public void testCommand(ChatMessage chatMessage)
    {
        validCommands = addCommands(validCommands);
        if (validCommands.Contains(chatMessage.command)) {
            inputCommand = new Command(chatMessage);
            //inputCommand.args = ParseCommandArgs(chatMessage, inputCommand);
            ExecuteCommand(inputCommand);
        }
    }
    */
    
    // Breaks up the message after the '!' into the command and parameters for the command.
    //public List<string> ParseCommandArgs(ChatMessage chatMessage, Command inputCommand)
    //{
    //    string[] splitMessage = chatMessage.message.Split();
    //    if(splitMessage.Length > 1) {
    //        for(int i = 0; i < splitMessage.Length; i++) {
    //            inputCommand.args.Add(splitMessage[i]);
    //        }
    //    }
    //    return inputCommand.args;
    //}

    // Sends the command to the appropriate command class to be executed in the Unity scene. 
    public void ExecuteCommand(Command cmd)
    {
        int argCount = cmd.args.Count;
        string command = cmd.args[0];
        string user = cmd.user;

        Debug.Log("User: " + user + " attempting to issue command: " + command + "...");

        if (command == "!move") {
            if (argCount == 1) {
                robotController.ExecuteMove();
            }
            else if (argCount == 2) {
                robotController.ExecuteMove(cmd.args[1]);
            }
            else if (argCount == 3) {
                robotController.ExecuteMove(cmd.args[1], Int32.Parse(cmd.args[2]));
            }
            else {
                Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
            }
        }

        else if (command == "!camera") {
            //This will have to change if we make more than the SwitchCamera function. It should be set up to
            //change fairly quickly though. Remove the first cameraController.SwitchCamera() and add a 
            //condition to the argCount == 1 (&&....).
            if (cmd.args[1] == "switch") {
                if (argCount == 2) {
                    cameraController.SwitchCamera(1);
                }
                else if (argCount == 3) {
                    cameraController.SwitchCamera(Int32.Parse(cmd.args[2]));
                }
                else {
                    Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
                }
            }
            else {
                //TODO:
                //Reply to chat with camera list.
            }
            Debug.Log("!camera command activated.");
        }
            
        else if(command == "!color") {

        }
    }

    /*

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
    */
}
