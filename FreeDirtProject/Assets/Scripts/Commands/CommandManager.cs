using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/*
 * The CommandManager is what takes the twitch commands, validates them, and sends them to the respective class to be executed.
 * 
 * To add commands, the trigger string is added to the addCommands method list. Then add an ExecuteCommand line to trigger
 * the actual class for that command. Finally, create a class and method for the command to be carried out. 
 */
public class CommandManager : MonoBehaviour
{
    public CameraController cameraController;
    public LightController lightController;
    public EnvironmentController environmentController;
    public RobotController robotController;
    public VirtualRobotController virtualRobotController;
    public SeedManager seedManager;
    public TwitchChat twitchChat;
    public List<string> validCommands;
    public bool testMovement = false;
    public HashSet<string> moderators = new HashSet<string> ();
    public HashSet<string> admins = new HashSet<string> { "stingreay99", "leahlipp" };

    private Queue<Command> movementCommandQueue = new Queue<Command>();
    private Queue<Command> generalCommandQueue = new Queue<Command>();
    private List<string> queueStrings = new List<string>();
    private Command nextCommand;
    private Command newCommand;
    public TMP_Text queuedCommands;
    public float executeDelay = 2;


    void Start()
    {
        validCommands = new List<string>();
        validCommands = addCommands();
        foreach(string admin in admins) {
            addMods(admin);
        }
        if(validCommands.Count > 0) {
            Debug.Log("Controller is accepting: '" + validCommands.Count + "' commands.");
        }
        else {
            Debug.Log("No commands marked as valid");
        }
        StartCoroutine(ExecuteMoveCommand());
        StartCoroutine(ExecuteGeneralCommand());
        StartCoroutine(updateCommandQueueDisplay());    
    }

    private void Update()
    {
        if(generalCommandQueue.Count > 0) {
            ExecuteGeneralCommand();
        }
        if(movementCommandQueue.Count > 0) {
            ExecuteMoveCommand();
        }
    }

    IEnumerator updateCommandQueueDisplay()
    {
        while(true) {
            queuedCommands.text = printCommandQueue();
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator ExecuteMoveCommand()
    {
        Command nextMoveCommand;
        print("Starting movement coroutine,");
        while(true) {
            if(movementCommandQueue.Count > 0) {
                nextMoveCommand = movementCommandQueue.Dequeue();
                print(nextMoveCommand.args[0]);
                if(nextMoveCommand != null) {
                    print("Executing general command from queue.");
                    //queuedCommands.text = printCommandQueue();
                    queueStrings.Remove(nextMoveCommand.message);
                    ExecuteCommand(nextMoveCommand);
                    yield return new WaitForSeconds(executeDelay);
                }
                else {
                    Debug.Log("Command is null.");
                    yield return null;
                }

            }
            yield return null;
        }
    }

    IEnumerator ExecuteGeneralCommand()
    {
        Command nextGenCommand;
        print("Starting general coroutine,");
        while(true) {
        if(generalCommandQueue.Count > 0) {
                nextGenCommand = generalCommandQueue.Dequeue();
            print(nextGenCommand.args[0]);
            if(nextGenCommand != null) {
                print("Executing general command from queue.");
                    //queuedCommands.text = printCommandQueue();
                    queueStrings.Remove(nextGenCommand.message);
                    ExecuteCommand(nextGenCommand);
                    yield return new WaitForSeconds(.25f);
            }
            else {
                Debug.Log("Command is null.");
                yield return null;
            }
            }
            yield return null;
        }
    }

    /* Instantiates the list of valid Twitch commands. */
    public List<string> addCommands()
    {
        List<string> commands = new List<string>
        {
            "!move",
            "!camera",
            "!turn",
            "!light",
            "!lightlevel",
            "!brighten",
            "!seed",
            "!commands"
        };
        return commands;
    }

    public string getCommands()
    {
        string allCommands = "Valid Commands: ";
        foreach(string s in validCommands) {
            allCommands = allCommands + " [" + s + "] ";
        }
        Debug.Log(allCommands);
        return allCommands;
    }

    private void addMods(string modName)
    {
        if(modName != null) {
            moderators.Add(modName);
            //twitchChat.WriteToChat("/mod " + modName);
            Debug.Log("Adding mod: " + modName);
        }
    }

    private void OnApplicationQuit()
    {
        foreach(string s in moderators) {
            if(s != null) {
                twitchChat.WriteToChat("/unmod " + s);
                Debug.Log("Unmodding: " + s);
            }
        }
    }

    private string printCommandQueue()
    {
        string qCommandString = "";
        if(queueStrings.Count > 0 && queueStrings.Count < 6) {
            foreach(string s in queueStrings) {
                qCommandString += (s + "\n");
            }
        }
        else if(queueStrings.Count >= 6) {

            for(int i = 0; i < 6; i++) {
                qCommandString += queueStrings[i] + "\n";
            }
        }

        return qCommandString;
    }

    public void AddToCommandQueue(ChatMessage chatMessage)
    {
            if(validCommands.Contains(chatMessage.command)) {
                newCommand = new Command(chatMessage);
                Debug.Log("Message with valid command recieved: " + newCommand.message);
                Debug.Log("Command: " + newCommand.args[0]);
                queueStrings.Add(newCommand.message);
                queuedCommands.text = printCommandQueue();
            if(chatMessage.command == "!move" || newCommand.args[0] == "!turn" ) {
                    movementCommandQueue.Enqueue(newCommand);
                    Debug.Log("Adding to movement queue");
                }
                else {
                    generalCommandQueue.Enqueue(newCommand);
                    Debug.Log("Adding to general queue");
                }
                //Debug.Log("Twitch read message+command: " + cmdFromTwitch.message);
                //ExecuteCommand(cmdFromTwitch);
            }
            else {
                Debug.Log("Message with invalid command recieved.");
            }
    }

    // Sends the command to the appropriate command class to be executed in the Unity scene. 
    public void ExecuteCommand(Command cmd)
    {
        int argCount = cmd.args.Count;
        string command = cmd.args[0];
        string user = cmd.user;

        Debug.Log("User: " + user + " attempting to issue command: " + command + "...");
        queuedCommands.text = printCommandQueue();
        if(command == "!move") {
            if(testMovement) {
                if(argCount == 1) {
                    virtualRobotController.ExecuteMove();
                }
                else if(argCount == 2) {
                    virtualRobotController.ExecuteMove(cmd.args[1]);
                }
                else if(argCount == 3) {
                    if(admins.Contains(user)) {
                        virtualRobotController.ExecuteMove(cmd.args[1], Int32.Parse(cmd.args[2]));
                    }

                }
                else {
                    Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
                }
            }
            else {
                if(argCount == 1) {
                    robotController.ExecuteMove();
                }
                else if(argCount == 2) {
                    robotController.ExecuteMove(cmd.args[1]);
                }
                else if(argCount == 3) {
                    if(admins.Contains(user)) {
                        robotController.ExecuteMove(cmd.args[1], Int32.Parse(cmd.args[2]));
                    }
                }
                else {
                    Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
                }
            }
        }
        else if(command == "!turn") {
            if(testMovement) {
                if(argCount == 1) {
                    virtualRobotController.ExecuteTurn();
                }
                else if(argCount == 2) {
                    virtualRobotController.ExecuteTurn(cmd.args[1]);
                }
                else if(argCount == 3) {
                    if(admins.Contains(user)) {
                        virtualRobotController.ExecuteTurn(cmd.args[1], Int32.Parse(cmd.args[2]));
                    }
                }
                else {
                    Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
                }
            }
            else {
                if(argCount == 1) {
                    robotController.ExecuteTurn();
                }
                else if(argCount == 2) {
                    robotController.ExecuteTurn(cmd.args[1]);
                }
                else if(argCount == 3) {
                    if(admins.Contains(user)) {
                        robotController.ExecuteTurn(cmd.args[1], Int32.Parse(cmd.args[2]));
                    }
                }
                else {
                    Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
                }
            }
        }
        else if(command == "!camera") {
            //This will have to change if we make more than the SwitchCamera function. It should be set up to
            //change fairly quickly though. Remove the first cameraController.SwitchCamera() and add a 
            //condition to the argCount == 1 (&&....).
            if(cmd.args[1] == "switch") {
                if(argCount == 2) {
                    cameraController.SwitchCamera(1);
                }
                else if(argCount == 3) {
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
        // !light will eventually be light spawning, not toggling. 
        else if(command == "!light") {
            if(argCount == 2) {
                lightController.ToggleLight(Int32.Parse(cmd.args[1]));
            }
            else if(argCount == 3) {
                lightController.ToggleLight(Int32.Parse(cmd.args[1]), cmd.args[2]);
            }
            else {
                Debug.LogError("Unexpected number of arguments (" + argCount + ") " + "for command: " + command);
            }
        }
        else if(command == "!lightlevel" || command == "!brighten") {
            if(argCount == 2) {
                lightController.SetLightLevel(Int32.Parse(cmd.args[1]));
            }
            else if(argCount == 1) {
                lightController.CycleLightLevel();
            }
        }
        else if(command == "!rain") {
            if(argCount == 1) {
                environmentController.ToggleRain();
            }
            else if(argCount == 2) {
                environmentController.ToggleRain(cmd.args[1]);
            }
        }
        else if(command == "!seed") {
            seedManager.CreateSeed();
            robotController.DropSeed();
        }
        else if(command == "!commands") {
            twitchChat.WriteToChat(getCommands());
        }
        else {
            Debug.Log("Invalid command recieved.");
        }
    }
}
