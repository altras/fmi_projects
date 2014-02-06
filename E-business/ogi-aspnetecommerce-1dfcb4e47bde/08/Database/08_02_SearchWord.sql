CREATE PROCEDURE SearchWord (@Word NVARCHAR(50))
AS

SET @Word = 'FORMSOF(INFLECTIONAL, "' + @Word + '")'

SELECT COALESCE(NameResults.[KEY], DescriptionResults.[KEY]) AS [KEY],
       ISNULL(NameResults.Rank, 0) * 3 + 
       ISNULL(DescriptionResults.Rank, 0) AS Rank 
FROM 
  CONTAINSTABLE(Product, Name, @Word, 
                LANGUAGE 'English') AS NameResults
  FULL OUTER JOIN
  CONTAINSTABLE(Product, Description, @Word, 
                LANGUAGE 'English') AS DescriptionResults
  ON NameResults.[KEY] = DescriptionResults.[KEY]
