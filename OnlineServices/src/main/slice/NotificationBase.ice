#ifndef _NOTIFICATION_BASE_ICE
#define _NOTIFICATION_BASE_ICE

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				interface NotificationBase
				{

				};

                sequence<NotificationBase>      NotificationBaseSeq;
                sequence<NotificationBase*>      NotificationBasePrxSeq;
			};
		};
	};
};

#endif //_NOTIFICATION_BASE_ICE
