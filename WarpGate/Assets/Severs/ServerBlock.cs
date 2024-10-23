using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerBlock : MonoBehaviour
{
    public Text text;
    GameObject servers;
    ServerController sc;
    void Start()
    {
        servers = GameObject.Find("Servers");
        sc = servers.GetComponent<ServerController>();
        if (sc.isconnected == true)
        {
            text.text = "retry";
        }
    }
}
