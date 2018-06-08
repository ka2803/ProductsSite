IF OBJECT_ID('dbo.ProductIdTable') IS NOT NULL
  BEGIN
    DROP FUNCTION dbo.ProductIdTable
  END

GO

CREATE TYPE dbo.ProductIdTable as TABLE
(
	ProductId uniqueidentifier
);