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
CREATE PROCEDURE SPU_OBTER_TODOS

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
		[dbo].[ArquivoCielo](NOLOCK)

END
GO
