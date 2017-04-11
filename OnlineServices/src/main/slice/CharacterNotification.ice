#ifndef _CHARACTER_NOTIFICATION_ICE
#define _CHARACTER_NOTIFICATION_ICE

#include <NotificationBase.ice>
#include <CharacterService.ice>


module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

				interface CharacterNotification extends NotificationBase
				{
					void OnSendPreventIndulgeWarn(int piOnlineTime);
					void OnQueueNumBeforeSelf(int queueNum);
				};
			};
		};
	};
};

#endif //_CHARACTER_NOTIFICATION_ICE

