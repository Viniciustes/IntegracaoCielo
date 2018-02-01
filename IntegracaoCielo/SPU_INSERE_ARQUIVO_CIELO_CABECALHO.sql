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
CREATE PROCEDURE SPU_INSERE_ARQUIVO_CIELO_CABECALHO
	@ID							UNIQUEIDENTIFIER
	,@TIPODEREGISTRO			VARCHAR(1)
	,@ESTABELECIMENTOMATRIZ		VARCHAR(10)
	,@DATADEPROCESSAMENTO		VARCHAR(8)
	,@PERIODOINICIAL			VARCHAR(8)
	,@PERIODOFINAL				VARCHAR(8)
	,@SEQUENCIA					VARCHAR(7)
	,@EMPRESAADQUIRENTE			VARCHAR(5)
	,@OPCAODEEXTRATO			VARCHAR(2)
	,@VAN						VARCHAR(1)
	,@CAIXAPOSTAL				VARCHAR(20)
	,@VERSAOLAYOUT				VARCHAR(3)
	,@USOCIELO					VARCHAR(177)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO 
		[dbo].[ArquivoCieloCabecalho] 
			([Id]
			,[TipoDeRegistro]
			,[EstabelecimentoMatriz]
			,[DataDeProcessamento]
			,[PeriodoInicial]
			,[PeriodoFinal]
			,[Sequencia]
			,[EmpresaAdquirente]
			,[OpcaoDeExtrato]
			,[VAN]
			,[CaixaPostal]
			,[VersaoLayout]
			,[UsoCielo]) 
		VALUES 
			(@ID
			,@TIPODEREGISTRO
			,@ESTABELECIMENTOMATRIZ
			,@DATADEPROCESSAMENTO
			,@PERIODOINICIAL
			,@PERIODOFINAL
			,@SEQUENCIA
			,@EMPRESAADQUIRENTE
			,@OPCAODEEXTRATO
			,@VAN
			,@CAIXAPOSTAL
			,@VERSAOLAYOUT
			,@USOCIELO)
   
END
GO
