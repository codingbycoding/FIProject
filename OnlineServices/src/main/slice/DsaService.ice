#ifndef _DSA_SERVICE_ICE
#define _DSA_SERVICE_ICE

#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{			
			
				exception DsaException extends PaseoException
                {
                };

                exception HasNoDsa extends DsaException
                {
                };

				interface DsaService
				{
					void DsReady(ServerInfo info);
					void DsaSetMaxLoad(long DsaId, int Load);
					void DsaSetLoadFactor(long DsaId, long Factor);
					void DsaSetMemLevel(long DsaId, int MemLevelHealth);
					void DsaSetAvailableLoad(long DsaId, int AvailableLoad);
                    void DsaSetCurrLoad(long DsaId, int CurrLoad);
					bool DsaCheckHealth2DC(long DsaId, int MaxLoad, int AvailableLoad, long LoadFactor, int MemLevelHealth, int DsaType);
					void DsaInit2DC(long DsaId, int MaxLoad, int AvailableLoad, long LoadFactor, int MemLevelHealth, int DsaType, string DsIP);

					void Ping( );
				};

			};
		};
	};
};

#endif //_DSA_SERVICE_ICE
