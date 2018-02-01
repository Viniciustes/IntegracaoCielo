USE IntegracaoCielo
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.procedures WHERE NAME = 'SPU_BUSCA_ARQUIVO_NO_BANCO_PARA_BAIXA_RM')
      DROP PROCEDURE [dbo].[SPU_BUSCA_ARQUIVO_NO_BANCO_PARA_BAIXA_RM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vinícius Batista Barreira
-- Create date: 21/02/2017
-- Description:	Procedure que busca o arquivo lido no banco para baixa no RM 
-- Exec SPU_BUSCA_ARQUIVO_NO_BANCO_PARA_BAIXA_RM 'C18AB772-4B73-42B0-AE8B-7CCADA61C58E'
-- =============================================
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
