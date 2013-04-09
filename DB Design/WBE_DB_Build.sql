/*
********************************************************************************
WBE_DB_Build.sql
SQL Server 2012
04.07.2013 Ken Baker
for CIS 234B Advanced Visual Basic
04.09.2013 NOTICE this does not create the relationships between tables!

********************************************************************************
*/

Create database WBE; -- comment out to reset tables without re-creating the entire database
GO
Use WBE;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'WBE')
	DROP TABLE WBE;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'CUSTOMER')
	DROP TABLE CUSTOMER;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'BAKEDGOOD')
	DROP TABLE BAKEDGOOD;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'ORDERS')
	DROP TABLE ORDERS;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'CUSTSTOCK')
	DROP TABLE CUSTSTOCK;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'DRIVER')
	DROP TABLE DRIVER;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'DELIVERY')
	DROP TABLE DELIVERY;
GO
IF EXISTS (SELECT name
			FROM SYSOBJECTS
			WHERE name = 'ORDERITEMS')
	DROP TABLE ORDERITEMS;
GO


CREATE TABLE WBE 
(CompanyID SMALLINT NOT NULL
,CompanyName  VARCHAR (25) NOT NULL 
,Street VARCHAR (1) NOT NULL 
,City VARCHAR (25) NOT NULL 
,State VARCHAR (25) NOT NULL 
,Country VARCHAR (25) NOT NULL 
,Zip SMALLINT  NOT NULL 
,Phone VARCHAR (25) NOT NULL 
,Fax VARCHAR (25) NOT NULL 
);
GO
CREATE TABLE CUSTOMER
(CustomenID SMALLINT NOT NULL
,CustomerName  VARCHAR (25) NOT NULL 
,Address1 VARCHAR (25) NOT NULL 
,Address2 VARCHAR (25) NOT NULL 
,Street VARCHAR (25) NOT NULL 
,City VARCHAR (25) NOT NULL 
,State VARCHAR (25) NOT NULL 
,Country VARCHAR (25) NOT NULL 
,Zip SMALLINT  NOT NULL 
,Phone VARCHAR (25) NOT NULL 
,Fax VARCHAR (25) NOT NULL);
GO
CREATE TABLE CUSTSTOCK
(StockID VARCHAR (25) NOT NULL 
,ItemType VARCHAR (25) NOT NULL 
,ItemName VARCHAR (25) NOT NULL 
,Price VARCHAR (25) NOT NULL 
,StockQuantity VARCHAR (25) NOT NULL 
,DesiredQuantity VARCHAR (25) NOT NULL 
,CustomerID VARCHAR (25) NOT NULL);
GO
CREATE TABLE BAKEDGOOD
(BakedGoodID SMALLINT NOT NULL
,Type VARCHAR (25) NOT NULL 
,Name VARCHAR (25) NOT NULL 
,Price VARCHAR (25) NOT NULL 
,StockQuantity VARCHAR (25) NOT NULL 
,CompanyID VARCHAR (25) NOT NULL);
GO
CREATE TABLE ORDERS
(OrderID VARCHAR (25) NOT NULL 
,OrderDT VARCHAR (25) NOT NULL 
,CustomerID VARCHAR (25) NOT NULL);
GO
CREATE TABLE ORDERITEMS
(OrderItemID VARCHAR (25) NOT NULL
,Quantity VARCHAR (25) NOT NULL
,BakedGoodID VARCHAR (25) NOT NULL
,OrderID VARCHAR (25) NOT NULL);
GO
CREATE TABLE DRIVER
(DriverID VARCHAR (25) NOT NULL 
,DriverName VARCHAR (25) NOT NULL
,CompanyID VARCHAR (25) NOT NULL
,DeliverID VARCHAR (25) NOT NULL);
GO
CREATE TABLE DELIVERY
(DeliveryID VARCHAR (25) NOT NULL
,DeliveryDT VARCHAR (25) NOT NULL
,DriverID VARCHAR (25) NOT NULL
,OrderID VARCHAR (25) NOT NULL);
GO

------------------------------------
-- Make it so and advise
------------------------------------

BEGIN TRANSACTION
    DECLARE @v_now DATETIME;
    BEGIN
        SET @v_now = GETDATE();
        PRINT '----------------------------';
        PRINT 'WBE has been built';
        PRINT @v_now;
        PRINT '----------------------------';
        COMMIT;
    END;
-- END TRANSACTION;





