USE BalloonShop

GO

CREATE TABLE ProductCategory(
	ProductID INT NOT NULL,
	CategoryID INT NOT NULL,
 CONSTRAINT PK_ProductCategory PRIMARY KEY CLUSTERED (ProductID ASC, CategoryID ASC)
) 

GO

ALTER TABLE ProductCategory  WITH CHECK ADD CONSTRAINT FK_ProductCategory_Category FOREIGN KEY(CategoryID)
REFERENCES Category (CategoryID)

GO

ALTER TABLE ProductCategory  WITH CHECK ADD  CONSTRAINT FK_ProductCategory_Product FOREIGN KEY(ProductID)
REFERENCES Product (ProductID)
