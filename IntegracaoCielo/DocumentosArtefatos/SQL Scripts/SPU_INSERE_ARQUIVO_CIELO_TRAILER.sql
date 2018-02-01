USE IntegracaoCielo
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vinícius Batista Barreira
-- Create date: 15/12/2015
-- =============================================
CREATE PROCEDURE SPU_INSERE_ARQUIVO_CIELO_TRAILER 
	@ID UNIQUEIDENTIFIER
	,@TIPODEREGISTRO VARCHAR(1)
	,@TOTALDEREGISTRO VARCHAR(11)
	,@USOCIELO VARCHAR(238)

AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO 
		[dbo].[ArquivoCieloTrailer] 
			([Id]
			,[TipoDeRegistro]
			,[TotalDeRegistro]
			,[UsoCielo]) 
		VALUES 
			(@ID
			,@TIPODEREGISTRO
			,@TOTALDEREGISTRO
			,@USOCIELO)
END
GO
