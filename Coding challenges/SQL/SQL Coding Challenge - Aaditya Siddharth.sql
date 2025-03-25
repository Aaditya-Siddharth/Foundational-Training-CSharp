Use PetPals

-- Creating Pets table
CREATE TABLE Pets (PetID INT PRIMARY KEY Identity(1,1), Name VARCHAR(100) NOT NULL, Age INT NOT NULL, Breed VARCHAR(100) NOT NULL, Type VARCHAR(50) NOT NULL,
    AvailableForAdoption BIT NOT NULL);

-- Creating the Shelters table
CREATE TABLE Shelters ( ShelterID INT PRIMARY KEY Identity(100,1) , Name VARCHAR(max) NOT NULL, Location VARCHAR(max) NOT NULL);

-- Creating the Donations table
CREATE TABLE Donations(DonationID INT PRIMARY KEY IDENTITY(200,1), DonorName VARCHAR(MAX) NOT NULL, DonationType VARCHAR(50) NOT NULL,
    DonationAmount DECIMAL(12,2) DEFAULT NULL, DonationItem VARCHAR(100) DEFAULT NULL, DonationDate DATE NOT NULL)

--Creating the AdoptionEvents table
Create table AdoptionEvents(EventID INT PRIMARY KEY Identity(300,1), EventName VARCHAR(max) NOT NULL, EventDate DATE NOT NULL, Location VARCHAR(255) NOT NULL);

-- Creating the participants table
Create table Participants (ParticipantID INT PRIMARY KEY IDENTITY(400,1),ParticipantName VARCHAR(max) NOT NULL,ParticipantType VARCHAR(50) NOT NULL, EventID INT,
    Constraint FK_Participant_Event FOREIGN KEY (EventID) REFERENCES AdoptionEvents(EventID))

--Insert values
INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption) VALUES  
('Simba', 4, 'Golden Retriever', 'Dog', 1),  
('Whiskers', 3, 'Sphynx', 'Cat', 1),    
('Coco', 2, 'German Shepherd', 'Dog', 1),  
('Lily', 3, 'Indian puff', 'Cat', 1),  
('Rio', 2, 'Macaw', 'Bird', 1),  
('Mithu', 1, 'Parrot', 'Bird', 1),  
('Snowy', 4, 'Angora', 'Rabbit', 0),  
('Fluffy', 3, 'Lionhead', 'Rabbit', 1);  

--Inserting into Shelters table

Insert Into Shelters VALUES ('Chennai Animal Rescue Center', 'Chennai, Tamil Nadu'),  
('Coimbatore Pet Haven', 'Coimbatore, Tamil Nadu'),  
('Palakkad Stray Care', 'Palakkad, Kerala'),  
('Banglore Paws Shelter', 'Banglore, Karnataka'),  
('Hyderabad Animal Welfare Society', 'Hyderabad, Andhra Pradesh');  

-- inserting into donations table

Insert into Donations (DonorName, DonationType, DonationAmount, DonationItem, DonationDate)  
VALUES  
('Ravi Kumar', 'Cash', 5000.00, NULL, '2024-03-01'),  
('Priya Sharma', 'Item', NULL, 'Dog Food', '2024-03-05'),  
('Arun Das', 'Cash', 7500.00, NULL, '2024-03-10'),  
('Meera Iyer', 'Item', NULL, 'Cat Medicine', '2024-03-15'),  
('Suresh Nair', 'Cash', 10000.00, NULL, '2024-03-20'),
('Anita Raj', 'Cash', 6500.00, NULL, '2024-03-22'),  
('Vikram Singh', 'Item', NULL, 'Dog Beds', '2024-03-25'),  
('Deepa Menon', 'Cash', 8500.00, NULL, '2024-03-28'),  
('Rohan Verma', 'Item', NULL, 'Bird Feed', '2024-03-30'),  
('Kavitha Krishnan', 'Cash', 12000.00, NULL, '2024-04-02');

-- Inserting values for AdoptionEvents
Insert into AdoptionEvents Values ('Chennai Mega Adoption Drive', '2024-04-05', 'Chennai, Tamil Nadu'),  
('Coimbatore Pet Fest', '2024-04-10', 'Coimbatore, Tamil Nadu'),  
('Madurai Stray Adoption Camp', '2024-04-15', 'Madurai, Tamil Nadu'),  
('Bangalore Paws Meet', '2024-04-20', 'Bangalore, Karnataka'),  
('Hyderabad Animal Welfare Expo', '2024-04-25', 'Hyderabad, Telangana');  

-- Insert into participants
INSERT INTO Participants VALUES ('Chennai Animal Rescue Center', 'Shelter', 300),  
('Coimbatore Pet Haven', 'Shelter', 301),  
('Ravi Kumar', 'Adopter', 300),  
('Meera Iyer', 'Adopter', 302),  
('Hyderabad Animal Welfare Society', 'Shelter', 304);  

-- Select available pets

Select Name, Age, Breed, Type from Pets where AvailableForAdoption <> 0;

-- Select participants of the specified events
Select p.ParticipantName, e.EventName from Participants as p
Join
AdoptionEvents as e on p.EventID = e.EventID
where p.EventID = 300;

-- Procedure to Update shelter information

Select * from Shelters

CREATE PROCEDURE UpdateShelterInfo @shelterID INT, @ShelterName varchar(max), @ShelterLoc varchar(max)
As
Begin
Update Shelters set Name = @ShelterName where ShelterID = @shelterID;
Update Shelters set Location = @ShelterLoc where ShelterID = @shelterID;
End;
Go

Exec UpdateShelterInfo @ShelterID = 101 , @ShelterName = 'Coimbatore Pet Heaven', @shelterLoc = 'Ganapathy, Coimbatore, Tamil Nadu';



-- Setting up for next query
Select * from Shelters
Select * from Donations

alter table Donations Add ShelterID INT
Alter table Donations Add constraint FK_Donation_Shelter Foreign key(ShelterID) references Shelters(ShelterID);

Update Donations set ShelterID = 101 where DonationID = 209;
Select * from Donations;

--total donations per shelter

Select s.Name as ShelterName, SUM(d.DonationAmount) AS TotalDonation  
From Shelters as s  
JOIN Donations as d 
ON s.ShelterID = d.ShelterID  
Group by s.Name;

-- seting up
Alter table Pets ADD OwnerID INT NULL;
Alter table pets add constraint FK_PET_ADOPTER foreign key(ownerID) references participants(participantID)
Update pets set ownerID = 402 where PetID = 3
Update pets set ownerID = 403 where PetID = 5

Select * from Pets

-- pets without owners

Select Name, Age, Breed, Type  
From Pets  
Where OwnerID IS NULL;

-- 10 

-- Distict breeds between age group
Select distinct Breed , Name, Age
From Pets  
Where Age BETWEEN 1 AND 3 OR Age > 5
order by age DESC;

-- pets available for adoption and their shelters

alter table pets add shelterID int 

update pets set shelterID = 103 where petId = 1
Select * from pets
Select * from Shelters

Select * from pets
SELECT p.Name AS PetName, s.Name AS ShelterName  
FROM Pets p  
JOIN Shelters s ON p.shelterId = s.ShelterID  
WHERE p.AvailableForAdoption =1;


--number of participants in events
select count(p.ParticipantID) as participantscount, e.EventName from participants as p
join AdoptionEvents as e
on p.EventID = e.EventID
group by e.EventName
having e.EventName like '%Chennai%';

-- unique breeds for pets with ages between 1 and 5 years. 

Select breed, name, age from Pets where age between 1 and 5


-- pets that are not adopted
Select name, breed, type, AvailableForAdoption from pets where AvailableForAdoption <>0;

-- adopted pets and their adopters name

Select p.name, a.participantname from pets as p
Join 
Participants as a
on p.ownerID = a.ParticipantID
Group by p.name, a.ParticipantName

--list of all shelters along with the count of pets currently available for adoption
SELECT s.Name AS ShelterName, COUNT(p.PetID) AS AvailablePets  
FROM Shelters s  
Left JOIN Pets p ON s.ShelterID = p.ShelterID AND p.AvailableForAdoption = 1  
GROUP BY s.Name;

--pair of pets of same breed

SELECT p1.Name AS Pet1, p2.Name AS Pet2, p1.Breed, s.Name AS ShelterName  
FROM Pets p1  
JOIN Pets p2 ON p1.ShelterID = p2.ShelterID  
AND p1.Breed = p2.Breed  
AND p1.PetID <> p2.PetID  
JOIN Shelters s ON p1.ShelterID = s.ShelterID  
ORDER BY s.Name, p1.Breed;

--List all possible combinations of shelters and adoption events. 
SELECT s.Name AS ShelterName, e.EventName  
FROM Shelters s  
CROSS JOIN AdoptionEvents e  
ORDER BY s.Name, e.EventName;


--shelter that has the highest number of adopted pets.
Select * from pets
SELECT TOP 1 s.Name AS ShelterName, COUNT(p.PetID) AS AdoptedPets  
FROM Shelters s  
JOIN Pets p ON s.ShelterID = p.ShelterID   
GROUP BY s.Name  
ORDER BY COUNT(p.PetID) DESC;