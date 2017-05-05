using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private GameObject gbChatPanel;
    private InputField chatInputField;

    // Use this for initialization
    void Start () {
        gbChatPanel = GameObject.Find("ChatPanel");
		chatInputField = GameObject.Find("ChatPanel/ChatInputField").GetComponent<InputField>();

        gbChatPanel.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M) && !chatInputField.isFocused) {
            if(!gbChatPanel.activeSelf)
            {
                gbChatPanel.SetActive(true);
				chatInputField.ActivateInputField();
				chatInputField.Select();
                
            } else
            {
                gbChatPanel.SetActive(false);
            }

            
        }
	}
}
