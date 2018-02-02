USE MASTER
GO

IF DB_ID ('IntegracaoCielo') IS NULL
	CREATE DATABASE IntegracaoCielo
GO

USE IntegracaoCielo
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.tables WHERE NAME = 'ArquivoCielo')
	CREATE TABLE ArquivoCielo (
		Id UNIQUEIDENTIFIER NOT NULL,      
		NomeArquivo NVARCHAR(150),
		TipoArquivo VARCHAR(3),
		DataImportacao DATETIME,
		StatusProcessamento BIT,
		DataImportacaoRM DATETIME,
		StatusProcessamentoRM BIT    
	)
GO
ALTER TABLE ArquivoCielo
	ADD CONSTRAINT PK_ARQUIVOCIELO
PRIMARY KEY (Id);


IF NOT EXISTS (SELECT TOP 1 1 FROM sys.tables WHERE NAME = 'ArquivoCieloDetalhes')
	CREATE TABLE ArquivoCieloDetalhes (
		Id UNIQUEIDENTIFIER NOT NULL,
		TipoDeRegistro VARCHAR(1),
		EstabelecimentoSubmissor VARCHAR(10), 
        NumeroDoRO VARCHAR(7),
        Parcela VARCHAR(2),
        Filler VARCHAR(1),
        Plano VARCHAR(2),
        TipoDeTransacao VARCHAR(2),
        DataDeApresentacao VARCHAR(6),
        DataPrevistaDePagamento VARCHAR(6),
        DataDeEnvioParaoBanco VARCHAR(6),
        SinalValorBruto VARCHAR(1),
        ValorBruto VARCHAR(13),
        SinalDaComissao VARCHAR(1),
        ValorDaComissao VARCHAR(13),
        SinalDoValorRejeitado VARCHAR(1),
        ValorRejeitado VARCHAR(13),
        SinalDoValorLiquido VARCHAR(1),
        ValorLiquido VARCHAR(13),
        Banco VARCHAR(4),
        Agencia VARCHAR(5),
        ContaCorrente VARCHAR(14),
        StatusDoPagamento VARCHAR(2),
        QuantidadeDeCVsAceitos VARCHAR(6),
        CodigoDoProdutoDesconsiderar VARCHAR(2),
        QuantidadesDeCVsRejeitados VARCHAR(6),
        IdentificadorDeRevendaAceleracao VARCHAR(1),
        DataDaCapturaDeTransacao VARCHAR(6),
        OrigemDoAjuste VARCHAR(2),
        ValorComplementar VARCHAR(13),
        IdentificadorDeAntecipacao VARCHAR(1),
        NumeroDaOperacaoDeAntecipacao VARCHAR(9),
        SinalDoValorBrutoAntecipado VARCHAR(1),
        ValorBrutoAntecipado VARCHAR(13),
        Bandeira VARCHAR(3),
        NumeroUnicoDoRO VARCHAR(22),
        TaxaDeComissao VARCHAR(4),
        Tarifa VARCHAR(5),
        TaxaDeGarantia VARCHAR(4),
        MeioDeCaptura VARCHAR(2),
        NumeroLogicoDoTerminal VARCHAR(8),
        CodigoDoProduto VARCHAR(3),
        MatrizDePagamento VARCHAR(10),
        UsoCielo VARCHAR(5) 
	)
GO
ALTER TABLE ArquivoCieloDetalhes
	ADD CONSTRAINT FK_ID_ARQUIVOCIELODETALHES
	FOREIGN KEY (Id)
	REFERENCES ArquivoCielo(Id);


IF NOT EXISTS (SELECT TOP 1 1 FROM sys.tables WHERE NAME = 'ArquivoCieloDetalhesCV')
	CREATE TABLE ArquivoCieloDetalhesCV (
		Id UNIQUEIDENTIFIER NOT NULL,
		TipoDeRegistro VARCHAR(1),
		EstabelecimentoSubmissor VARCHAR(10),
		NumeroDoRO VARCHAR(7),
		NumeroDoCartaoTruncado VARCHAR(19),
		DataDaVendaAjuste VARCHAR(8),
		SinalDoValorDaCompraOuValorDaParcela VARCHAR(1),
		ValorDaCompraOuValorDaParcela VARCHAR(13),
		Parcela VARCHAR(2),
		TotalDeParcelas VARCHAR(2),
		MotivoDaRejeicao VARCHAR(3),
		CodigoDeAutorizacao VARCHAR(6),
		TID VARCHAR(20),
		NSUDOC VARCHAR(6),
		ValorComplementar VARCHAR(13),
		DigCartao VARCHAR(2),
		ValorTotalDaVendaNoCasoDeParceladoLoja VARCHAR(13),
		ValorDaProximaParcela VARCHAR(13),
		NumeroDaNotaFiscal VARCHAR(9),
		IndicadorDeCartaoEmitidoNoExterior VARCHAR(4),
		NumeroLogicoDoTerminal VARCHAR(8),
		IdentificadorDeTaxaDeEmbarqueOuValorDeEntrada VARCHAR(2),
		ReferenciaCodigoDoPedido VARCHAR(20),
		HoraDaTransacao VARCHAR(6),
		NumeroUnicoDaTransacao VARCHAR(29),
		IndicadorCieloPromo VARCHAR(1),
		UsoCielo VARCHAR(32)
	)
GO
ALTER TABLE ArquivoCieloDetalhesCV
	ADD CONSTRAINT FK_ID_ARQUIVOCIELODETALHESCV
	FOREIGN KEY (Id)
	REFERENCES ArquivoCielo(Id);

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.tables WHERE NAME = 'ArquivoCieloCabecalho')
	CREATE TABLE ArquivoCieloCabecalho (
		Id UNIQUEIDENTIFIER NOT NULL,
		TipoDeRegistro VARCHAR(1),
		EstabelecimentoMatriz VARCHAR(10),
        DataDeProcessamento VARCHAR(8),
        PeriodoInicial VARCHAR(8),
        PeriodoFinal VARCHAR(8),
        Sequencia VARCHAR(7),
        EmpresaAdquirente VARCHAR(5),
        OpcaoDeExtrato VARCHAR(2),
        VAN VARCHAR(1),
        CaixaPostal VARCHAR(20),
        VersaoLayout VARCHAR(3),
        UsoCielo VARCHAR(177)
	)
GO
ALTER TABLE ArquivoCieloCabecalho
	ADD CONSTRAINT FK_ID_ARQUIVOCIELOCABECALHO
	FOREIGN KEY (Id)
	REFERENCES ArquivoCielo(Id);

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.tables WHERE NAME = 'ArquivoCieloTrailer')
	CREATE TABLE ArquivoCieloTrailer (
		Id UNIQUEIDENTIFIER NOT NULL,
		TipoDeRegistro VARCHAR(1),
		TotalDeRegistro VARCHAR(11),
		UsoCielo VARCHAR(238)
		
	)
GO
ALTER TABLE ArquivoCieloTrailer
	ADD CONSTRAINT FK_ID_ARQUIVOCIELOTRAILER
	FOREIGN KEY (Id)
	REFERENCES ArquivoCielo(Id);
GO


-- Criação das Procedures Abaixo
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

CREATE PROCEDURE SPU_INSERE_ARQUIVO_CIELO_DETALHES_CV 
@ID UNIQUEIDENTIFIER
,@TIPODEREGISTRO VARCHAR(1)
,@ESTABELECIMENTOSUBMISSOR VARCHAR(10)
,@NUMERODORO VARCHAR(7)
,@NUMERODOCARTAOTRUNCADO VARCHAR(19)
,@DATADAVENDAAJUSTE VARCHAR(8)
,@SINALDOVALORDACOMPRAOUVALORDAPARCELA VARCHAR(1)
,@VALORDACOMPRAOUVALORDAPARCELA VARCHAR(13)
,@PARCELA VARCHAR(2)
,@TOTALDEPARCELAS VARCHAR(2)
,@MOTIVODAREJEICAO VARCHAR(3)
,@CODIGODEAUTORIZACAO VARCHAR(6)
,@TID VARCHAR(20)
,@NSUDOC VARCHAR(6)
,@VALORCOMPLEMENTAR VARCHAR(13)
,@DIGCARTAO VARCHAR(2)
,@VALORTOTALDAVENDANOCASODEPARCELADOLOJA VARCHAR(13)
,@VALORDAPROXIMAPARCELA VARCHAR(13)
,@NUMERODANOTAFISCAL VARCHAR(9)
,@INDICADORDECARTAOEMITIDONOEXTERIOR VARCHAR(4)
,@NUMEROLOGICODOTERMINAL VARCHAR(8)
,@IDENTIFICADORDETAXADEEMBARQUEOUVALORDEENTRADA VARCHAR(2)
,@REFERENCIACODIGODOPEDIDO VARCHAR(20)
,@HORADATRANSACAO VARCHAR(6)
,@NUMEROUNICODATRANSACAO VARCHAR(29)
,@INDICADORCIELOPROMO VARCHAR(1)
,@USOCIELO VARCHAR(32)

AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO 
		[dbo].[ArquivoCieloDetalhesCV] 
			([Id]
			,[TipoDeRegistro]
			,[EstabelecimentoSubmissor]
			,[NumeroDoRO]
			,[NumeroDoCartaoTruncado]
			,[DataDaVendaAjuste]
			,[SinalDoValorDaCompraOuValorDaParcela]
			,[ValorDaCompraOuValorDaParcela]
			,[Parcela]
			,[TotalDeParcelas]
			,[MotivoDaRejeicao]
			,[CodigoDeAutorizacao]
			,[TID]
			,[NSUDOC]
			,[ValorComplementar]
			,[DigCartao]
			,[ValorTotalDaVendaNoCasoDeParceladoLoja]
			,[ValorDaProximaParcela]
			,[NumeroDaNotaFiscal]
			,[IndicadorDeCartaoEmitidoNoExterior]
			,[NumeroLogicoDoTerminal]
			,[IdentificadorDeTaxaDeEmbarqueOuValorDeEntrada]
			,[ReferenciaCodigoDoPedido]
			,[HoraDaTransacao]
			,[NumeroUnicoDaTransacao]
			,[IndicadorCieloPromo]
			,[UsoCielo]) 
		VALUES 
			(@ID
			,@TIPODEREGISTRO
			,@ESTABELECIMENTOSUBMISSOR
			,@NUMERODORO
			,@NUMERODOCARTAOTRUNCADO
			,@DATADAVENDAAJUSTE
			,@SINALDOVALORDACOMPRAOUVALORDAPARCELA
			,@VALORDACOMPRAOUVALORDAPARCELA
			,@PARCELA
			,@TOTALDEPARCELAS
			,@MOTIVODAREJEICAO
			,@CODIGODEAUTORIZACAO
			,@TID
			,@NSUDOC
			,@VALORCOMPLEMENTAR
			,@DIGCARTAO
			,@VALORTOTALDAVENDANOCASODEPARCELADOLOJA
			,@VALORDAPROXIMAPARCELA
			,@NUMERODANOTAFISCAL
			,@INDICADORDECARTAOEMITIDONOEXTERIOR
			,@NUMEROLOGICODOTERMINAL
			,@IDENTIFICADORDETAXADEEMBARQUEOUVALORDEENTRADA
			,@REFERENCIACODIGODOPEDIDO
			,@HORADATRANSACAO
			,@NUMEROUNICODATRANSACAO
			,@INDICADORCIELOPROMO
			,@USOCIELO)
  
END
GO

CREATE PROCEDURE SPU_INSERE_ARQUIVO_CIELO_DETALHES
 @ID UNIQUEIDENTIFIER
,@TIPODEREGISTRO VARCHAR(1)
,@ESTABELECIMENTOSUBMISSOR VARCHAR(10)
,@NUMERODORO VARCHAR(7)
,@PARCELA VARCHAR(2)
,@FILLER VARCHAR(1)
,@PLANO VARCHAR(2)
,@TIPODETRANSACAO VARCHAR(2)
,@DATADEAPRESENTACAO VARCHAR(6)
,@DATAPREVISTADEPAGAMENTO VARCHAR(6)
,@DATADEENVIOPARAOBANCO VARCHAR(6)
,@SINALVALORBRUTO VARCHAR(1)
,@VALORBRUTO VARCHAR(13)
,@SINALDACOMISSAO VARCHAR(1)
,@VALORDACOMISSAO VARCHAR(13)
,@SINALDOVALORREJEITADO VARCHAR(1)
,@VALORREJEITADO VARCHAR(13)
,@SINALDOVALORLIQUIDO VARCHAR(1)
,@VALORLIQUIDO VARCHAR(13)
,@BANCO VARCHAR(4)
,@AGENCIA VARCHAR(5)
,@CONTACORRENTE VARCHAR(14)
,@STATUSDOPAGAMENTO VARCHAR(2)
,@QUANTIDADEDECVSACEITOS VARCHAR(6)
,@CODIGODOPRODUTODESCONSIDERAR VARCHAR(2)
,@QUANTIDADESDECVSREJEITADOS VARCHAR(6)
,@IDENTIFICADORDEREVENDAACELERACAO VARCHAR(1)
,@DATADACAPTURADETRANSACAO VARCHAR(6)
,@ORIGEMDOAJUSTE VARCHAR(2)
,@VALORCOMPLEMENTAR VARCHAR(13)
,@IDENTIFICADORDEANTECIPACAO VARCHAR(1)
,@NUMERODAOPERACAODEANTECIPACAO VARCHAR(9)
,@SINALDOVALORBRUTOANTECIPADO VARCHAR(1)
,@VALORBRUTOANTECIPADO VARCHAR(13)
,@BANDEIRA VARCHAR(3)
,@NUMEROUNICODORO VARCHAR(22)
,@TAXADECOMISSAO VARCHAR(4)
,@TARIFA VARCHAR(5)
,@TAXADEGARANTIA VARCHAR(4)
,@MEIODECAPTURA VARCHAR(2)
,@NUMEROLOGICODOTERMINAL VARCHAR(8)
,@CODIGODOPRODUTO VARCHAR(3)
,@MATRIZDEPAGAMENTO VARCHAR(10)
,@USOCIELO VARCHAR(5)
	
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO 
		[dbo].[ArquivoCieloDetalhes] 
			([Id]
			,[TipoDeRegistro]
			,[EstabelecimentoSubmissor]
			,[NumeroDoRO]
			,[Parcela]
			,[Filler]
			,[Plano]
			,[TipoDeTransacao]
			,[DataDeApresentacao]
			,[DataPrevistaDePagamento]
			,[DataDeEnvioParaoBanco]
			,[SinalValorBruto]
			,[ValorBruto]
			,[SinalDaComissao]
			,[ValorDaComissao]
			,[SinalDoValorRejeitado]
			,[ValorRejeitado]
			,[SinalDoValorLiquido]
			,[ValorLiquido]
			,[Banco]
			,[Agencia]
			,[ContaCorrente]
			,[StatusDoPagamento]
			,[QuantidadeDeCVsAceitos]
			,[CodigoDoProdutoDesconsiderar]
			,[QuantidadesDeCVsRejeitados]
			,[IdentificadorDeRevendaAceleracao]
			,[DataDaCapturaDeTransacao]
			,[OrigemDoAjuste]
			,[ValorComplementar]
			,[IdentificadorDeAntecipacao]
			,[NumeroDaOperacaoDeAntecipacao]
			,[SinalDoValorBrutoAntecipado]
			,[ValorBrutoAntecipado]
			,[Bandeira]
			,[NumeroUnicoDoRO]
			,[TaxaDeComissao]
			,[Tarifa]
			,[TaxaDeGarantia]
			,[MeioDeCaptura]
			,[NumeroLogicoDoTerminal]
			,[CodigoDoProduto]
			,[MatrizDePagamento]
			,[UsoCielo]) 
		VALUES 
			(@ID
			,@TIPODEREGISTRO
			,@ESTABELECIMENTOSUBMISSOR
			,@NUMERODORO
			,@PARCELA
			,@FILLER
			,@PLANO
			,@TIPODETRANSACAO
			,@DATADEAPRESENTACAO
			,@DATAPREVISTADEPAGAMENTO
			,@DATADEENVIOPARAOBANCO
			,@SINALVALORBRUTO
			,@VALORBRUTO
			,@SINALDACOMISSAO
			,@VALORDACOMISSAO
			,@SINALDOVALORREJEITADO
			,@VALORREJEITADO
			,@SINALDOVALORLIQUIDO
			,@VALORLIQUIDO
			,@BANCO
			,@AGENCIA
			,@CONTACORRENTE
			,@STATUSDOPAGAMENTO
			,@QUANTIDADEDECVSACEITOS
			,@CODIGODOPRODUTODESCONSIDERAR
			,@QUANTIDADESDECVSREJEITADOS
			,@IDENTIFICADORDEREVENDAACELERACAO
			,@DATADACAPTURADETRANSACAO
			,@ORIGEMDOAJUSTE
			,@VALORCOMPLEMENTAR
			,@IDENTIFICADORDEANTECIPACAO
			,@NUMERODAOPERACAODEANTECIPACAO
			,@SINALDOVALORBRUTOANTECIPADO
			,@VALORBRUTOANTECIPADO
			,@BANDEIRA
			,@NUMEROUNICODORO
			,@TAXADECOMISSAO
			,@TARIFA
			,@TAXADEGARANTIA
			,@MEIODECAPTURA
			,@NUMEROLOGICODOTERMINAL
			,@CODIGODOPRODUTO
			,@MATRIZDEPAGAMENTO
			,@USOCIELO)
  
END
GO

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

CREATE PROCEDURE SPU_BUSCA_ARQUIVO_NO_BANCO_PARA_BAIXA_RM
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
		ArquivoCieloDetalhes.Id,
		CodigoDeAutorizacao,
		ValorBruto = (CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaCompraOuValorDaParcela)/100)),
		ValorLiquido = (CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorLiquido)/100)),
		ValorDaComissao = (CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaComissao)/100)),
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,TaxaDeComissao)/100)) AS TaxaDeComissao,
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorBruto)/100)) AS ValorBrutoLote,
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorLiquido)/100)) AS ValorLiquidoLote,
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaComissao)/100)) AS ValorDaComissaoLote,
		CONVERT(INT, ArquivoCieloDetalhes.QuantidadeDeCVsAceitos) AS QtdItensLote
	FROM ArquivoCieloDetalhes (NOLOCK)
	RIGHT JOIN ArquivoCieloDetalhesCV (NOLOCK)
	ON 
		SUBSTRING(ArquivoCieloDetalhes.NumeroUnicoDoRO ,1, 22) = 
		SUBSTRING(ArquivoCieloDetalhesCV.NumeroUnicoDaTransacao ,1, 22) AND
		ArquivoCieloDetalhes.Id = ArquivoCieloDetalhesCV.Id
	WHERE  
		ArquivoCieloDetalhes.Id = @Id AND
		ArquivoCieloDetalhes.QuantidadeDeCVsAceitos = 1 
	UNION ALL
	SELECT
		ArquivoCieloDetalhes.Id, 
		CodigoDeAutorizacao,
	    ValorBruto = (CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaCompraOuValorDaParcela)/100)),
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaCompraOuValorDaParcela)/100 - (CONVERT(DECIMAL(13,2),ROUND((((CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaCompraOuValorDaParcela)/100)) * (CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,TaxaDeComissao)/100)))/100),2))))) AS 'ValorLiquido',
	    ValorDaComissao = CONVERT(DECIMAL(13,2),ROUND((((CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaCompraOuValorDaParcela)/100)) * (CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,TaxaDeComissao)/100)))/100),2)),
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,TaxaDeComissao)/100)) AS TaxaDeComissao,
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorBruto)/100)) AS ValorBrutoLote,
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorLiquido)/100)) AS ValorLiquidoLote,
		(CONVERT(DECIMAL(13,2), CONVERT(DECIMAL,ValorDaComissao)/100)) AS ValorDaComissaoLote,
		CONVERT(INT, ArquivoCieloDetalhes.QuantidadeDeCVsAceitos) AS QtdItensLote
	FROM ArquivoCieloDetalhes (NOLOCK)
	RIGHT JOIN ArquivoCieloDetalhesCV (NOLOCK)
	ON 
		SUBSTRING(ArquivoCieloDetalhes.NumeroUnicoDoRO ,1, 22) = 
		SUBSTRING(ArquivoCieloDetalhesCV.NumeroUnicoDaTransacao ,1, 22) AND
		ArquivoCieloDetalhes.Id = ArquivoCieloDetalhesCV.Id
	WHERE  
		ArquivoCieloDetalhes.Id = @Id AND
		ArquivoCieloDetalhes.QuantidadeDeCVsAceitos > 1 
END
GO
