CREATE SCHEMA IF NOT EXISTS PaseoUPM 
DEFAULT CHARACTER SET = utf8 
DEFAULT COLLATE = utf8_general_ci;

USE PaseoUPM;    
				
CREATE TABLE IF NOT EXISTS user_accounts_tbl (
    avatar_id CHAR(36) PRIMARY KEY,
    nick_name VARCHAR(64) NOT NULL COMMENT 'Name of the user',
    email VARCHAR(64),
    create_timestamp INT(11) COMMENT 'The time when this user was created',
    active_timestamp INT(11) COMMENT 'Last time when this user was active',
    avatar_level INTEGER NOT NULL DEFAULT 0,
    user_flags INTEGER NOT NULL DEFAULT 0 COMMENT 'Use different to tag different state like:is online or not, has pay once or not',
    user_title VARCHAR(64) NOT NULL DEFAULT '' COMMENT 'like "Mentor", "Master"'
)  ENGINE = InnoDB;
	
  
CREATE TABLE IF NOT EXISTS avatars_tbl (
    avatar_id CHAR(36) NOT NULL COMMENT '',
    name VARCHAR(32) NOT NULL COMMENT 'Name of the avatar',
    avatar_state MEDIUMBLOB COMMENT 'To customize dynamic state of the avatar',
    PRIMARY KEY (name)
) ENGINE = InnoDB;

		
CREATE TABLE IF NOT EXISTS auth_tbl (
    avatar_id CHAR(36) NOT NULL,
    password_hash CHAR(32) NOT NULL DEFAULT '' COMMENT 'md5(md5("password") + ":" + password_salt)',
    password_salt CHAR(32) NOT NULL DEFAULT '' COMMENT 'see password_hash',
    account_type VARCHAR(32) NOT NULL DEFAULT 'UserAccount',
    PRIMARY KEY (avatar_id)
) ENGINE = InnoDB;

	   
	   
CREATE TABLE IF NOT EXISTS inventory_items_tbl (
	avatar_id VARCHAR(36) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
    item_id INTEGER NOT NULL,   
	
    item_type INTEGER,
    item_name VARCHAR(64),
    item_description VARCHAR(128),
	item_count INTEGER DEFAULT 0,    
	# item_slot INTEGER COMMENT 'Represents the slot position in the inventory panel',
    item_state MEDIUMBLOB COMMENT 'To customize dynamic state of the item',
	PRIMARY KEY (avatar_id, item_id)
) ENGINE = InnoDB;