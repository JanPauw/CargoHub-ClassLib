CREATE DATABASE DevHub

create table [tblEmployees]
(
    [empNum] varchar(10) NOT NULL,
    [empName] VARCHAR(50),
    [empContact] VARCHAR(13),
    [empRole] VARCHAR(255),

    PRIMARY KEY (empNum),
);

create table [tblUsers]
(
    [Username] varchar(255),
    [Password] varchar(max),
    [empNum] varchar(10) NOT NULL,

    PRIMARY KEY (Username),
    FOREIGN KEY (empNum) REFERENCES tblEmployees(empNum),
);

 CREATE TABLE tblTimesheet
 (
    [workEntry] int IDENTITY (1,1) NOT NULL,
    [empNum] varchar(10) NOT NULL,
    [workDate] date,
    [workHours] int,

    PRIMARY KEY (workEntry),
    FOREIGN KEY (empNum) REFERENCES tblEmployees(empNum),
 );

  CREATE TABLE tblJobs
 (
    [jobID] int IDENTITY (1,1) NOT NULL,
    [jodDesc] VARCHAR(225),
    [empNum] VARCHAR(10),

    PRIMARY KEY (jobID),
    FOREIGN KEY (empNum) REFERENCES tblEmployees(empNum),
 );

  CREATE TABLE tblVehicles
 (
    [vehRegNum] VARCHAR(10),
    [vehType] VARCHAR(50),
    [vehManufacturer] VARCHAR(50),
    [vehEngineSize] VARCHAR(25),
    [vehOdoReading] VARCHAR(25),
    [vehNextService] VARCHAR(25),
    [vehStatus] VARCHAR(255),
    [empNum] VARCHAR(10),

    PRIMARY KEY (vehRegNum),
    FOREIGN KEY (empNum) REFERENCES tblEmployees(empNum),
 );

  CREATE TABLE tblVehicleServicing
 (
    [servCode] int IDENTITY (1,1) NOT NULL,
    [vehRegNum] VARCHAR(10),
    [servTime] VARCHAR(7),
    [servType] VARCHAR(50),
    [servDesc] VARCHAR(225),

    PRIMARY KEY (servCode),
    FOREIGN KEY (vehRegNum) REFERENCES tblVehicles(vehRegNum),
 );

  CREATE TABLE tblCustomers
 (
    [custID] int IDENTITY (1,1) NOT NULL,
    [custName] VARCHAR(50),
    [custAddress] VARCHAR(50),
    [custProvince] VARCHAR(50),
    [custEmail] VARCHAR(50),
    [custNum] VARCHAR(13),

    PRIMARY KEY (custID),
 );

  CREATE TABLE tblOrders
 (
    [ordNum] VARCHAR(10),
    [ordCargo] VARCHAR(MAX),
    [ordQuantity] int,
    [toDepot] varchar(255),
    [fromDepot] varchar(255),
    [custID] int,
    [ordDate] date,
    [ordStatus] varchar(255),
    [empNum] VARCHAR(10) NOT NULL,

    PRIMARY KEY (ordNum),
    FOREIGN KEY (custID) REFERENCES tblCustomers(custID),
);

 CREATE TABLE tblInvoice
 (
    [invNum] int IDENTITY (1,1) NOT NULL,
    [ordNum] int,

    PRIMARY KEY (invNum),
    FOREIGN KEY (ordNum) REFERENCES tblOrder(ordID),
 );

  CREATE TABLE tblTrip
 (
    [ordNum] VARCHAR(10),
    [tripPickup] VARCHAR(50),
    [tripDestination] VARCHAR(50),
    [tripDistance] VARCHAR(50),

    PRIMARY KEY (ordNum),
    FOREIGN KEY (ordNum) REFERENCES tblOrders(ordNum),
 );

  CREATE TABLE tblDelivery
 (
    [deliveryID] int IDENTITY (1,1) NOT NULL,
    [vehID] int,
    [ordNum] int,
    [tripID] int,

    PRIMARY KEY (deliveryID),
    FOREIGN KEY (vehID) REFERENCES tblVehicles(vehID),
    FOREIGN KEY (ordNum) REFERENCES tblOrder(ordID),
    FOREIGN KEY (tripID) REFERENCES tblTrip(tripID),
 );

  CREATE TABLE tblDepot
 (
    [depID] int IDENTITY (1,1) NOT NULL,
    [depAddress] VARCHAR(50),
    [depProvince] VARCHAR(50),
    [depNum] VARCHAR(10),

    PRIMARY KEY (depID),
 );

 INSERT tblEmployees
VALUES ('AD00001', 'Admin', '0000000000', 'Admin');