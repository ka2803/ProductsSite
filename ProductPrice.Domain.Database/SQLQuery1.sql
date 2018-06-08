IF OBJECT_ID('dbo.PriceByProductId') IS NOT NULL
  BEGIN
    DROP FUNCTION dbo.PriceByProductId
  END

GO

CREATE FUNCTION dbo.PriceByProductId (@ProductId uniqueidentifier)
RETURNS DECIMAL
	AS
	BEGIN

		declare @simplePrice as decimal
		declare @PriceId as uniqueidentifier
		declare @AllPrice as decimal
		declare @TaxesPrice as decimal

		SELECT  @PriceId = Products.ProductPriceId,
				@simplePrice = ProductPrices.StartPrice
		FROM Products
		Join ProductPrices ON Products.ProductPriceId=ProductPrices.Id
		WHERE Products.Id=@ProductId


		SELECT @AllPrice =  SUM(Shippings.Price + Environments.TotalAmortization
			+ Environments.TotalElectricity
			+ Environments.TotalSalary + Boxings.Price) FROM Products
		Join ProductPrices ON Products.ProductPriceId=ProductPrices.Id
		Join Shippings ON ProductPrices.ShippingId = ShippingId
		Join Environments ON ProductPrices.EnvironmentId = Environments.Id
		Join Boxings ON ProductPrices.BoxingId = Boxings.Id
		WHERE Products.Id=@ProductId

		

		SELECT @TaxesPrice = SUM(Taxes.Value) FROM Taxes
		Join TaxProductPrices ON Taxes.Id=TaxProductPrices.Tax_Id
		Join ProductPrices ON TaxProductPrices.ProductPrice_Id=ProductPrices.Id
		WHERE ProductPrices.Id=@PriceId

		declare @result decimal = @TaxesPrice + @AllPrice + @simplePrice

		RETURN (@result);
END;
	