#ifndef CHARACTER_SERVICE_H
#define CHARACTER_SERVICE_H

#include <AccountService.ice>
#include <TypeDef.ice>
module es
{
	module upm
	{
		module fi
		{
			module rmi
			{
				sequence<string>					IDSeq;
				sequence<int>					    intSeq;
				sequence<long>					    longSeq;				
			
				struct CharacterProfile
				{
					int		id;
					string	name;
					byte	gender;
					byte 	rank;			

				};				
				sequence< CharacterProfile > 		CharacterSeq;

				sequence< AvatarProfile > 		AvatarSeq;
				
				interface CharacterService
				{
					void CreateCharacter( string userId, CharacterProfile chr , AvatarSeq avatarInfo ) throws PaseoException;
					CharacterSeq GetCharcterByUID( long sid, string userId ) throws PaseoException;
					CharacterProfile SelectCharacter(int characterId,long sessionId) throws PaseoException;
					CharacterProfile GetCurrentCharacter(long sessionId) throws PaseoException;
					void CancelSelectCharacter(long sessionId) throws PaseoException;
					void DeleteCharaterByCharacterId(int characterId) throws PaseoException;
					void UpdateCurrentInfomation(CharacterProfile chr) throws PaseoException;
					void ChangeFamilyInfo(int CharacterId, int familyInfo) throws PaseoException;
					CharacterProfile GetCharacterByName(string name) throws PaseoException;
					void AddCharacterExperience(int CharacterId, int experience) throws PaseoException;						
				};
			};
		};	
	};
};

#endif //CHARACTER_SERVICE_H
																																	

