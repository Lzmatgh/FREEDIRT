using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A test script to test commands without needing to use the Twitch Chat.
 */
public class CommandTestWithoutTwitch : MonoBehaviour
{
    public CommandManager commandManager;
    string user = "Spencer";

    // Start is called before the first frame update
    void Start()
    {
        //TestCommandMessage("!move forward 4", "!move");
        //TestCommandMessage("!move left 42", "!move");
        //TestCommandMessage("!move backward 9", "!move");
        //TestCommandMessage("!move right 600", "!move");
        //TestCommandMessage("!move left 600", "!move");
        // TestCommandMessage("!move forward 7", "!move");

    }

    public void TestCommandMessage(string msg, string cmd)
    {
        Debug.Log("TESTING COMMAND: " + msg);
        ChatMessage messageToExecute = new ChatMessage(user, msg, cmd);
        //commandManager.testCommand(messageToExecute);
    }
}
