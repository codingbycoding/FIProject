#ifndef _SERVER_SERVICE_ICE
#define _SERVER_SERVICE_ICE

#include <TypeDef.ice>


module es
{
	module upm
	{
		module fi
		{
			module rmi
			{

                interface ServerService
                {
                    ServerInfo   getServerInfo();
                };

			};
        };
    };
};

#endif //_SERVER_SERVICE_ICE