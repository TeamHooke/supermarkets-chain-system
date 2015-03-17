DROP TABLE IF EXISTS "ProductTaxes";
CREATE TABLE "ProductTaxes" ("Id" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , "Name" VARCHAR NOT NULL , "Tax" DOUBLE NOT NULL );
INSERT INTO "ProductTaxes" VALUES(1,'Chocolade bar',12.2);
INSERT INTO "ProductTaxes" VALUES(2,'Glass Bottle',2.5);
INSERT INTO "ProductTaxes" VALUES(3,'Rakia',1.2);
INSERT INTO "ProductTaxes" VALUES(4,'Fanta',23.4);
INSERT INTO "ProductTaxes" VALUES(5,'Nuts',15);
INSERT INTO "ProductTaxes" VALUES(6,'Video Card Ati Radeon HD 1200',23);
INSERT INTO "ProductTaxes" VALUES(7,'Windows 10',19.99);
