CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `AspNetRoles` (
    `Id` varchar(127) NOT NULL,
    `ConcurrencyStamp` longtext,
    `Name` varchar(256),
    `NormalizedName` varchar(256),
    CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(127) NOT NULL,
    `LoginProvider` varchar(127) NOT NULL,
    `Name` varchar(127) NOT NULL,
    `Value` longtext,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`)
);

CREATE TABLE `AspNetUsers` (
    `Id` varchar(127) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    `ConcurrencyStamp` longtext,
    `Email` varchar(256),
    `EmailConfirmed` bit NOT NULL,
    `LockoutEnabled` bit NOT NULL,
    `LockoutEnd` datetime(6),
    `NormalizedEmail` varchar(256),
    `NormalizedUserName` varchar(256),
    `PasswordHash` longtext,
    `PhoneNumber` longtext,
    `PhoneNumberConfirmed` bit NOT NULL,
    `SecurityStamp` longtext,
    `TwoFactorEnabled` bit NOT NULL,
    `UserName` varchar(256),
    CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClaimType` longtext,
    `ClaimValue` longtext,
    `RoleId` varchar(127) NOT NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClaimType` longtext,
    `ClaimValue` longtext,
    `UserId` varchar(127) NOT NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(127) NOT NULL,
    `ProviderKey` varchar(127) NOT NULL,
    `ProviderDisplayName` longtext,
    `UserId` varchar(127) NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(127) NOT NULL,
    `RoleId` varchar(127) NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `IX_AspNetUserRoles_UserId` ON `AspNetUserRoles` (`UserId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('00000000000000_CreateIdentitySchema', '2.0.2-rtm-10011');

ALTER TABLE `AspNetUsers` MODIFY COLUMN `LockoutEnd` datetime(6) NULL;
ALTER TABLE `AspNetUsers` ALTER COLUMN `LockoutEnd` DROP DEFAULT;
ALTER TABLE `AspNetUserClaims` MODIFY COLUMN `Id` int NOT NULL;
ALTER TABLE `AspNetUserClaims` ALTER COLUMN `Id` DROP DEFAULT;
ALTER TABLE `AspNetRoleClaims` MODIFY COLUMN `Id` int NOT NULL;
ALTER TABLE `AspNetRoleClaims` ALTER COLUMN `Id` DROP DEFAULT;
CREATE TABLE `biodata` (
    `BioId` int(11) NOT NULL AUTO_INCREMENT,
    `ActivityLevel` tinyint(4) NOT NULL,
    `Birthday` datetime(6) NOT NULL,
    `Gender` longtext,
    `Height` tinyint(4) NOT NULL,
    `UserId` varchar(127),
    `Weight` tinyint(4) NOT NULL,
    CONSTRAINT `PK_biodata` PRIMARY KEY (`BioId`),
    CONSTRAINT `FK_BioData_Aspnetusers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `recipe` (
    `RecipeId` int(11) NOT NULL AUTO_INCREMENT,
    `ReCreationDate` datetime(6) NOT NULL,
    `RecipeDescription` longtext,
    `RecipeName` longtext,
    `UserId` varchar(127),
    CONSTRAINT `PK_recipe` PRIMARY KEY (`RecipeId`),
    CONSTRAINT `FK_Recipe_Aspnetusers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `reciperatning` (
    `RecipeId` int(11) NOT NULL,
    `RecipeRating` smallint(6) NOT NULL,
    CONSTRAINT `PK_reciperatning` PRIMARY KEY (`RecipeId`),
    CONSTRAINT `FK_RecipeRatning_Recipe_RecipeId` FOREIGN KEY (`RecipeId`) REFERENCES `recipe` (`RecipeId`) ON DELETE CASCADE
);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `aspnetuserclaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `aspnetuserlogins` (`UserId`);

CREATE INDEX `IX_Aspnetuserroles_RoleId` ON `aspnetuserroles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `aspnetusers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `aspnetusers` (`NormalizedUserName`);

CREATE INDEX `IX_BioData_UserId` ON `biodata` (`UserId`);

CREATE INDEX `IX_Recipe_UserId` ON `recipe` (`UserId`);

ALTER TABLE `AspNetUserTokens` ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180417161514_InitialCreate', '2.0.2-rtm-10011');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180417192128_AgetCreate', '2.0.2-rtm-10011');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180417201646_BMRCreate', '2.0.2-rtm-10011');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180417203310_configCurrentCreate', '2.0.2-rtm-10011');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180417211154_HeightDigitsCreate', '2.0.2-rtm-10011');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180417211627_Height2DigitsCreate', '2.0.2-rtm-10011');

ALTER TABLE `biodata` MODIFY COLUMN `Weight` int(5) NOT NULL;
ALTER TABLE `biodata` ALTER COLUMN `Weight` DROP DEFAULT;
ALTER TABLE `biodata` MODIFY COLUMN `Height` int(5) NOT NULL;
ALTER TABLE `biodata` ALTER COLUMN `Height` DROP DEFAULT;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180418052741_biotypechangeCreate', '2.0.2-rtm-10011');