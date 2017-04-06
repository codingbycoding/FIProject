using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class OptionalMenu : MonoBehaviour {

    public Button exitButtonFab;
    Button exitButton;

    Transform canvasRT;
    // Use this for initialization
    void Start () {
        canvasRT = GameObject.Find("Canvas").GetComponent<RectTransform>();

        exitButton = Instantiate<Button>(exitButtonFab, new Vector3(0, 0, 0), Quaternion.identity);
        exitButton.gameObject.SetActive(false);
        exitButton.transform.SetParent(canvasRT, false);

        exitButton.onClick.AddListener(GameExit);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowOptionButton();
        }
    }


    public void ShowOptionButton()
    {
        
        if (exitButton.gameObject.activeSelf == true)
        {
            exitButton.gameObject.SetActive(false);
        }
        else
        {
            exitButton.gameObject.SetActive(true);
        }
    }
    

    void GameExit()
    {
        Debug.Log("Game is exiting....");

        GameObject gbPlayer = DataMaster.GamePlayer;
        PlayerCommand playerCommand = gbPlayer.GetComponent<PlayerCommand>();
        playerCommand.CmdSaveState();

        Application.Quit();        
    }


}
