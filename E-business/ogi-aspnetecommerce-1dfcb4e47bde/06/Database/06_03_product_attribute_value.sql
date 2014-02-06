USE BalloonShop

-- Create ProductAttributeValue table (associates attribute values to products)
CREATE TABLE ProductAttributeValue (
  ProductID INT NOT NULL,
  AttributeValueID INT NOT NULL,
  PRIMARY KEY (ProductID, AttributeValueID)
)

-- Populate ProductAttributeValue table
INSERT INTO ProductAttributeValue (ProductID, AttributeValueID)
SELECT p.ProductID, av.AttributeValueID
FROM product p, AttributeValue av;
