USE BalloonShop

-- Create AttributeValue table (stores values such as Yellow or XXL)
CREATE TABLE AttributeValue (
  AttributeValueID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  AttributeID INT NOT NULL, -- The ID of the attribute
  Value NVARCHAR(100) NOT NULL -- E.g. Yellow
)

-- Set the IDENTITY INSERT option for AttributeValue
SET IDENTITY_INSERT AttributeValue ON;

-- Populate AttributeValue table 
INSERT INTO AttributeValue (AttributeValueID, AttributeID, Value)
SELECT 1, 1, 'White' UNION ALL
SELECT 2, 1, 'Black' UNION ALL
SELECT 3, 1, 'Red' UNION ALL
SELECT 4, 1, 'Orange' UNION ALL
SELECT 5, 1, 'Yellow' UNION ALL
SELECT 6, 1, 'Green' UNION ALL
SELECT 7, 1, 'Blue' UNION ALL
SELECT 8, 1, 'Indigo' UNION ALL
SELECT 9, 1, 'Purple';

-- Set the IDENTITY INSERT option for AttributeValue
SET IDENTITY_INSERT AttributeValue OFF;
