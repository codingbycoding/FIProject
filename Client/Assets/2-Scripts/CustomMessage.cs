using UnityEngine.Networking;



// All Custom Messages definitions go here 
public class CustomMessage { 
    
}

class CSLoginMessage : MessageBase
{
    public string userName;
    public int avatarId;
    public string cookie;
    public bool restoreFlag;
}

class CSRestoreState : MessageBase
{
    public string userName;
}


class CSClientSceneReady : MessageBase
{

}

enum LoginState
{
    ACCEPT,
    REJECT
}

class SCLoginMessage : MessageBase
{
    public LoginState loginState;
    public string sceneName;
}


class SCPlayerReady : MessageBase
{

}

class CustomMsgType
{
    public static short CS_Login = 500;
    public static short SC_Login = 501;

    //public static short CS_ClientSceneReady = 502;

    public static short SC_PlayerReady = 504;

    public static short CS_RestoreState = 505;
}