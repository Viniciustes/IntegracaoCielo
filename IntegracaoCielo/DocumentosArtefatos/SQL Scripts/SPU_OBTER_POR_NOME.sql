USE IntegracaoCielo
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vinícius Batista Barreira
-- Create date: 15/12/2017
-- =============================================
CREATE PROCEDURE SPU_OBTER_POR_NOME
	@NOME NVARCHAR(150)
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT 
		[Id]
		,[NomeArquivo]
		,[TipoArquivo]
		,[DataImportacao]
		,[StatusProcessamento]
		,[DataImportacaoRM]
		,[StatusProcessamentoRM]
	FROM
		[dbo].[ArquivoCielo] (NOLOCK)
	WHERE
		[NomeArquivo] = @NOME

END
GO
