USE BalloonShop

GO

CREATE PROCEDURE CatalogGetAllProductsInCategory
(@CategoryID INT)
AS
SELECT Product.ProductID, Name, Description, Price, Thumbnail, 
       Image, PromoDept, PromoFront
FROM Product INNER JOIN ProductCategory
  ON Product.ProductID = ProductCategory.ProductID
WHERE ProductCategory.CategoryID = @CategoryID

GO

CREATE PROCEDURE CatalogCreateProduct
(@CategoryID INT,
 @ProductName NVARCHAR(50),
 @ProductDescription NVARCHAR(MAX),
 @Price MONEY,
 @Thumbnail NVARCHAR(50),
 @Image NVARCHAR(50),
 @PromoFront BIT,
 @PromoDept BIT)
AS
-- Declare a variable to hold the generated product ID
DECLARE @ProductID int
-- Create the new product entry

INSERT INTO Product 
    (Name, 
     Description, 
     Price, 
     Thumbnail, 
     Image,
     PromoFront, 
     PromoDept)
VALUES 
    (@ProductName, 
     @ProductDescription, 
     @Price, 
     @Thumbnail, 
     @Image,
     @PromoFront, 
     @PromoDept)
-- Save the generated product ID to a variable
SELECT @ProductID = @@Identity
-- Associate the product with a category
INSERT INTO ProductCategory (ProductID, CategoryID)
VALUES (@ProductID, @CategoryID)

GO

CREATE PROCEDURE CatalogUpdateProduct
(@ProductID INT,
 @ProductName NVARCHAR(50),
 @ProductDescription NVARCHAR(MAX),
 @Price MONEY,
 @Thumbnail NVARCHAR(50),
 @Image NVARCHAR(50),
 @PromoFront BIT,
 @PromoDept BIT)
AS
UPDATE Product
SET Name = @ProductName,
    Description = @ProductDescription,
    Price = @Price,
    Thumbnail = @Thumbnail,
    Image = @Image,
    PromoFront = @PromoFront,
    PromoDept = @PromoDept
WHERE ProductID = @ProductID

GO

CREATE PROCEDURE CatalogGetCategoriesWithProduct
(@ProductID int)
AS
SELECT Category.CategoryID, Name
FROM Category INNER JOIN ProductCategory
ON Category.CategoryID = ProductCategory.CategoryID
WHERE ProductCategory.ProductID = @ProductID

GO

CREATE PROCEDURE CatalogGetCategoriesWithoutProduct
(@ProductID int)
AS
SELECT CategoryID, Name
FROM Category
WHERE CategoryID NOT IN
   (SELECT Category.CategoryID
    FROM Category INNER JOIN ProductCategory
    ON Category.CategoryID = ProductCategory.CategoryID
    WHERE ProductCategory.ProductID = @ProductID)

GO

CREATE PROCEDURE CatalogAssignProductToCategory
(@ProductID int, @CategoryID int)
AS
INSERT INTO ProductCategory (ProductID, CategoryID)
VALUES (@ProductID, @CategoryID)

GO
CREATE PROCEDURE CatalogMoveProductToCategory
(@ProductID int, @OldCategoryID int, @NewCategoryID int)
AS
UPDATE ProductCategory
SET CategoryID = @NewCategoryID
WHERE CategoryID = @OldCategoryID
  AND ProductID = @ProductID

GO

CREATE PROCEDURE CatalogRemoveProductFromCategory
(@ProductID int, @CategoryID int)
AS
DELETE FROM ProductCategory
WHERE CategoryID = @CategoryID AND ProductID = @ProductID

GO

CREATE PROCEDURE CatalogDeleteProduct
(@ProductID INT)
AS
DELETE FROM ProductCategory WHERE ProductID=@ProductID
DELETE FROM Product where ProductID=@ProductID
