using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    GameClient gameClient;
    AvatarPanel avatarPanel;

    GameObject loginWarningObj;

    InputField userNameInput;
    InputField passwordInput;

    // Use this for initialization
    void Start() {
        GameObject obj = GameObject.Find("GameClient") as GameObject;
        if (null != obj)
        {
            gameClient = obj.GetComponent<GameClient>();
        }

        avatarPanel = GameObject.Find("AvatarPanel").GetComponent<AvatarPanel>();
        loginWarningObj = GameObject.Find("LoginWarning") as GameObject;
        loginWarningObj.SetActive(false);

        userNameInput = GameObject.Find("UserName").GetComponent<InputField>();
        passwordInput = GameObject.Find("Password").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update() {
        if (userNameInput.isFocused || passwordInput.isFocused)
        {
            loginWarningObj.SetActive(false);
        }
	}

    public void Connect()
    {
        string userName = userNameInput.text;
        string password = passwordInput.text;

        if(userName.Equals("") || password.Equals(""))
        {
            loginWarningObj.SetActive(true);
            return;
        }

        int avatarId = avatarPanel.AvatarCursor;

        gameClient.ConnectOlineService(userName, password, avatarId);
    }
}