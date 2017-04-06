using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


// GameUser exists on game server holds each game user's data.
public class GameUser
{
    private string userName;
    private GameObject avatar;
    private NetworkConnection networkConn;

    public GameUser(string userName, GameObject avatar, NetworkConnection networkConn)
    {
        this.userName = userName;
        this.avatar = avatar;
        this.networkConn = networkConn;
    }

    public string UserName
    {
        get
        {
            return userName;
        }

        set
        {
            userName = value;
        }
    }

    public NetworkConnection NetworkConn
    {
        get
        {
            return networkConn;
        }
    }

    public GameObject Avatar
    {
        get
        {
            return avatar;
        }

        set
        {
            avatar = value;
        }
    }

}