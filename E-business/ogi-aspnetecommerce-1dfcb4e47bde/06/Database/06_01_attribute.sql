-- Connect to the BalloonShop database
USE BalloonShop

-- Create attribute table (stores attributes such as Size and Color)
CREATE TABLE Attribute (
  AttributeID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Name NVARCHAR(100) NOT NULL -- e.g. Color, Size
) 

-- Populate Attribute table
SET IDENTITY_INSERT Attribute ON

INSERT INTO Attribute (AttributeID, Name) 
VALUES (1, 'Color');

SET IDENTITY_INSERT Attribute OFF
