#ifndef _DS_SERVICE_ICE
#define _DS_SERVICE_ICE

#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				interface DsService
				{
					void registerDs(ServerEntry serverEntry);
					void unRegisterDs(ServerEntry serverEntry);
				};
			};
		};
	};
};

#endif //ACCOUNT_SERVICE_H
