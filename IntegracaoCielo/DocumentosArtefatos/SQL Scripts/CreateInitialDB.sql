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
