using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private GameObject gbChatPanel;
    private InputField inputField;

    // Use this for initialization
    void Start () {
        gbChatPanel = GameObject.Find("ChatPanel");
        inputField = gameObject.GetComponentInChildren<InputField>();

        gbChatPanel.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M) && !inputField.isFocused) {
            if(!gbChatPanel.activeSelf)
            {
                gbChatPanel.SetActive(true);
                
            } else
            {
                gbChatPanel.SetActive(false);
            }

            
        }
	}
}
