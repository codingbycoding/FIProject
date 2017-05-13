using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EscPanel : MonoBehaviour {
	private GameObject gbEscPanel;

	// Use this for initialization
	void Start () {
		gbEscPanel = GameObject.Find("EscPanel");
		gbEscPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ShowEscPanel();
		}
	}


	public void ShowEscPanel()
	{

		if (gbEscPanel.activeSelf == true)
		{
			gbEscPanel.SetActive(false);
		}
		else
		{
			gbEscPanel.SetActive(true);
		}
	}


}
