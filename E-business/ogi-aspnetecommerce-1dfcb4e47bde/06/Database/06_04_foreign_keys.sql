USE BalloonShop

-- Create the foreign keys
ALTER TABLE AttributeValue ADD CONSTRAINT FK_AttributeValue_Attribute FOREIGN KEY(AttributeID)
REFERENCES Attribute (AttributeID)
GO
ALTER TABLE ProductAttributeValue ADD CONSTRAINT FK_ProductAttributeValue_AttributeValue FOREIGN KEY(AttributeValueID)
REFERENCES AttributeValue (AttributeValueID)
GO
ALTER TABLE ProductAttributeValue WITH CHECK ADD CONSTRAINT FK_ProductAttributeValue_Product FOREIGN KEY(ProductID)
REFERENCES Product (ProductID)
GO
