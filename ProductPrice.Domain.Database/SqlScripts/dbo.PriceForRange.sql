
IF OBJECT_ID('dbo.PriceForRange') IS NOT NULL
  BEGIN
    DROP FUNCTION dbo.PriceForRange
  END

GO

CREATE FUNCTION dbo.PriceForRange (@Products ProductIdTable  READONLY)
RETURNS TABLE
AS
RETURN(
	SELECT dbo.PriceByProductId(ProductId) as Price FROM @Products	
);