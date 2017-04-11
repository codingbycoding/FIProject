#ifndef _MISC_NOTIFICATION_ICE
#define _MISC_NOTIFICATION_ICE

#include <NotificationBase.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

				interface MiscNotification extends NotificationBase
				{
					void OnFirstNotification( long sid, string acc );                 
                    void OnChannelCreated(long sid, int charaid, int uniqueId, long channelId);
				};
			};
		};
	};
};

#endif //_MISC_NOTIFICATION_ICE
