#ifndef _MESSAGE_NOTIFICATION_ICE
#define _MESSAGE_NOTIFICATION_ICE

#include <NotificationBase.ice>
#include <ChatService.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				struct Message
				{
					byte            scopeId;
					string			SenderId;			
					long			SessionId;
					string			Text;
				};
				
				sequence< Message >		MessageSeq;
				
				interface MessageNotification extends NotificationBase
				{
                    void OnAutoJoinedChannel(ChannelInfo info);
					void OnReceiveMessage(MessageSeq msgSeq);
					void OnKeepAliveCheck();
					void OnReceiveNotice(NoticeInfo info);
					void OnReceiveInformation(SendInformationInfo info);
				};
			};
		};
	};
};

#endif //_MESSAGE_NOTIFICATION_ICE
