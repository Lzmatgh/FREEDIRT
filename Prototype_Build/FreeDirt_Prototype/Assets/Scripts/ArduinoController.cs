using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.Sockets;

public class ArduinoController : MonoBehaviour
{
    bool socketReady = false;
    TcpClient client;
    public NetworkStream stream;
    StreamWriter writer;
    StreamReader reader;

    public string host;
    public Int32 port;

     void Start()
    {
        ConnectArduino();
    }

    void Update()
    {
        while(stream.DataAvailable) {
            string data = ReadSocket();
            if(data == "Enter stuff here ") {

            }
        }
    }

    void ConnectArduino()
    {
        try {
            client = new TcpClient(host, port);
            stream = client.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
    }

    public void WriteSocket(string writeLine)
    {
        if (!socketReady) {
            return;
        }
        writer.Write(writeLine);
        writer.Flush();
    }

    public string ReadSocket()
    {
        if (!socketReady) {
            return null;
        }
        if (stream.DataAvailable) {
            return reader.ReadLine();
        }
        return "NoData";
    }

    public void CloseSocket()
    {
        if (!socketReady) {
            return;
        }
        writer.Close();
        reader.Close();
        stream.Close();
        socketReady = false;
    }

    public void MaintainConnection()
    {
        if (!stream.CanRead) {
            ConnectArduino();
        }
    }
}
