SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for posts
-- ----------------------------
DROP TABLE IF EXISTS `posts`;
CREATE TABLE `posts` (
  `PostId` int(11) NOT NULL AUTO_INCREMENT,
  `PostContent` longtext,
  `UserId` int(11) NOT NULL,
  `Alias` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`PostId`),
  KEY `IX_Weddings_UserId` (`UserId`),
  KEY `WeddingId` (`PostId`) USING BTREE,
  KEY `WeddingId_2` (`PostId`) USING BTREE,
  KEY `WeddingId_3` (`PostId`) USING BTREE,
  KEY `WeddingId_4` (`PostId`),
  KEY `WeddingId_5` (`PostId`),
  KEY `WeddingId_6` (`PostId`),
  KEY `WeddingId_7` (`PostId`),
  KEY `WeddingId_8` (`PostId`),
  KEY `WeddingId_9` (`PostId`),
  KEY `WeddingId_10` (`PostId`),
  KEY `WeddingId_11` (`PostId`),
  KEY `PostId` (`PostId`),
  KEY `PostId_2` (`PostId`),
  KEY `PostId_3` (`PostId`),
  KEY `PostId_4` (`PostId`),
  CONSTRAINT `posts_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

SET FOREIGN_KEY_CHECKS = 1;
