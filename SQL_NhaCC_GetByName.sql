USE [QL_BanHangDienThoai]
GO

Create Proc NhaCC_GetByName(
@TenNhaCC nvarchar)
AS
Begin
	SELECT * FROM NhaCC WHERE TenNhaCC = @TenNhaCC
End