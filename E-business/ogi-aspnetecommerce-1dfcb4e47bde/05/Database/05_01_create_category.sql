USE BalloonShop

GO

---
--- CATEGORY
---

CREATE TABLE Category(
	CategoryID INT IDENTITY(1,1) NOT NULL,
	DepartmentID INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(1000) NULL,
 CONSTRAINT PK_Category_1 PRIMARY KEY CLUSTERED(CategoryID ASC)
)

GO

ALTER TABLE Category ADD CONSTRAINT FK_Category_Department FOREIGN KEY(DepartmentID)
REFERENCES Department (DepartmentID)

GO
