using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine.Networking;

public class ArduinoController : MonoBehaviour
{
    bool socketReady = false;
    TcpClient client;
    public NetworkStream stream;
    StreamWriter writer;
    StreamReader reader;

    public string host;
    public Int32 port = 5001;

    Thread m_Thread;
    UdpClient m_Client;
    public string ipAddress = "192.168.0.1";

    void Start()
    {
        //ConnectArduino();
        m_Thread = new Thread(new ThreadStart(ReceiveData));
        m_Thread.IsBackground = true;
        m_Thread.Start();
    }

    void ReceiveData()
    {

        try {

            m_Client = new UdpClient(4001);
            m_Client.EnableBroadcast = true;
            while(true) {

                IPEndPoint hostIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = m_Client.Receive(ref hostIP);
                string returnData = Encoding.ASCII.GetString(data);

                Debug.Log(returnData);
            }
        }
        catch(Exception e) {
            Debug.Log(e);
        }
    }

    void SendOrder(string order)
    {
        var IP = IPAddress.Parse(ipAddress);

        var udpClient1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        var sendEndPoint = new IPEndPoint(IP, port);


        try {

            //Sends a message to the host to which you have connected.
            byte[] sendBytes = Encoding.ASCII.GetBytes(order);

            udpClient1.SendTo(sendBytes, sendEndPoint);



        }
        catch(Exception e) {
            Debug.Log(e.ToString());
        }

    }

    void Update()
    {
        if(!stream.CanRead) {
            ConnectArduino();
        }
        else {
        //    ReadSocket();
            print("Attempting to read socket.");
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

    public void WriteSocket(char writeChar)
    {
        if (!socketReady) {
            return;
        }
        writer.Write(writeChar);
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
}
