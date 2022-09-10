using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

/*
 * The Command structure makes a command with the user and the message and the command parameters
 * to be made into a specific command after being parsed for the valid command. 
 */
public class Command
{
    public string user;
    public string message;
    public List<string> args;

    public Command(ChatMessage chatMessage) 
    {
        user = chatMessage.user;
        message = chatMessage.message;
        args = new List<string>();
        
        ParseCommandArgs(chatMessage);
    }

    //Parse through the command sent from the message and sends the componants of the message to a list. 
    public void ParseCommandArgs(ChatMessage chatMessage)
    {
        string[] splitMessage = chatMessage.message.Split();
        Debug.Log("Parsing Commands: ");
        if (splitMessage.Length >= 0) {
            for(int i = 0; i < splitMessage.Length; i++) {
                this.args.Add(splitMessage[i]);
            }
        }
        PrintCommandArgs();
    }

    public void PrintCommandArgs()
    {
        for (int i = 0; i < args.Count; i++) {
            Debug.Log(i + ": " + args[i]);
        }
    }

}
