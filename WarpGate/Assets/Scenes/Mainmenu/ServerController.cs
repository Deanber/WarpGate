using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class ServerController : MonoBehaviour
{
    static bool isconnected = false;
    Socket socket;
    void startservers()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.BeginConnect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 888), connectcallback, socket);
    }
    void connectcallback(IAsyncResult ar)
    {
        try
        {
            Socket serversocket = (Socket)ar.AsyncState;
            isconnected = true;
            serversocket.EndConnect(ar);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    void check_connection(float tick)
    {

    }

    void Start()
    {
        startservers();
    }


    void Update()
    {

    }
}
