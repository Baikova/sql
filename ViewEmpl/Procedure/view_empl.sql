USE [dip]
GO
/****** Object:  StoredProcedure [dbo].[view_empl]    Script Date: 10/08/2018 23:43:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[view_empl] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		Employees.empl_name,
		Employees.department_name, 
		Employees.science_degree,
		Employees.hours
		 
		
		
	from Employees
	
END
