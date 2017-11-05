SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for aspnetusers
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers` (
  `Id` varchar(127) NOT NULL,
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `FName` varchar(256) DEFAULT NULL,
  `LName` varchar(256) DEFAULT NULL,
  `Birthdate` datetime DEFAULT NULL,
  `Alias` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  KEY `UserId` (`UserId`) USING BTREE,
  KEY `UserId_2` (`UserId`) USING BTREE,
  KEY `UserId_3` (`UserId`) USING BTREE,
  KEY `UserId_4` (`UserId`) USING BTREE,
  KEY `UserId_5` (`UserId`),
  KEY `UserId_6` (`UserId`),
  KEY `UserId_7` (`UserId`),
  KEY `UserId_8` (`UserId`),
  KEY `Id` (`Id`),
  KEY `Id_2` (`Id`),
  KEY `UserId_9` (`UserId`),
  KEY `UserId_10` (`UserId`),
  KEY `UserId_11` (`UserId`),
  KEY `UserId_12` (`UserId`),
  KEY `UserId_13` (`UserId`),
  KEY `UserId_14` (`UserId`),
  KEY `UserId_15` (`UserId`),
  KEY `UserId_16` (`UserId`),
  KEY `UserId_17` (`UserId`),
  KEY `UserId_18` (`UserId`),
  KEY `UserId_19` (`UserId`),
  KEY `UserId_20` (`UserId`),
  KEY `UserId_21` (`UserId`),
  KEY `FName` (`FName`),
  KEY `UserId_22` (`UserId`),
  KEY `UserId_23` (`UserId`),
  KEY `UserId_24` (`UserId`),
  KEY `UserId_25` (`UserId`),
  KEY `UserId_26` (`UserId`),
  KEY `UserId_27` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;

SET FOREIGN_KEY_CHECKS = 1;
