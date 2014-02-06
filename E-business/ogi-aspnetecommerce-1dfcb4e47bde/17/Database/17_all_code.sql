USE BalloonShop

GO

-- Adding the three new fields: customer_id, auth_code and reference.
ALTER TABLE Orders ADD CustomerID UNIQUEIDENTIFIER;
ALTER TABLE Orders ADD Status     INT DEFAULT 0;
ALTER TABLE Orders ADD AuthCode   VARCHAR(50);
ALTER TABLE Orders ADD Reference  VARCHAR(50);

GO

CREATE PROCEDURE CreateCustomerOrder 
(@CartID char(36),
 @CustomerID uniqueidentifier)
AS
/* Insert a new record into Orders */
DECLARE @OrderID int
INSERT INTO Orders (CustomerID) VALUES (@CustomerID)
/* Save the new Order ID */
SET @OrderID = @@IDENTITY
/* Add the order details to OrderDetail */
INSERT INTO OrderDetail 
     (OrderID, ProductID, ProductName, Quantity, UnitCost)
SELECT 
     @OrderID, Product.ProductID, Product.Name, 
     ShoppingCart.Quantity, Product.Price
FROM Product JOIN ShoppingCart
ON Product.ProductID = ShoppingCart.ProductID
WHERE ShoppingCart.CartID = @CartID
/* Clear the shopping cart */
DELETE FROM ShoppingCart
WHERE CartID = @CartID
/* Return the Order ID */
SELECT @OrderID

GO

CREATE PROCEDURE CommerceLibOrderGetInfo
(@OrderID int)
AS
SELECT OrderID, 
       DateCreated, 
       DateShipped, 
       Comments, 
       Status, 
       CustomerID, 
       AuthCode,
       Reference
FROM Orders
WHERE OrderID = @OrderID

GO

CREATE TABLE Tax (
  TaxID INT NOT NULL PRIMARY KEY,
  TaxType NVARCHAR(100) NOT NULL,
  TaxPercentage FLOAT NOT NULL
) 


GO

INSERT INTO TAX (TaxID, TaxType, TaxPercentage) 
VALUES (1, 'Sales Tax at 8.5%', 8.5), 
       (2, 'No Tax', 0)

GO

CREATE TABLE Shipping (
  ShippingID INT NOT NULL PRIMARY KEY,
  ShippingType NVARCHAR(100) NOT NULL,
  ShippingCost MONEY NOT NULL,
  ShippingRegionID INT REFERENCES ShippingRegion (ShippingRegionID)
) 

GO

INSERT INTO Shipping (ShippingID, ShippingType, ShippingCost, ShippingRegionID) 
VALUES (1, 'Next Day Delivery ($20)', 20, 2),
       (2, '3-4 Days ($10)', 10, 2),
       (3, '7 Days ($5)', 5, 2),
       (4, 'By Air (7 Days, $25)', 25, 3),
       (5, 'By Sea (28 days, $10)', 10, 3),
       (6, 'By Air (10 days, $35)', 35, 4),
       (7, 'By Sea (38 days, $30)', 30, 4)

GO

ALTER TABLE Orders ADD TaxID INT;
ALTER TABLE Orders ADD ShippingID INT;

ALTER TABLE Orders ADD CONSTRAINT FK_Orders_Tax 
FOREIGN KEY(TaxID) REFERENCES Tax (TaxID)

ALTER TABLE Orders ADD CONSTRAINT FK_Orders_Shipping 
FOREIGN KEY(ShippingID) REFERENCES Shipping (ShippingID)

GO

ALTER PROCEDURE CommerceLibOrderGetInfo
(@OrderID int)
AS
SELECT OrderID, 
       DateCreated, 
       DateShipped, 
       Comments, 
       Status, 
       CustomerID, 
       AuthCode,
       Reference,
       Orders.ShippingID,
       ShippingType,
       ShippingCost,
       Orders.TaxID,
       TaxType,
       TaxPercentage
FROM Orders 
LEFT OUTER JOIN Tax ON Tax.TaxID = Orders.TaxID
LEFT OUTER JOIN Shipping ON Shipping.ShippingID = Orders.ShippingID
WHERE OrderID = @OrderID

GO

ALTER PROCEDURE CreateCustomerOrder 
(@CartID char(36),
 @CustomerID uniqueidentifier,
 @ShippingID int,
 @TaxID int)
AS
/* Insert a new record into Orders */
DECLARE @OrderID int
INSERT INTO Orders (CustomerID, ShippingID, TaxID) 
VALUES (@CustomerID, @ShippingID, @TaxID)
/* Save the new Order ID */
SET @OrderID = @@IDENTITY
/* Add the order details to OrderDetail */
INSERT INTO OrderDetail 
     (OrderID, ProductID, ProductName, Quantity, UnitCost)

SELECT 
     @OrderID, Product.ProductID, Product.Name, 
     ShoppingCart.Quantity, Product.Price
FROM Product JOIN ShoppingCart
ON Product.ProductID = ShoppingCart.ProductID
WHERE ShoppingCart.CartID = @CartID
/* Clear the shopping cart */
DELETE FROM ShoppingCart
WHERE CartID = @CartID
/* Return the Order ID */
SELECT @OrderID

GO

CREATE PROCEDURE CommerceLibShippingGetInfo
(@ShippingRegionID int)
AS
SELECT ShippingID,
       ShippingType,
       ShippingCost
FROM Shipping
WHERE ShippingRegionID = @ShippingRegionID
