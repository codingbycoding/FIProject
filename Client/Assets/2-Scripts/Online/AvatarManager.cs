using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using es.upm.fi.rmi;

public class AvatarManager
{
    private static AvatarManager _instance = null;

    private AvatarServicePrx _avatarPrx;

    public static AvatarManager GetAvatarManager()
    {
        if (_instance == null)
        {
            _instance = new AvatarManager(OnlineManager.GetOnlineManger());

        }

        return _instance;
    }

    private AvatarManager(OnlineManager olManager)
    {
        _avatarPrx = AvatarServicePrxHelper.checkedCast(olManager.StringToProxy("PaseoOnline/PaseoAvatarService"));
    }

    public void UpdateAvatar(string name, AvatarState avatarState)
    {
        AvatarProfile avatarProfile = new AvatarProfile();

        avatarProfile.name = name;
        avatarProfile.avatarState = avatarState;
        avatarProfile.avatarId = avatarProfile.name;
        _avatarPrx.updateAvatar(avatarProfile);

        Debug.Log("SaveState:" + avatarState.serverEntry.servAddr);
    }

    public AvatarState GetAvatarState(string name)
    {
        return _avatarPrx.getAvatar(name).avatarState;
    }
}

