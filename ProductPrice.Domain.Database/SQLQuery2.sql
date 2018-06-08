USE [PricesContext]
GO

DECLARE	@return_value Decimal(18, 0)

EXEC	@return_value = [dbo].[PriceByProductId]
		@ProductId = 'b7eb0f20-cae8-e711-b871-38d5478bdf73'

SELECT	@return_value as 'Return Value'

GO
