-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
USE [dip]
GO
/****** Object:  StoredProcedure [dbo].[view_empl]    Script Date: 09/17/2018 11:23:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[select_publ_kpi]
	-- Add the parameters for the stored procedure here
	@lastName nvarchar(255)
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
  select * from [dip].[dbo].[Publ] s 
  join (select employees_id, translit_name, synonym, department_name 
  from [dip].[dbo].[Employees]) as s1 
  on 
  s1.translit_name LIKE @lastName+'%' 
  where s.SNIP is not NULL and s.Авторы like @lastName + '%'
END
