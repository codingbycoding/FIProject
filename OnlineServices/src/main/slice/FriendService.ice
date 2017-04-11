#ifndef _FRIEND_SERVICE_ICE
#define _FRIEND_SERVICE_ICE

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
				struct FriendInfo
                {
					CharacterProfile 	characterInfo;
					byte 				flagOnline;
				};

				sequence<FriendInfo>	FriendInfoSeq;

				exception FriendException extends PaseoException
                {
                };

				exception FriendHasAlreadyExisted extends FriendException
				{
				};

				interface FriendService
				{
					FriendInfoSeq GetFriendList(int characterId);
					FriendInfoSeq GetBlackList(int characterId);
					void AddFriendById(int characterId, int friCharacterId, int relationType) throws PaseoException;
					void AddFriendByName(int cid, string frdName, int relationType) throws PaseoException;
					bool DeleteFriend(long sid, int frdCid, int relationType) throws PaseoException;
					FriendInfoSeq GetIdleFriendList(long sid) throws PaseoException;
				};
			};
		};
	};
};

#endif //_FRIEND_SERVICE_ICE
