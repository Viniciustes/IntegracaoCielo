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
CREATE PROCEDURE SPU_INSERE_ARQUIVO_CIELO
	@ID						UNIQUEIDENTIFIER,
	@NOMEARQUIVO			NVARCHAR(150),
	@TIPOARQUIVO			VARCHAR(3),
	@DATAIMPORTACAO			DATETIME,
	@STATUSPROCESSAMENTO	BIT,
	@DATAIMPORTACAORM		DATETIME,
	@STATUSPROCESSAMENTORM	BIT

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO 
		[dbo].[ArquivoCielo] 
			([Id]
			,[NomeArquivo]
			,[TipoArquivo]
			,[DataImportacao]
			,[StatusProcessamento]
			,[DataImportacaoRM]
			,[StatusProcessamentoRM]) 
		VALUES 
			(@ID
			,@NOMEARQUIVO
			,@TIPOARQUIVO
			,@DATAIMPORTACAO
			,@STATUSPROCESSAMENTO
			,@DATAIMPORTACAORM
			,@STATUSPROCESSAMENTORM)

END
GO
