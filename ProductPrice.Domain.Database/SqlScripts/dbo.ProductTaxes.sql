IF OBJECT_ID('dbo.ProductTaxes') IS NOT NULL
  BEGIN
    DROP FUNCTION dbo.ProductTaxes
  END
GO
CREATE FUNCTION dbo.ProductTaxes (@ProductId uniqueidentifier)
RETURNS TABLE
	AS
	RETURN(
		SELECT Taxes.* FROM Taxes 
		Join TaxProductPrices ON TaxProductPrices.Tax_Id = Taxes.Id
		Join ProductPrices ON TaxProductPrices.ProductPrice_Id = ProductPrices.Id
		Join Products ON Products.ProductPriceId = ProductPrices.Id
		WHERE Products.Id = @ProductID
)