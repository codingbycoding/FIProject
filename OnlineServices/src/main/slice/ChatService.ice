#ifndef _CHAT_SERVICE_ICE
#define _CHAT_SERVICE_ICE

#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

                sequence<string>	OnlineUserSeq;

				exception ChatException extends PaseoException
                {};


				interface ChatService
				{
					void SendChatMessage( long sid, byte scopeId, long senderSid, string receiverName, string message ) throws PaseoException;
					OnlineUserSeq GetOnlineUserList() throws PaseoException;
				};
			};
		};
	};
};

#endif //_CHAT_SERVICE_ICE
