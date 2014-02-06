USE BalloonShop

GO

CREATE PROCEDURE CommerceLibOrderGetAuditTrail
(@OrderID int)
AS
SELECT OrderID, 
       AuditID,
       DateStamp, 
       Message, 
       MessageNumber
FROM Audit
WHERE OrderID = @OrderID

GO

CREATE PROCEDURE CommerceLibOrdersGetByCustomer
(@CustomerID uniqueidentifier)
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
WHERE CustomerID = @CustomerID

GO

CREATE PROCEDURE CommerceLibOrdersGetByDate 
(@StartDate smalldatetime,
 @EndDate smalldatetime)
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
WHERE DateCreated BETWEEN @StartDate AND @EndDate
ORDER BY DateCreated DESC

Go

CREATE PROCEDURE CommerceLibOrdersGetByRecent 
(@Count smallint)
AS

SET ROWCOUNT @Count

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
ORDER BY DateCreated DESC

SET ROWCOUNT 0

GO

CREATE PROCEDURE CommerceLibOrdersGetByStatus
(@Status int)
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
WHERE Status = @Status

GO

CREATE PROCEDURE CommerceLibOrderUpdate
(@OrderID int,
 @DateCreated smalldatetime,
 @DateShipped smalldatetime = NULL,
 @Status int,
 @Comments nvarchar(200),
 @AuthCode varchar(50),
 @Reference varchar(50))
AS
UPDATE Orders
SET DateCreated=@DateCreated,
    DateShipped=@DateShipped,
    Status=@Status,
    Comments=@Comments,
    AuthCode=@AuthCode,
    Reference=@Reference
WHERE OrderID = @OrderID

GO

