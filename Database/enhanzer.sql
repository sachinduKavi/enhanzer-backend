CREATE DATABASE IF NOT EXISTS `enhanzer` CHARACTER SET utf8mb4;
USE `enhanzer`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;
CREATE TABLE `Location_Details` (
    `Location_Code` varchar(20) NOT NULL,
    `Location_Name` varchar(100) NULL,
    `Stock_Handle` int NULL,
    `Address` text NULL,
    `Phone` varchar(15) NULL,
    `Status` tinyint(1) NULL,
    PRIMARY KEY (`Location_Code`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261030211132_location', '10.0.14');

CREATE TABLE `Purchase_Bill` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Created_At` datetime(6) NOT NULL,
    `Created_By` varchar(100) NOT NULL,
    `Total_Items` int NOT NULL,
    `Total_Qty` decimal(18,2) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Purchase_Bill_Item` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Purchase_Bill_Id` int NOT NULL,
    `Item_Name` varchar(50) NOT NULL,
    `Batch_Code` varchar(20) NOT NULL,
    `Standard_Cost` decimal(18,2) NOT NULL,
    `Standard_Price` decimal(18,2) NOT NULL,
    `Margin` decimal(18,2) NOT NULL,
    `Qty` decimal(18,2) NOT NULL,
    `Free_Qty` decimal(18,2) NOT NULL,
    `Discount` decimal(5,2) NOT NULL,
    `Total_Cost` decimal(18,2) NOT NULL,
    `Total_Selling` decimal(18,2) NOT NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Purchase_Bill_Item_Location_Details_Batch_Code` FOREIGN KEY (`Batch_Code`) REFERENCES `Location_Details` (`Location_Code`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Purchase_Bill_Item_Purchase_Bill_Purchase_Bill_Id` FOREIGN KEY (`Purchase_Bill_Id`) REFERENCES `Purchase_Bill` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Purchase_Bill_Item_Batch_Code` ON `Purchase_Bill_Item` (`Batch_Code`);

CREATE INDEX `IX_Purchase_Bill_Item_Purchase_Bill_Id` ON `Purchase_Bill_Item` (`Purchase_Bill_Id`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20261031044744_purchase_bill', '10.0.14');

COMMIT;

