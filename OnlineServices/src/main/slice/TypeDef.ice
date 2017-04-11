#ifndef _TYPE_DEF_ICE
#define _TYPE_DEF_ICE

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

				enum MatchNotificationType
				{
					MNTStartMatch,
					MNTMatchReady
				};

				struct URL
				{
					string 			IP;
					int 			Port;
				};

                sequence<byte>                      byteSeqT;
                sequence<short>                     shortSeqT;
                sequence<int>                       intSeqT;
                sequence<long>                      longSeqT;
                sequence<string>                    strSeqT;

			    struct BaseInfoStream
                {
                    byteSeqT                            byteSeq;
                    shortSeqT                           shortSeq;
                    intSeqT                             intSeq;
                    longSeqT                            longSeq;
                    strSeqT                             strSeq;
                };
			
				struct ServerEntry
				{
					//example: "192.168.1.200:30000"
					string servAddr;
					string name;
				};

				sequence<ServerEntry>   					serverInfoSeqT;

                struct Position
                {
                    float x;
                    float y;
                    float z;
                };

                struct Rotation
                {
                    float x;
                    float y;
                    float z;
                    float w;
                };


				struct AvatarState
				{
                    Position position;
                    Rotation rotation;
                    ServerEntry serverEntry;
				};

				struct ServerInfo
				{
				    serverInfoSeqT     serverInfoSeq;
				    bool               hasLastState = true;
				};


                struct AvatarProfile
                {
                    string	name;
                    string avatarId;
                    AvatarState avatarState;
                };

                struct RmiItem
                {
                    int itemId;
                    int itemNum;
                };

                sequence<RmiItem>    itemSeq;
                struct RmiInventory
                {
                    itemSeq    items;
                };

                exception PaseoException
                {
                };

                exception LoginQueued extends PaseoException
                {
                };

                exception UserDoesnotOnline extends PaseoException
                {
                };

				exception CharacterNotExisted extends PaseoException
				{
				};

                exception OperateFailed extends PaseoException
                {
                };

                exception DataError extends PaseoException
                {
                };

				exception UserHasNotAuthority extends PaseoException
                {
                };

				exception ArgErr extends PaseoException
				{
				};

			};
		};
	};
};

#endif //_TYPE_DEF_ICE
