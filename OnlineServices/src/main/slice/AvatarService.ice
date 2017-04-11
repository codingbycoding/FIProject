#ifndef AVATAR_SERVICE_H
#define AVATAR_SERVICE_H

#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

				interface AvatarService
				{
				    AvatarProfile getAvatar(string name);
				    void updateAvatar(AvatarProfile avatarProfile);
				};

            };
        };
    };
};

#endif