using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using System;
using System.ComponentModel;


public class TwitchChat : MonoBehaviour
{
    public string username;
    public string password;
    public string channelName;

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    private float reconnectTimer;
    private float reconnectAfter;

    public CommandManager manager;
    public ChatMessage message;

    // Start is called before the first frame update
    void Start()
    {
        reconnectAfter = 10.0f;
        Connect();
    }

    // Connect instantiates twitchClient and connects Unity to the Twitch channel URL
    private void Connect()
    {
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
        if(twitchClient.Connected) {
            print("Connected!");
        }
    }


    // Checks if the Twitch data is available (>0) and gets a message. 
    // If the message is a PRIVMSG its user created and will print to console.
    public ChatMessage ReadChat()
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
                if(message.Contains("!")) {
                    message = message.ToLower();
                    splitPoint = message.IndexOf("!");
                    command = message.Substring(splitPoint);
                    // This chops the command to only from the ! to the space " " but if the command only wants
                    // to be everything after the command then the following if statement can be removed.
                    // Depending on the complexity of the commands (direction and speed) we might want to 
                    // allow this to be multi string commands.
                    
                    if(command.Contains(" ")) {
                        int space = message.IndexOf(' ');
                        command = message.Substring(splitPoint, space - splitPoint); 
                    }
                }

                ChatMessage chatMessage = new ChatMessage(chatterName, message, command);
                print("Chatter: " + chatMessage.user);
                print("Message: " + chatMessage.message);
                print("Command: " + chatMessage.command);

                //manager.ActivateCommand(command);
                return chatMessage;
            }
            else {
                print("Non-user sent message recieved: " + message);
                return null;
            }
        }
        return null;
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
            Connect();
            print("Client not connected. attempting to connect");
        }
        else {
            ChatMessage chatMessage = new ChatMessage();
            chatMessage = ReadChat();
            if (chatMessage != null) {
                print("A message has been recieved from Twitch");
                manager.ReadFromTwitch(chatMessage);
            }
            //print("Attempting to read from Twitch");
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