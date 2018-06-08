[![Codacy Badge](https://api.codacy.com/project/badge/Grade/4a87e276518e470a9dc3e115c37ade13)](https://www.codacy.com/app/ka2803/ProductPrice?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=ka2803/ProductPrice&amp;utm_campaign=Badge_Grade)
[![Build status](https://ci.appveyor.com/api/projects/status/fgn8bl5mkkes7hdo?svg=true)](https://ci.appveyor.com/project/ka2803/productprice)

Project made on ASP .Net WebAPI with MS SQL Server database.

Used NuGet packages:
-  Autofac, click [here](https://autofac.org/) to see more information.
-  EntityFramework, click [here](https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx) to see more information.
-  Swagger, click [here](https://swagger.io/) to see more information.
-  Log4Net, click [here](https://logging.apache.org/log4net/) to see more information.

**Gets total price of specified product**
``` sql

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
```
**Gets pairs of ProductId - Total Price for the list of specified products**
``` sql
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
```
**Gets list of Taxes for specified product**
``` sql
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
		Join TaxProductPrices ON TaxProductPrices.Tax_Id=Taxes.Id
		Join ProductPrices ON TaxProductPrices.ProductPrice_Id = ProductPrices.Id
		Join Products ON Products.ProductPriceId = ProductPrices.Id
		WHERE Products.Id=@ProductID
)
```
