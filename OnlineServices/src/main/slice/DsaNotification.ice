#ifndef _DSA_NOTIFICATION_ICE
#define _DSA_NOTIFICATION_ICE

#include <NotificationBase.ice>
#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{				
				interface DsaNotification extends NotificationBase
				{
					void OnStartServer( ServerInfo info );
				};

			};
		};
	};
};

#endif //_DSA_NOTIFICATION_ICE
