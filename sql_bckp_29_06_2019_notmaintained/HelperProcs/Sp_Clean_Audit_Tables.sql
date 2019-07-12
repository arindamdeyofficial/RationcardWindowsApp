IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sp_Clean_Audit_Tables]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[Sp_Clean_Audit_Tables]
GO 
--EXEC Sp_Clean_Audit_Tables 
CREATE PROCEDURE [dbo].[Sp_Clean_Audit_Tables]
@tableName VARCHAR(100),
@dtFrom DATETIME,
@dtTo DATETIME

AS
BEGIN
	
	SET NOCOUNT ON;
	BEGIN TRY

		IF(@tableName = 'Card_Search_Input')
		BEGIN
			DELETE FROM Card_Search_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'Logger')
		BEGIN
			DELETE FROM Logger
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'Product_Search_Input')
		BEGIN
			DELETE FROM Product_Search_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'Product_Input')
		BEGIN
			DELETE FROM Product_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'Bill_Input')
		BEGIN
			DELETE FROM Bill_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'Txn_Card_Input_Data')
		BEGIN
			DELETE FROM Txn_Card_Input_Data
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'App_Start_His')
		BEGIN
			DELETE FROM App_Start_His
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		IF(@tableName = 'Login_His')
		BEGIN
			DELETE FROM Login_His
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		ELSE
		BEGIN
			DELETE FROM Card_Search_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM Logger
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM Product_Search_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM Product_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM Bill_Input
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM Txn_Card_Input_Data
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM App_Start_His
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo

			DELETE FROM Login_His
			WHERE Created_Date >= @dtFrom AND Created_Date <= @dtTo
		END
		SELECT 'SUCCESS'
	END TRY
	BEGIN CATCH
		SELECT 'FAILURE',
		ERROR_NUMBER() AS ErrorNumber  
		,ERROR_SEVERITY() AS ErrorSeverity  
		,ERROR_STATE() AS ErrorState  
		,ERROR_PROCEDURE() AS ErrorProcedure  
		,ERROR_LINE() AS ErrorLine  
		,ERROR_MESSAGE() AS ErrorMessage; 
	END CATCH
END