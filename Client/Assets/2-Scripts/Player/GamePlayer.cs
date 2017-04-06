using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// GamePlayer will holds attributs like userName(HP, avatar level ...) of the player
public class GamePlayer : MonoBehaviour {
    private string userName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}