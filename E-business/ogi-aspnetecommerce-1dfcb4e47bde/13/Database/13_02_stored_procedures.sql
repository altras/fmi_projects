USE BalloonShop

GO

CREATE Procedure ShoppingCartAddItem
(@CartID char(36),
 @ProductID int,
 @Attributes nvarchar(1000))
AS
IF EXISTS
        (SELECT CartID
         FROM ShoppingCart
         WHERE ProductID = @ProductID AND CartID = @CartID)
    UPDATE ShoppingCart
    SET Quantity = Quantity + 1
    WHERE ProductID = @ProductID AND CartID = @CartID
ELSE
    IF EXISTS (SELECT Name FROM Product WHERE ProductID=@ProductID)
        INSERT INTO ShoppingCart (CartID, ProductID, Attributes, Quantity, DateAdded)
        VALUES (@CartID, @ProductID, @Attributes, 1, GETDATE())

Go

CREATE PROCEDURE ShoppingCartRemoveItem
(@CartID char(36),
 @ProductID int)
AS
DELETE FROM ShoppingCart
WHERE CartID = @CartID and ProductID = @ProductID

GO

CREATE Procedure ShoppingCartUpdateItem
(@CartID char(36),
 @ProductID int,
 @Quantity int)
AS
IF @Quantity <= 0
  EXEC ShoppingCartRemoveItem @CartID, @ProductID
ELSE
  UPDATE ShoppingCart
  SET Quantity = @Quantity, DateAdded = GETDATE()
  WHERE ProductID = @ProductID AND CartID = @CartID

GO

CREATE PROCEDURE ShoppingCartGetItems
(@CartID char(36))
AS
SELECT Product.ProductID, Product.Name, ShoppingCart.Attributes, Product.Price, ShoppingCart.Quantity,Product.Price * ShoppingCart.Quantity AS Subtotal
FROM ShoppingCart INNER JOIN Product
ON ShoppingCart.ProductID = Product.ProductID
WHERE ShoppingCart.CartID = @CartID

GO

CREATE PROCEDURE ShoppingCartGetTotalAmount
(@CartID char(36))
AS
SELECT ISNULL(SUM(Product.Price * ShoppingCart.Quantity), 0)
FROM ShoppingCart INNER JOIN Product
ON ShoppingCart.ProductID = Product.ProductID
WHERE ShoppingCart.CartID = @CartID

Go

ALTER PROCEDURE CatalogDeleteProduct
(@ProductID int)
AS
DELETE FROM ShoppingCart WHERE ProductID=@ProductID
DELETE FROM ProductCategory WHERE ProductID=@ProductID
DELETE FROM Product where ProductID=@ProductID

GO

CREATE PROCEDURE ShoppingCartDeleteOldCarts
(@Days smallint)
AS
DELETE FROM ShoppingCart
WHERE CartID IN
(SELECT CartID
FROM ShoppingCart
GROUP BY CartID
HAVING MIN(DATEDIFF(dd,DateAdded,GETDATE())) >= @Days)


GO

CREATE PROCEDURE ShoppingCartCountOldCarts
(@Days smallint)
AS
SELECT COUNT(CartID)
FROM ShoppingCart
WHERE CartID IN
(SELECT CartID
FROM ShoppingCart
GROUP BY CartID
HAVING MIN(DATEDIFF(dd,DateAdded,GETDATE())) >= @Days)



