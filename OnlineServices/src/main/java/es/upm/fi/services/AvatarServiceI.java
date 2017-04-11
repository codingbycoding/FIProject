package es.upm.fi.services;

import Ice.Current;

import es.upm.fi.db.AvatarDB;

import es.upm.fi.rmi.AvatarProfile;
import es.upm.fi.rmi.AvatarState;
import es.upm.fi.rmi._AvatarServiceDisp;

import es.upm.fi.entity.AvatarEntity;
import es.upm.fi.utils.SerializeUtil;
import es.upm.fi.utils.UTLogger;


public class AvatarServiceI extends _AvatarServiceDisp {

    @Override
    public AvatarProfile getAvatar(String name, Current __current) {
        AvatarProfile avatarProfile = null;
        AvatarEntity avatarEntity = AvatarDB.getAvatar(name);
        if(null != avatarEntity) {
            avatarProfile = new AvatarProfile();
            avatarProfile.name = avatarEntity.getName();
            UTLogger.debug("getAvatar serialization db: " + avatarEntity.getAvatar_state());
            avatarProfile.avatarState = (AvatarState)SerializeUtil.getObjectFromString(avatarEntity.getAvatar_state());
        }

        return avatarProfile;
    }

    @java.lang.Override
    public void updateAvatar(AvatarProfile avatarProfile, Current __current) {
        AvatarEntity avatarEntity = new AvatarEntity();

        avatarEntity.setAvatar_id("");
        avatarEntity.setName(avatarProfile.name);
        avatarEntity.setAvatar_state(SerializeUtil.object2String(avatarProfile.avatarState));

        AvatarDB.persistAvatar(avatarEntity);
        UTLogger.info("updateAvatar servAddr:" + avatarProfile.avatarState.serverEntry.servAddr);
    }
}
