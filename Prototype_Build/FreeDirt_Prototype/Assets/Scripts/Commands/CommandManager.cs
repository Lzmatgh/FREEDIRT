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
    public LightController lightController;
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
            "!turn",
            "!light",
            "!l",
            "!lightlevel",
            "!ll",
            "!level"
        };
        return commands;
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

        if (command == "!turn")
        {
            if (argCount == 1)
            {
                robotController.ExecuteTurn();
            }
            else if (argCount == 2)
            {
                robotController.ExecuteTurn(cmd.args[1]);
            }
            else if (argCount == 3)
            {
                robotController.ExecuteTurn(cmd.args[1], Int32.Parse(cmd.args[2]));
            }
            else
            {
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
        else if (command == "!light") {
            if (argCount == 2) {
                lightController.ToggleLight(Int32.Parse(cmd.args[1]));
            }
            else if (argCount == 3) {
                lightController.ToggleLight(Int32.Parse(cmd.args[1]), cmd.args[2]);
            }
            else {
                Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
            }
        }
        else if (command == "!lightlevel") {
            if (argCount == 2) {
                lightController.LightLevel(Int32.Parse(cmd.args[1]));       
            }
        }
    }
}
