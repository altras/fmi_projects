USE BalloonShop

GO

CREATE FULLTEXT CATALOG BalloonShopFullText AS DEFAULT

GO

CREATE FULLTEXT INDEX ON Product(Name, Description) KEY INDEX PK_Product ON BalloonShopFullText

