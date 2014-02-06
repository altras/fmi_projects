USE BalloonShop

GO

-- Create review table
CREATE TABLE Review (
  ReviewID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  CustomerID UNIQUEIDENTIFIER NOT NULL,
  ProductID INT NOT NULL REFERENCES Product (ProductID),
  Review NVARCHAR(MAX) NOT NULL,
  DateCreated DATETIME NOT NULL)

GO

-- Create CatalogGetProductReviews stored procedure
CREATE PROCEDURE CatalogGetProductReviews(@ProductID INT)
AS
SELECT u.UserName as CustomerName,
       r.Review as ProductReview,
       r.DateCreated as ReviewDate
FROM Review r
INNER JOIN aspnet_Users u ON u.UserId = r.CustomerID
WHERE r.ProductID = @ProductID
ORDER BY r.DateCreated DESC

GO

-- Create CatalogAddProductReview stored procedure
CREATE PROCEDURE CatalogAddProductReview
(@CustomerId UNIQUEIDENTIFIER, @ProductId INT, @Review NVARCHAR(MAX))
AS
INSERT INTO Review (CustomerID, ProductID, Review, DateCreated)
   VALUES (@CustomerId, @ProductId, @Review, GETDATE())

GO

