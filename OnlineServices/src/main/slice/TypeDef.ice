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

				struct URL
				{
					string 			IP;
					int 			Port;
				};
			
				struct ServerEntry
				{
					//example: "192.168.1.200:30000"
					string serverName;
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

                exception UserDoesnotOnline extends PaseoException
                {
                };


                exception DataError extends PaseoException
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
