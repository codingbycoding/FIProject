#ifndef _CHAT_SERVICE_ICE
#define _CHAT_SERVICE_ICE

#include <CharacterService.ice>
#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
                struct ChannelInfo
                {
                    long    channelId;
                    int     curPlayerNum;
                    int     maxPlayerNum;
                };
				sequence<ChannelInfo>   ChannelSeq;

				struct NoticeInfo
				{
					int 	noticeId;
					string	noticeMessage;
					string 	noticeTitle;
					long  	beginTime;
					long 	deadTime;
					byte 	noticeType;
				};
				sequence<NoticeInfo>	NoticeInfoSeq;

				struct InformationInfo
				{
					int 	informationId;
					int 	informationPeriod;
					string  informationMessage;
					string 	informationTitle;
					long  	beginTime;
					long  	deadTime;
					byte	informationType;
				};
				sequence<InformationInfo>	InformationInfoSeq;

				struct SendInformationInfo
				{
					InformationInfo 	informationStruct;
					byte 				informationState;
				};

				exception ChatException extends PaseoException
                {};

				exception ChannelNotExisted extends ChatException
				{};

				exception ChannelFull extends ChatException
				{};

				exception NoticeNotExisted extends ChatException
				{};

				interface ChatService
				{
					void SendChatMessage( long sid, byte scopeId, long senderSid, string receiverName, string message ) throws PaseoException;
                   	ChannelInfo JoinChannel( long sid, long channelId ) throws PaseoException;
                    ChannelSeq  GetAllChannel(long sid);
					bool SendNotice( long sid, NoticeInfo info );
					NoticeInfoSeq GetAllNoticeByType( long sid, byte noticeType );
					bool DelNotice( long sid, int noticeId, byte noticeType );
					bool SendInformation( long sid, InformationInfo info );
					InformationInfoSeq GetAllInformation( long sid );
					bool DelInformation( long sid, int informationId );
					CharacterSeq GetSameChannelIdlePlayers( long sid ) throws PaseoException;
				};
			};
		};
	};
};

#endif //_CHAT_SERVICE_ICE
