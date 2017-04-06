using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// DataMaster is for share the data among different objects
public class DataMaster : MonoBehaviour
{

    static private GameClient gameClient;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    static public GameClient GameClient {
        get
        {
            return gameClient;
        }
        set
        {
            gameClient = value;
        }
    }

    static public GameObject GamePlayer
    {
        get; set;
       
    }

    static public GameServer GameServer
    {
        get; set;

    }


    //    (GameClient inNetworkController)
    //{
    //    gameClient = inNetworkController;
    //}

    //static public GameClient getNetworkController()
    //{
    //    return gameClient;
    //}
}

