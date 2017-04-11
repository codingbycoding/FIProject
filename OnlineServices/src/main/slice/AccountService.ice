#ifndef ACCOUNT_SERVICE_H
#define ACCOUNT_SERVICE_H

#include <TypeDef.ice>

module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				struct AccountProfile
				{
					string	name;
					string  email;
					string	uid;
					string	password;
                    int     groupType;
				};

				exception AccountException extends PaseoException
                {
                };

				exception AccountHasAlreadyExisted extends AccountException
				{
				};

				exception AccountDoesnotExist extends AccountException
				{
				};

				interface AccountService
				{
					void KeepAlive(long sid);
					void CreateAccount( AccountProfile profile ) throws AccountHasAlreadyExisted;
					AccountProfile GetCurrentAccount(long sid) throws AccountDoesnotExist;
					AccountProfile GetAccountByName( string name ) throws AccountDoesnotExist;
					AccountProfile GetAccountByUid( int uid ) throws AccountDoesnotExist;
					void DestroyAccountByName( string name ) throws AccountDoesnotExist;
					void DestroyAccountByUid( int uid ) throws AccountDoesnotExist;
				};
			};
		};
	};
};

#endif //ACCOUNT_SERVICE_H
