USE BalloonShop

GO

CREATE PROCEDURE CatalogGetDepartments AS
SELECT DepartmentID, Name, Description
FROM Department
