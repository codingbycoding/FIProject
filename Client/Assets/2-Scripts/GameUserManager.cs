using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


// GameUserManager only exists on game server, manages all the active game users 
public class GameUserManager
{
    private Dictionary<NetworkConnection, GameUser> userDictionary;
    private Dictionary<string, NetworkConnection> name2ConnectionDic;


    private static GameUserManager instance = null;

    public static GameUserManager GetGameUserManager()
    {
        if (null == instance)
        {
            instance = new GameUserManager();
        }

        return instance;
    }


    private GameUserManager()
    {
        userDictionary = new Dictionary<NetworkConnection, GameUser>();
        name2ConnectionDic = new Dictionary<string, NetworkConnection>();
    }

    public bool HasGameUser(string userName)
    {
        return name2ConnectionDic.ContainsKey(userName);
    }

    public void AddGameUser(GameUser gameUser)
    {
        userDictionary[gameUser.NetworkConn] = gameUser;
        name2ConnectionDic[gameUser.UserName] = gameUser.NetworkConn;
    }

    public void RemoveGameUser(string userName)
    {
        NetworkConnection networkConn = name2ConnectionDic[userName];
        name2ConnectionDic.Remove(userName);
        userDictionary.Remove(networkConn);
    }

    public void RemoveGameUser(NetworkConnection networkConn)
    {
        GameUser gameUser = userDictionary[networkConn];
        name2ConnectionDic.Remove(gameUser.UserName);
        userDictionary.Remove(networkConn);
    }


    public GameUser GetGameUser(string userName)
    {
        NetworkConnection networkConn = name2ConnectionDic[userName];
        return GetGameUser(networkConn);
    }

    public GameUser GetGameUser(NetworkConnection networkConn)
    {
        return userDictionary[networkConn];
    }
}