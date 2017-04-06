using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarPanel : MonoBehaviour {

    public Sprite[] avtarSprits;

    private GameObject leftAvatar;
    private Image avatarImage;
    private GameObject rightAvatar;
    
    private int avatarCursor = 0;

    public int AvatarCursor
    {
        get { return avatarCursor; }
    }
    

    // Use this for initialization
    void Start () {
        leftAvatar = transform.Find("LeftAvatar").gameObject;
        avatarImage = transform.Find("AvatarImage").GetComponent<Image>();
        rightAvatar = transform.Find("RightAvatar").gameObject;

        avatarImage.sprite = avtarSprits[avatarCursor];
        leftAvatar.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseLeft()
    {
        avatarImage.sprite = avtarSprits[--avatarCursor];

        if (!rightAvatar.activeSelf)
        {
            SetAvatarChooserActive(rightAvatar, true);
        }

        if (avatarCursor == 0)
        {
            SetAvatarChooserActive(leftAvatar, false);
        }
    }

    public void ChooseRight()
    {
        avatarImage.sprite = avtarSprits[++avatarCursor];

        if (!leftAvatar.activeSelf)
        {
            SetAvatarChooserActive(leftAvatar, true);
        }

        if(avatarCursor == avtarSprits.Length-1)
        {
            SetAvatarChooserActive(rightAvatar, false);
        }
    }

    private void SetAvatarChooserActive(GameObject avatarChooser, bool value)
    {
        avatarChooser.SetActive(value);
    }
}