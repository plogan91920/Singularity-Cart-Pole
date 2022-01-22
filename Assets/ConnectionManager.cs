using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    private TcpClient client;
    private Thread clientReceiveThread;
    // Start is called before the first frame update
    void Start()
    {
        ConnectToTcpServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ConnectToTcpServer()
    {
        try {
            clientReceiveThread = new Thread (new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On Client connect exception " + e);
        }
    }

    private void ListenForData() {
        try {
            client = new TcpClient("localhost", 13000);
        }
        catch (SocketException socketException) {
            Debug.Log("Socket exception: " + socketException);
        }
    }
}
