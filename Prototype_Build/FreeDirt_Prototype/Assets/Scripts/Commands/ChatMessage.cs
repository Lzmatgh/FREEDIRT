using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChatMessage
{
    public string user;
    public string message;
    public string command;

    public ChatMessage(string user, string message, string command)
    {
        this.user = user;
        this.message = message;
        this.command = command;
    }

    public ChatMessage()
    {
        this.user = null;
        this.message = null;
        this.command = null;
    }
}
