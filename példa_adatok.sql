SET IDENTITY_INSERT [dbo].[CarManufacturer] ON
insert into [dbo].[CarManufacturer](Id, Name) values (1, 'manufacturer-100');
insert into [dbo].[CarManufacturer](Id, Name) values (2, 'manufacturer-200');
insert into [dbo].[CarManufacturer](Id, Name) values (3, 'manufacturer-300');
SET IDENTITY_INSERT [dbo].[CarManufacturer] OFF

SET IDENTITY_INSERT [dbo].[ModelDetail] ON
insert into [dbo].[ModelDetail](Id, YearOfManufacture, Price, Seats) values (1, 2010, 3000000, 4);
insert into [dbo].[ModelDetail](Id, YearOfManufacture, Price, Seats) values (2, 2013, 5000000, 5);
insert into [dbo].[ModelDetail](Id, YearOfManufacture, Price, Seats) values (3, 2008, 1000000, 6);
SET IDENTITY_INSERT [dbo].[ModelDetail] OFF

SET IDENTITY_INSERT [dbo].[CarModel] ON
insert into [dbo].[CarModel](Id, Name, ModelDetailId, CarManufacturerId) values (1, 'model-101',1,1);
insert into [dbo].[CarModel](Id, Name, ModelDetailId, CarManufacturerId) values (2, 'model-102',2,1);
insert into [dbo].[CarModel](Id, Name, ModelDetailId, CarManufacturerId) values (3, 'model-201',3,2);
SET IDENTITY_INSERT [dbo].[CarModel] OFF