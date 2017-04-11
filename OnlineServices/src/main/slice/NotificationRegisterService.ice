#ifndef _NOTIFICATION_REGISTER_SERVICE_ICE
#define _NOTIFICATION_REGISTER_SERVICE_ICE

#include <NotificationBase.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				interface NotificationRegisterService
				{
					void RegisterNotification( NotificationBase* notification );
					void RegisterNotifications( NotificationBasePrxSeq notificationSeq );
				};
			};
		};
	};
};

#endif //_NOTIFICATION_REGISTER_SERVICE_ICE
