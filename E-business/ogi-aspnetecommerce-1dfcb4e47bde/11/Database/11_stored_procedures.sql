USE BalloonShop

GO

CREATE PROCEDURE CatalogAddDepartment
(@DepartmentName nvarchar(50),
@DepartmentDescription nvarchar(1000))
AS
INSERT INTO Department (Name, Description)
VALUES (@DepartmentName, @DepartmentDescription)

GO

CREATE PROCEDURE CatalogUpdateDepartment
(@DepartmentID int,
@DepartmentName nvarchar(50),
@DepartmentDescription nvarchar(1000))
AS
UPDATE Department
SET Name = @DepartmentName, Description = @DepartmentDescription
WHERE DepartmentID = @DepartmentID

GO

CREATE PROCEDURE CatalogDeleteDepartment
(@DepartmentID int)
AS
DELETE FROM Department
WHERE DepartmentID = @DepartmentID

GO

CREATE PROCEDURE CatalogCreateCategory
(@DepartmentID int,
@CategoryName nvarchar(50),
@CategoryDescription nvarchar(50))
AS
INSERT INTO Category (DepartmentID, Name, Description)
VALUES (@DepartmentID, @CategoryName, @CategoryDescription)

Go

CREATE PROCEDURE CatalogUpdateCategory
(@CategoryID int,
@CategoryName nvarchar(50),
@CategoryDescription nvarchar(1000))
AS
UPDATE Category
SET Name = @CategoryName, Description = @CategoryDescription
WHERE CategoryID = @CategoryID

GO

CREATE PROCEDURE CatalogDeleteCategory
(@CategoryID int)
AS
DELETE FROM Category
WHERE CategoryID = @CategoryID

