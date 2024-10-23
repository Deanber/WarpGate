using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class ServerController : MonoBehaviour
{
    [HideInInspector] public bool isconnected = false;
    [HideInInspector] public string CallBackString = null;
    Socket socket;

    void Start()
    {
        DontDestroyOnLoad(this);
        startservers();
    }


    void Update()
    {

    }

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
            serversocket.EndConnect(ar);
            isconnected = true;
            CallBackString = "The Server is connected";
        }
        catch (Exception e)
        {
            Debug.Log(e);
            CallBackString = "Server connection fail, please check your network connection. ";
            isconnected = false;
        }
    }


}
