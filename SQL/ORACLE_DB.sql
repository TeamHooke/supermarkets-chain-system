--------------------------------------------------------
--  File created - Сряда-Март-11-2015   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence SEQUENCE_ID_AUTOINCREMENT
--------------------------------------------------------

   CREATE SEQUENCE  "SEQUENCE_ID_AUTOINCREMENT"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 61 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence SEQUENCE_MEASURES_AI
--------------------------------------------------------

   CREATE SEQUENCE  "SEQUENCE_MEASURES_AI"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 21 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence SEQUENCE_PRODUCT_ID
--------------------------------------------------------

   CREATE SEQUENCE  "SEQUENCE_PRODUCT_ID"  MINVALUE 1000 MAXVALUE 9999999999999999999999999999 INCREMENT BY 10 START WITH 1200 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Sequence SEQUENCE_VENDORS_AUTOINCREMENT
--------------------------------------------------------

   CREATE SEQUENCE  "SEQUENCE_VENDORS_AUTOINCREMENT"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 41 CACHE 20 NOORDER  NOCYCLE ;
--------------------------------------------------------
--  DDL for Table MEASURES
--------------------------------------------------------

  CREATE TABLE "MEASURES" 
   (	"ID" NUMBER(*,0), 
	"NAME" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table PRODUCTS
--------------------------------------------------------

  CREATE TABLE "PRODUCTS" 
   (	"ID" NUMBER(*,0), 
	"PRODUCT_ID" NUMBER(*,0), 
	"NAME" VARCHAR2(50 BYTE), 
	"VENDOR_ID" NUMBER(*,0), 
	"MEASURE_ID" NUMBER(*,0), 
	"PRICE" NUMBER(18,2)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
--------------------------------------------------------
--  DDL for Table VENDORS
--------------------------------------------------------

  CREATE TABLE "VENDORS" 
   (	"ID" NUMBER(*,0), 
	"NAME" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "SYSTEM" ;
REM INSERTING into MEASURES
SET DEFINE OFF;
Insert into MEASURES (ID,NAME) values (1,'Name1');
Insert into MEASURES (ID,NAME) values (2,'Name2');
Insert into MEASURES (ID,NAME) values (3,'Name3');
Insert into MEASURES (ID,NAME) values (4,'Name4');
Insert into MEASURES (ID,NAME) values (5,'Name5');
REM INSERTING into PRODUCTS
SET DEFINE OFF;
Insert into PRODUCTS (ID,PRODUCT_ID,NAME,VENDOR_ID,MEASURE_ID,PRICE) values (44,1000,'Fafla',1,2,20.5);
Insert into PRODUCTS (ID,PRODUCT_ID,NAME,VENDOR_ID,MEASURE_ID,PRICE) values (46,1020,'Beer “Beck’s”',1,2,20.5);
Insert into PRODUCTS (ID,PRODUCT_ID,NAME,VENDOR_ID,MEASURE_ID,PRICE) values (47,1030,'Vodka “Targovishte”',2,2,20.5);
Insert into PRODUCTS (ID,PRODUCT_ID,NAME,VENDOR_ID,MEASURE_ID,PRICE) values (48,1040,'Chocolate “Milka””',5,3,8);
REM INSERTING into VENDORS
SET DEFINE OFF;
Insert into VENDORS (ID,NAME) values (1,'Name1');
Insert into VENDORS (ID,NAME) values (2,'Name2');
Insert into VENDORS (ID,NAME) values (3,'Name3');
Insert into VENDORS (ID,NAME) values (4,'Name4');
Insert into VENDORS (ID,NAME) values (5,'Name5');
Insert into VENDORS (ID,NAME) values (6,'Name6');
Insert into VENDORS (ID,NAME) values (7,'Name7');
Insert into VENDORS (ID,NAME) values (8,'Name8');
Insert into VENDORS (ID,NAME) values (9,'Name9');
Insert into VENDORS (ID,NAME) values (10,'Name10');
Insert into VENDORS (ID,NAME) values (11,'Name11');
Insert into VENDORS (ID,NAME) values (12,'Name12');
Insert into VENDORS (ID,NAME) values (13,'Name13');
Insert into VENDORS (ID,NAME) values (14,'Name14');
Insert into VENDORS (ID,NAME) values (15,'Name15');
Insert into VENDORS (ID,NAME) values (16,'Name16');
Insert into VENDORS (ID,NAME) values (17,'Name17');
Insert into VENDORS (ID,NAME) values (18,'Name18');
Insert into VENDORS (ID,NAME) values (19,'Name19');
Insert into VENDORS (ID,NAME) values (20,'Name20');
Insert into VENDORS (ID,NAME) values (21,'Name21');
Insert into VENDORS (ID,NAME) values (22,'Name22');
Insert into VENDORS (ID,NAME) values (23,'Name23');
Insert into VENDORS (ID,NAME) values (24,'Name24');
Insert into VENDORS (ID,NAME) values (25,'Name25');
