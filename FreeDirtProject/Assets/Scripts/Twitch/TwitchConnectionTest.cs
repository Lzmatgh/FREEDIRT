using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net.Sockets;
using System;
using System.ComponentModel;
using UnityEngine.UI;
using TMPro;

public class TwitchConnectionTest : MonoBehaviour
{
    string username;// = "stingreay99";
    string password;// = "oauth:bgwmlgp1xkzk6fatv4oby6wcn7yso3";
    string channelName;// = "stingreay99";

    private TcpClient twitchClient;
    private StreamReader streamReader;
    private StreamWriter streamWriter;
    private float reconnectTimer;
    private float reconnectAfter;

    public ChatMessage message;

    public TMP_Text statusText;
    public TMP_Text lastMessageText;

    public TMP_Text channelInput;
    public TMP_Text userInput;
    public TMP_Text oauthInput;

    // Start is called before the first frame update
    void Start()
    {   
        reconnectAfter = 10.0f;
    }

    // Connect instantiates twitchClient and connects Unity to the Twitch channel URL
    public void Connect()
    {
        ReadConfig();
        print("Connecting");
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667); // 1        
        streamReader = new StreamReader(twitchClient.GetStream()); // 2
        streamWriter = new StreamWriter(twitchClient.GetStream());
        streamWriter.WriteLine("PASS " + password); // 3
        streamWriter.WriteLine("NICK " + username);
        streamWriter.WriteLine("USER " + username + " 8 * : " + username);
        streamWriter.WriteLine("JOIN #" + channelName);
        streamWriter.Flush();
        if (twitchClient.Connected) {
            print("Connected!");
            statusText.text = "Connected";
            statusText.color = Color.green;
        }
    }

    public void ReadConfig()
    {
        print("Reading config file.");
        StreamReader reader = new StreamReader("Assets/connection_info.txt");
        channelName = reader.ReadLine();
        username = reader.ReadLine();
        password = reader.ReadLine();

        channelInput.text = channelName;
        userInput.text = username;
        oauthInput.text = password;

        reader.Close();
        print(channelName);
        print(username);
        print(password);
    }
    // Checks if the Twitch data is available (>0) and gets a message. 
    // If the message is a PRIVMSG its user created and will print to console.
    public void ReadChat()
    {
        if (twitchClient.Available > 0) {
            //print("Client Available");    
            string message = streamReader.ReadLine();

            // Twitch will ping the program every 5 minutes and requires the response PONG or will disconnect
            if (message.Contains("PING")) {
                streamWriter.WriteLine("PONG");
                streamWriter.Flush();
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

                lastMessageText.text = "Chatter: " + chatMessage.user + "\nMessage: " + chatMessage.message + "\nCommand: " + chatMessage.command;
               


            }
            else {
                print("Non-user sent message recieved: " + message);
                if (message.Contains(":Invalid") || message.Contains(":Improperly")) {
                    statusText.text = "Disconnected";
                    statusText.color = Color.red;
                }
            }
        }
    }

// If the Twitch client isn't available it attempts to reconnect. 
    void Update()
    {
        if (!twitchClient.Connected) {
            statusText.text = "Disconnected";
            statusText.color = Color.red;
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

