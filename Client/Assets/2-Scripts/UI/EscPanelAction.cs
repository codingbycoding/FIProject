using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscPanelAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SaveExitGame() {
		Debug.Log("SaveExitGame.");

		GameObject gbPlayer = DataMaster.GamePlayer;
		PlayerCommand playerCommand = gbPlayer.GetComponent<PlayerCommand>();
		playerCommand.CmdSaveState();
		Application.Quit();    
	}

	public void ExitGame() {
		Debug.Log("ExitGame.");
		Application.Quit();    
	}

	public void BackToLogin() {
		Debug.Log("BackToLogin.");
		GameClient gameClient = DataMaster.GameClient;
		gameClient.Logout();
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}
