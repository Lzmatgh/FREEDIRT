using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using System;
using System.ComponentModel;
using UnityEngine.UI;
using TMPro;

public class TwitchConnectionTest : MonoBehaviour
{
     string username = "stingreay99";
     string password = "oauth:bgwmlgp1xkzk6fatv4oby6wcn7yso3";
     string channelName = "stingreay99";

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    private float reconnectTimer;
    private float reconnectAfter;

    public CommandManager manager;
    public ChatMessage message;

    public TMP_Text connectedTxt;
    public TMP_Text mess1;
    public TMP_Text mess2;
    public TMP_Text mess3;


    public TMP_Text userInput;
    public TMP_Text oauthInput;
    public TMP_Text channelInput;
    public Button connectBtn;

    // Start is called before the first frame update
    void Start()
    {   

        userInput.text = "stingreay99";
        oauthInput.text = "oauth:bgwmlgp1xkzk6fatv4oby6wcn7yso3";
        channelInput.text = "stingreay99";
        //password = oauthInput.text;
        //username = userInput.text;
        //channelName = channelInput.text;

        reconnectAfter = 10.0f;
    }

    // Connect instantiates twitchClient and connects Unity to the Twitch channel URL
    public void Connect()
    {
        //userInput.GetComponent<Text>().text = "stingreay99";
        //oauthInput.GetComponent<Text>().text = "oauth:bgwmlgp1xkzk6fatv4oby6wcn7yso3";
        //channelInput.GetComponent<Text>().text = "stingreay99";
        //password = oauthInput.GetComponent<Text>().text;
        //username = userInput.GetComponent<Text>().text;
        //channelName = channelInput.GetComponent<Text>().text;

        print("Connecting");
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667); // 1        
        reader = new StreamReader(twitchClient.GetStream()); // 2
        writer = new StreamWriter(twitchClient.GetStream());
        writer.WriteLine("PASS " + password); // 3
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * : " + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.WriteLine("PRIVMSG #" + channelName + " :THE FREE DIRT EXPERIENCE");
        writer.Flush();
        if (twitchClient.Connected) {
            print("Connected!");
            connectedTxt.text = "Connected";
            connectedTxt.color = Color.green;
        }
    }


    // Checks if the Twitch data is available (>0) and gets a message. 
    // If the message is a PRIVMSG its user created and will print to console.
    public void ReadChat()
    {
        if (twitchClient.Available > 0) {
            //print("Client Available");    
            string message = reader.ReadLine();

            // Twitch will ping the program every 5 minutes and requires the response PONG or will disconnect
            if (message.Contains("PING")) {
                writer.WriteLine("PONG");
                writer.Flush();
                //return null;
            }
            // If the message is sent by a user, chop the received message up to get the command.
            if (message.Contains("PRIVMSG")) {
                print(message);

                // Get the username
                int splitPoint = message.IndexOf('!');
                string chatterName = message.Substring(1, splitPoint - 1);

                //Get the full message
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);

                //If the message is or contains a command denoted by a command character (!)
                //set the message command to the string, without spaces, following the command char
                string command = null;
                if (message.Contains("!")) {
                    message = message.ToLower();
                    splitPoint = message.IndexOf("!");
                    command = message.Substring(splitPoint);
                    // This chops the command to only from the ! to the space " " but if the command only wants
                    // to be everything after the command then the following if statement can be removed.
                    // Depending on the complexity of the commands (direction and speed) we might want to 
                    // allow this to be multi string commands.

                    if (command.Contains(" ")) {
                        int space = message.IndexOf(' ');
                        command = message.Substring(splitPoint, space - splitPoint);
                    }
                }

                ChatMessage chatMessage = new ChatMessage(chatterName, message, command);
                print("Chatter: " + chatMessage.user);
                print("Message: " + chatMessage.message);
                print("Command: " + chatMessage.command);


                string name1 = "", message1 = "", command1 = "";
                                
                string fullMessage3 = mess3.text;
                string fullMessage2 = mess2.text;
                string fullMessage1 = mess1.text;
         
                mess3.text = fullMessage2;
                mess2.text = fullMessage1;
                name1 = chatterName;
                message1 = message;
                command1 = command;
                mess1.text = "Chatter: " + name1 + "\nMessage: " + message1 + "\nCommand: " + command1;
               


            }
            else {
                print("Non-user sent message recieved: " + message);
            }
        }
    }

    public void WriteToChat(string message)
    {
        writer.WriteLine("PRIVMSG #" + channelName + " :" + "Command List: !command !camera");
        writer.WriteLine("PRIVMSG #" + channelName + " :" + "Colors: !blue !red");
        writer.WriteLine("PRIVMSG #" + channelName + " :" + "Movement: !bounce !up !down !left !right");
        writer.Flush();
        print("SentCommandList");
    }



// If the Twitch client isn't available it attempts to reconnect. 
    void Update()
    {
        if (!twitchClient.Connected) {
            connectedTxt.text = "Disconnected";
            connectedTxt.color = Color.red;
            Connect();
            print("Client not connected. attempting to connect");
        }
        else {
            ReadChat();
        }

        if (twitchClient.Available == 0) {
            reconnectTimer += Time.deltaTime;
        }
        if (twitchClient.Available == 0 && reconnectTimer >= reconnectAfter) {
            Connect();
            print("Trying to make client available");
            reconnectTimer = 0.0f;
        }
    }
}

