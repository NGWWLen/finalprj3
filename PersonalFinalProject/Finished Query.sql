Select * from Reservations;

--DROP DATABASE PersonalFinalProject;

--Restaurant 
--DELETE FROM Restaurants;
INSERT into Restaurants (name) VALUES ('BeanScene');
Select * from Restaurants;

--Area
--DELETE FROM Areas;
INSERT into Areas (name,RestaurantId) VALUES ('Main', 1 );
INSERT into Areas (name,RestaurantId) VALUES ('Outside', 1);
INSERT into Areas (name,RestaurantId) VALUES ('Balcony', 1);
Select * from Areas;

--RestaurantTable
--DELETE FROM RestaurantTables;
INSERT into RestaurantTables(name,AreaId) VALUES ('M1', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M2', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M3', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M4', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M5', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M6', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M7', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M8', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M9', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('M10', 1);
INSERT into RestaurantTables(name,AreaId) VALUES ('O1', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O2', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O3', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O4', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O5', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O6', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O7', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O8', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O9', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('O10', 2);
INSERT into RestaurantTables(name,AreaId) VALUES ('B1', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B2', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B3', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B4', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B5', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B6', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B7', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B8', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B9', 3);
INSERT into RestaurantTables(name,AreaId) VALUES ('B10', 3);
Select * from RestaurantTables;


--SittingType
INSERT into SittingTypes(name) VALUES ('Breakfast');
INSERT into SittingTypes(name) VALUES ('Lunch');
INSERT into SittingTypes(name) VALUES ('Dinner');
INSERT into SittingTypes(name) VALUES ('Special Event');
Select * from SittingTypes;


DELETE from Sittings;
INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-01 07:00:00', '2023-01-01 11:00:00', 'Breakfast, 1 Jan', 40, 1, 1); 

INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-01 12:00:00', '2023-01-01 16:00:00', 'Lunch, 1 Jan', 40, 1, 2);

INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-01 18:00:00', '2023-01-01 23:00:00', 'Dinner, 1 Jan', 40, 1, 3);

INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-01 07:00:00', '2023-01-01 23:00:00', 'Special Events, 1 Jan', 40, 1, 4);


INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-02 07:00:00', '2023-01-02 11:00:00', 'Breakfast, 2 Jan', 40, 1, 1); 

INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-02 12:00:00', '2023-01-02 16:00:00', 'Lunch, 2 Jan', 40, 1, 2);

INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-02 18:00:00', '2023-01-02 23:00:00', 'Dinner, 2 Jan', 40, 1, 3);

INSERT into Sittings(StartTime, EndTime, Name, Capacity, Active, SittingTypeId) VALUES ('2023-01-02 07:00:00', '2023-01-02 23:00:00', 'Special Events, 2 Jan', 40, 1, 4);

Select * from Sittings;

--Reservation Source
INSERT into ReservationSources (name) VALUES ('Website');
INSERT into ReservationSources (name) VALUES ('Mobile App');
INSERT into ReservationSources (name) VALUES ('Email');
INSERT into ReservationSources (name) VALUES ('Phone Call');
INSERT into ReservationSources (name) VALUES ('In Person');
Select * from ReservationSources;

--Reservation Status
INSERT into ReservationStatuses (name) VALUES ('Pending');
INSERT into ReservationStatuses (name) VALUES ('Confirmed');
INSERT into ReservationStatuses (name) VALUES ('Canceled');
INSERT into ReservationStatuses (name) VALUES ('Seated');
INSERT into ReservationStatuses (name) VALUES ('Completed');
Select * from ReservationStatuses;

--Reservation --> Needs to do coding for this.
--When someone make a reservation, they have to enter :
--Start Time, Duration (2,4,15 *Whole Day*) ONLY NUMBER --> Need to update to code
--Guest Number, Notes, FN, LN, PN, Email
--ReservationStatus(Always 1 for Pending)
--ReservationSources(1,2,3,4,5)
--Email is written by the reserver
--UserEmail is to link the ID
--SittingId (1,2,3,4 - B L D Special) --> this should be automatically generated by looking up for database rather than user input

--DELETE from Reservations;
INSERT into Reservations (Start, Duration, GuestNumber, FirstName, LastName, PhoneNumber, Email, Notes, SittingId, ReservationStatusId, ReservationSourceId, AreaId)
	VALUES ('2023-02-01 07:30:00', 2, 4, 'Captain', 'Belle', '0483483483', 'Captain.Belle@gmail.com', '', 5, 1, 1, 1);
INSERT into Reservations (Start, Duration, GuestNumber, FirstName, LastName, PhoneNumber, Email, Notes, SittingId, ReservationStatusId, ReservationSourceId, AreaId)
	VALUES ('2023-01-01 07:00:00', 4, 20, 'Zeth', 'Relics', '0444123123', 'Zeth.Relics@gmail.com', '', 7, 2, 4, NULL);
Select * from Reservations;
Select * from Areas;

--ReservationTable
-- Once reservation is made, ReservationTable table will be automatically generated by the back-end
-- Example for first reservation
--RestaurantTable 21~24 = Balcony1-4 should be randomly generated from available tables
--lets assume 1 table is for 1 person
-- Example for second reservation
--RestaurantTable 1~20 = Main & Outside 1-10 should be chosen by Manager (need a window to pick tables)
--lets assume 1 table is for 1 person

INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (1, 1); 
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (1, 2); 
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (1, 3); 
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (1, 4); 
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 1);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 2);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 3);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 4);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 5);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 6);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 7);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 8);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 9);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 10);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 11);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 12);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 13);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 14);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 15);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 16);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 17);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 18);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 19);
INSERT into ReservationTables(ReservationId, RestaurantTableId) VALUES (2, 20);
Select * from ReservationTables;
