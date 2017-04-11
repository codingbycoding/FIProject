#ifndef _FRIEND_NOTIFICATION_ICE
#define _FRIEND_NOTIFICATION_ICE

#include <NotificationBase.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				interface FriendNotification extends NotificationBase
				{
					void OnFriendOnline( string FriendName );
					void OnFriendOffline( string FriendName );
					void OnSomeoneAddFriend( string FriendName );
				};
			};
		};
	};
};

#endif //_FRIEND_NOTIFICATION_ICE
