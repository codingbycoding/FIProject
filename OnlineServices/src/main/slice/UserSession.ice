#ifndef _USERSESSION_ICE
#define _USERSESSION_ICE

#include <Glacier2/Session.ice>
#include <NotificationBase.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				interface UserSession extends ::Glacier2::Session
				{
					void RegisterNotification( NotificationBase* notification );
					void RegisterNotifications( NotificationBasePrxSeq notificationSeq );
				};
			};
		};
	};
};

#endif //_USERSESSION_ICE
