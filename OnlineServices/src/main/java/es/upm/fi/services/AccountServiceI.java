package es.upm.fi.services;

import Ice.Current;

import es.upm.fi.rmi.AccountDoesnotExist;
import es.upm.fi.rmi.AccountHasAlreadyExisted;
import es.upm.fi.rmi.AccountProfile;
import es.upm.fi.rmi._AccountServiceDisp;
import es.upm.fi.utils.UTLogger;
import es.upm.fi.db.UserAccountDB;


public class AccountServiceI extends _AccountServiceDisp {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;


	@Override
	public void CreateAccount(AccountProfile profile, Current __current) throws AccountHasAlreadyExisted {
		UTLogger.info("CreateAccount profile:" + profile.toString());
		UserAccountDB.createAccount(profile);
	}


	@Override
	public AccountProfile GetAccountByName(String name, Current __current) throws AccountDoesnotExist {
		// TODO Auto-generated method stub
		return null;
	}


}
