using IntegracaoCielo.Dominio.Entidades;
using IntegracaoCielo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace IntegracaoCielo.Infraestrutura.Repositorios
{
    public class RepositorioCartaoCielo : RepositorioBase, IRepositorioCartaoCielo
    {
        public bool GravarArquivoNoBanco(ArquivoCielo arquivoCielo, object[] retornoArquivo)
        {
            using (Db)
            {
                using (var dbContextTransaction = Db.Database.BeginTransaction())
                {
                    try
                    {
                        Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_INSERE_ARQUIVO_CIELO] @ID, @NOMEARQUIVO, @TIPOARQUIVO, @DATAIMPORTACAO, @STATUSPROCESSAMENTO, @DATAIMPORTACAORM, @STATUSPROCESSAMENTORM", new[] { new SqlParameter("@ID", arquivoCielo.Id), new SqlParameter("@NOMEARQUIVO", arquivoCielo.NomeArquivo), new SqlParameter("@TIPOARQUIVO", arquivoCielo.TipoArquivo), new SqlParameter("@DATAIMPORTACAO", arquivoCielo.DataImportacao), new SqlParameter("@STATUSPROCESSAMENTO", arquivoCielo.StatusProcessamento), new SqlParameter("@DATAIMPORTACAORM", arquivoCielo.DataImportacaoRm ?? (object)DBNull.Value), new SqlParameter("@STATUSPROCESSAMENTORM", arquivoCielo.StatusProcessamentoRm) });

                        foreach (var rec in retornoArquivo)
                        {
                            if (rec.GetType() == typeof(ArquivoCieloCabecalho))
                            {
                                var arquivoCieloCabecalho = (ArquivoCieloCabecalho)rec;

                                Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_INSERE_ARQUIVO_CIELO_CABECALHO] @ID, @TIPODEREGISTRO, @ESTABELECIMENTOMATRIZ, @DATADEPROCESSAMENTO, @PERIODOINICIAL, @PERIODOFINAL, @SEQUENCIA, @EMPRESAADQUIRENTE, @OPCAODEEXTRATO, @VAN, @CAIXAPOSTAL, @VERSAOLAYOUT, @USOCIELO", new[] { new SqlParameter("@ID", arquivoCielo.Id), new SqlParameter("@TIPODEREGISTRO", arquivoCieloCabecalho.TipoDeRegistro ?? (object)DBNull.Value), new SqlParameter("@ESTABELECIMENTOMATRIZ", arquivoCieloCabecalho.EstabelecimentoMatriz ?? (object)DBNull.Value), new SqlParameter("@DATADEPROCESSAMENTO", arquivoCieloCabecalho.DataDeProcessamento ?? (object)DBNull.Value), new SqlParameter("@PERIODOINICIAL", arquivoCieloCabecalho.PeriodoInicial ?? (object)DBNull.Value), new SqlParameter("@PERIODOFINAL", arquivoCieloCabecalho.PeriodoFinal ?? (object)DBNull.Value), new SqlParameter("@SEQUENCIA", arquivoCieloCabecalho.Sequencia ?? (object)DBNull.Value), new SqlParameter("@EMPRESAADQUIRENTE", arquivoCieloCabecalho.EmpresaAdquirente ?? (object)DBNull.Value), new SqlParameter("@OPCAODEEXTRATO", arquivoCieloCabecalho.OpcaoDeExtrato ?? (object)DBNull.Value), new SqlParameter("@VAN", arquivoCieloCabecalho.Van ?? (object)DBNull.Value), new SqlParameter("@CAIXAPOSTAL", arquivoCieloCabecalho.CaixaPostal ?? (object)DBNull.Value), new SqlParameter("@VERSAOLAYOUT", arquivoCieloCabecalho.VersaoLayout ?? (object)DBNull.Value), new SqlParameter("@USOCIELO", arquivoCieloCabecalho.UsoCielo ?? (object)DBNull.Value) });
                            }
                            else if (rec.GetType() == typeof(ArquivoCieloDetalhes))
                            {
                                var arquivoCieloDetalhes = (ArquivoCieloDetalhes)rec;

                                Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_INSERE_ARQUIVO_CIELO_DETALHES] @ID ,@TIPODEREGISTRO ,@ESTABELECIMENTOSUBMISSOR ,@NUMERODORO ,@PARCELA ,@FILLER ,@PLANO ,@TIPODETRANSACAO ,@DATADEAPRESENTACAO ,@DATAPREVISTADEPAGAMENTO ,@DATADEENVIOPARAOBANCO ,@SINALVALORBRUTO ,@VALORBRUTO ,@SINALDACOMISSAO ,@VALORDACOMISSAO ,@SINALDOVALORREJEITADO ,@VALORREJEITADO ,@SINALDOVALORLIQUIDO ,@VALORLIQUIDO ,@BANCO ,@AGENCIA ,@CONTACORRENTE ,@STATUSDOPAGAMENTO ,@QUANTIDADEDECVSACEITOS ,@CODIGODOPRODUTODESCONSIDERAR ,@QUANTIDADESDECVSREJEITADOS ,@IDENTIFICADORDEREVENDAACELERACAO ,@DATADACAPTURADETRANSACAO ,@ORIGEMDOAJUSTE ,@VALORCOMPLEMENTAR ,@IDENTIFICADORDEANTECIPACAO ,@NUMERODAOPERACAODEANTECIPACAO ,@SINALDOVALORBRUTOANTECIPADO ,@VALORBRUTOANTECIPADO ,@BANDEIRA ,@NUMEROUNICODORO ,@TAXADECOMISSAO ,@TARIFA ,@TAXADEGARANTIA ,@MEIODECAPTURA ,@NUMEROLOGICODOTERMINAL ,@CODIGODOPRODUTO ,@MATRIZDEPAGAMENTO ,@USOCIELO", new[] { new SqlParameter("@ID", arquivoCielo.Id), new SqlParameter("@TIPODEREGISTRO", arquivoCieloDetalhes.TipoDeRegistro ?? (object)DBNull.Value), new SqlParameter("@ESTABELECIMENTOSUBMISSOR", arquivoCieloDetalhes.EstabelecimentoSubmissor ?? (object)DBNull.Value), new SqlParameter("@NUMERODORO", arquivoCieloDetalhes.NumeroDoRo ?? (object)DBNull.Value), new SqlParameter("@PARCELA", arquivoCieloDetalhes.Parcela ?? (object)DBNull.Value), new SqlParameter("@FILLER", arquivoCieloDetalhes.Filler ?? (object)DBNull.Value), new SqlParameter("@PLANO", arquivoCieloDetalhes.Plano ?? (object)DBNull.Value), new SqlParameter("@TIPODETRANSACAO", arquivoCieloDetalhes.TipoDeTransacao ?? (object)DBNull.Value), new SqlParameter("@DATADEAPRESENTACAO", arquivoCieloDetalhes.DataDeApresentacao ?? (object)DBNull.Value), new SqlParameter("@DATAPREVISTADEPAGAMENTO", arquivoCieloDetalhes.DataPrevistaDePagamento ?? (object)DBNull.Value), new SqlParameter("@DATADEENVIOPARAOBANCO", arquivoCieloDetalhes.DataDeEnvioParaoBanco ?? (object)DBNull.Value), new SqlParameter("@SINALVALORBRUTO", arquivoCieloDetalhes.SinalValorBruto ?? (object)DBNull.Value), new SqlParameter("@VALORBRUTO", arquivoCieloDetalhes.ValorBruto ?? (object)DBNull.Value), new SqlParameter("@SINALDACOMISSAO", arquivoCieloDetalhes.SinalDaComissao ?? (object)DBNull.Value), new SqlParameter("@VALORDACOMISSAO", arquivoCieloDetalhes.ValorDaComissao ?? (object)DBNull.Value), new SqlParameter("@SINALDOVALORREJEITADO", arquivoCieloDetalhes.SinalDoValorRejeitado ?? (object)DBNull.Value), new SqlParameter("@VALORREJEITADO", arquivoCieloDetalhes.ValorRejeitado ?? (object)DBNull.Value), new SqlParameter("@SINALDOVALORLIQUIDO", arquivoCieloDetalhes.SinalDoValorLiquido ?? (object)DBNull.Value), new SqlParameter("@VALORLIQUIDO", arquivoCieloDetalhes.ValorLiquido ?? (object)DBNull.Value), new SqlParameter("@BANCO", arquivoCieloDetalhes.Banco ?? (object)DBNull.Value), new SqlParameter("@AGENCIA", arquivoCieloDetalhes.Agencia ?? (object)DBNull.Value), new SqlParameter("@CONTACORRENTE", arquivoCieloDetalhes.ContaCorrente ?? (object)DBNull.Value), new SqlParameter("@STATUSDOPAGAMENTO", arquivoCieloDetalhes.StatusDoPagamento ?? (object)DBNull.Value), new SqlParameter("@QUANTIDADEDECVSACEITOS", arquivoCieloDetalhes.QuantidadeDeCVsAceitos ?? (object)DBNull.Value), new SqlParameter("@CODIGODOPRODUTODESCONSIDERAR", arquivoCieloDetalhes.CodigoDoProdutoDesconsiderar ?? (object)DBNull.Value), new SqlParameter("@QUANTIDADESDECVSREJEITADOS", arquivoCieloDetalhes.QuantidadesDeCVsRejeitados ?? (object)DBNull.Value), new SqlParameter("@IDENTIFICADORDEREVENDAACELERACAO", arquivoCieloDetalhes.IdentificadorDeRevendaAceleracao ?? (object)DBNull.Value), new SqlParameter("@DATADACAPTURADETRANSACAO", arquivoCieloDetalhes.DataDaCapturaDeTransacao ?? (object)DBNull.Value), new SqlParameter("@ORIGEMDOAJUSTE", arquivoCieloDetalhes.OrigemDoAjuste ?? (object)DBNull.Value), new SqlParameter("@VALORCOMPLEMENTAR", arquivoCieloDetalhes.ValorComplementar ?? (object)DBNull.Value), new SqlParameter("@IDENTIFICADORDEANTECIPACAO", arquivoCieloDetalhes.IdentificadorDeAntecipacao ?? (object)DBNull.Value), new SqlParameter("@NUMERODAOPERACAODEANTECIPACAO", arquivoCieloDetalhes.NumeroDaOperacaoDeAntecipacao ?? (object)DBNull.Value), new SqlParameter("@SINALDOVALORBRUTOANTECIPADO", arquivoCieloDetalhes.SinalDoValorBrutoAntecipado ?? (object)DBNull.Value), new SqlParameter("@VALORBRUTOANTECIPADO", arquivoCieloDetalhes.ValorBrutoAntecipado ?? (object)DBNull.Value), new SqlParameter("@BANDEIRA", arquivoCieloDetalhes.Bandeira ?? (object)DBNull.Value), new SqlParameter("@NUMEROUNICODORO", arquivoCieloDetalhes.NumeroUnicoDoRo ?? (object)DBNull.Value), new SqlParameter("@TAXADECOMISSAO", arquivoCieloDetalhes.TaxaDeComissao ?? (object)DBNull.Value), new SqlParameter("@TARIFA", arquivoCieloDetalhes.Tarifa ?? (object)DBNull.Value), new SqlParameter("@TAXADEGARANTIA", arquivoCieloDetalhes.TaxaDeGarantia ?? (object)DBNull.Value), new SqlParameter("@MEIODECAPTURA", arquivoCieloDetalhes.MeioDeCaptura ?? (object)DBNull.Value), new SqlParameter("@NUMEROLOGICODOTERMINAL", arquivoCieloDetalhes.NumeroLogicoDoTerminal ?? (object)DBNull.Value), new SqlParameter("@CODIGODOPRODUTO", arquivoCieloDetalhes.CodigoDoProduto ?? (object)DBNull.Value), new SqlParameter("@MATRIZDEPAGAMENTO", arquivoCieloDetalhes.MatrizDePagamento ?? (object)DBNull.Value), new SqlParameter("@USOCIELO", arquivoCieloDetalhes.UsoCielo ?? (object)DBNull.Value) });
                            }
                            else if (rec.GetType() == typeof(ArquivoCieloDetalhesCv))
                            {
                                var arquivoCieloDetalhesCv = (ArquivoCieloDetalhesCv)rec;

                                Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_INSERE_ARQUIVO_CIELO_DETALHES_CV] @ID ,@TIPODEREGISTRO ,@ESTABELECIMENTOSUBMISSOR ,@NUMERODORO ,@NUMERODOCARTAOTRUNCADO ,@DATADAVENDAAJUSTE ,@SINALDOVALORDACOMPRAOUVALORDAPARCELA ,@VALORDACOMPRAOUVALORDAPARCELA ,@PARCELA ,@TOTALDEPARCELAS ,@MOTIVODAREJEICAO ,@CODIGODEAUTORIZACAO ,@TID ,@NSUDOC ,@VALORCOMPLEMENTAR ,@DIGCARTAO ,@VALORTOTALDAVENDANOCASODEPARCELADOLOJA ,@VALORDAPROXIMAPARCELA ,@NUMERODANOTAFISCAL ,@INDICADORDECARTAOEMITIDONOEXTERIOR ,@NUMEROLOGICODOTERMINAL ,@IDENTIFICADORDETAXADEEMBARQUEOUVALORDEENTRADA ,@REFERENCIACODIGODOPEDIDO ,@HORADATRANSACAO ,@NUMEROUNICODATRANSACAO ,@INDICADORCIELOPROMO ,@USOCIELO", new[] { new SqlParameter("@ID", arquivoCielo.Id), new SqlParameter("@TIPODEREGISTRO", arquivoCieloDetalhesCv.TipoDeRegistro ?? (object)DBNull.Value), new SqlParameter("@ESTABELECIMENTOSUBMISSOR", arquivoCieloDetalhesCv.EstabelecimentoSubmissor ?? (object)DBNull.Value), new SqlParameter("@NUMERODORO", arquivoCieloDetalhesCv.NumeroDoRo ?? (object)DBNull.Value), new SqlParameter("@NUMERODOCARTAOTRUNCADO", arquivoCieloDetalhesCv.NumeroDoCartaoTruncado ?? (object)DBNull.Value), new SqlParameter("@DATADAVENDAAJUSTE", arquivoCieloDetalhesCv.DataDaVendaAjuste ?? (object)DBNull.Value), new SqlParameter("@SINALDOVALORDACOMPRAOUVALORDAPARCELA", arquivoCieloDetalhesCv.SinalDoValorDaCompraOuValorDaParcela ?? (object)DBNull.Value), new SqlParameter("@VALORDACOMPRAOUVALORDAPARCELA", arquivoCieloDetalhesCv.ValorDaCompraOuValorDaParcela ?? (object)DBNull.Value), new SqlParameter("@PARCELA", arquivoCieloDetalhesCv.Parcela ?? (object)DBNull.Value), new SqlParameter("@TOTALDEPARCELAS", arquivoCieloDetalhesCv.TotalDeParcelas ?? (object)DBNull.Value), new SqlParameter("@MOTIVODAREJEICAO", arquivoCieloDetalhesCv.MotivoDaRejeicao ?? (object)DBNull.Value), new SqlParameter("@CODIGODEAUTORIZACAO", arquivoCieloDetalhesCv.CodigoDeAutorizacao ?? (object)DBNull.Value), new SqlParameter("@TID", arquivoCieloDetalhesCv.Tid ?? (object)DBNull.Value), new SqlParameter("@NSUDOC", arquivoCieloDetalhesCv.Nsudoc ?? (object)DBNull.Value), new SqlParameter("@VALORCOMPLEMENTAR", arquivoCieloDetalhesCv.ValorComplementar ?? (object)DBNull.Value), new SqlParameter("@DIGCARTAO", arquivoCieloDetalhesCv.DigCartao ?? (object)DBNull.Value), new SqlParameter("@VALORTOTALDAVENDANOCASODEPARCELADOLOJA", arquivoCieloDetalhesCv.ValorTotalDaVendaNoCasoDeParceladoLoja ?? (object)DBNull.Value), new SqlParameter("@VALORDAPROXIMAPARCELA", arquivoCieloDetalhesCv.ValorDaProximaParcela ?? (object)DBNull.Value), new SqlParameter("@NUMERODANOTAFISCAL", arquivoCieloDetalhesCv.NumeroDaNotaFiscal ?? (object)DBNull.Value), new SqlParameter("@INDICADORDECARTAOEMITIDONOEXTERIOR", arquivoCieloDetalhesCv.IndicadorDeCartaoEmitidoNoExterior ?? (object)DBNull.Value), new SqlParameter("@NUMEROLOGICODOTERMINAL", arquivoCieloDetalhesCv.NumeroLogicoDoTerminal ?? (object)DBNull.Value), new SqlParameter("@IDENTIFICADORDETAXADEEMBARQUEOUVALORDEENTRADA", arquivoCieloDetalhesCv.IdentificadorDeTaxaDeEmbarqueOuValorDeEntrada ?? (object)DBNull.Value), new SqlParameter("@REFERENCIACODIGODOPEDIDO", arquivoCieloDetalhesCv.ReferenciaCodigoDoPedido ?? (object)DBNull.Value), new SqlParameter("@HORADATRANSACAO", arquivoCieloDetalhesCv.HoraDaTransacao ?? (object)DBNull.Value), new SqlParameter("@NUMEROUNICODATRANSACAO", arquivoCieloDetalhesCv.NumeroUnicoDaTransacao ?? (object)DBNull.Value), new SqlParameter("@INDICADORCIELOPROMO", arquivoCieloDetalhesCv.IndicadorCieloPromo ?? (object)DBNull.Value), new SqlParameter("@USOCIELO", arquivoCieloDetalhesCv.UsoCielo ?? (object)DBNull.Value) });
                            }
                            else if (rec.GetType() == typeof(ArquivoCieloTrailer))
                            {
                                var arquivoCieloTrailer = (ArquivoCieloTrailer)rec;

                                Db.Database.ExecuteSqlCommand("EXECUTE [dbo].[SPU_INSERE_ARQUIVO_CIELO_TRAILER] @ID ,@TIPODEREGISTRO ,@TOTALDEREGISTRO ,@USOCIELO", new[] { new SqlParameter("@ID", arquivoCielo.Id), new SqlParameter("@TIPODEREGISTRO", arquivoCieloTrailer.TipoDeRegistro ?? (object)DBNull.Value), new SqlParameter("@TOTALDEREGISTRO", arquivoCieloTrailer.TotalDeRegistro ?? (object)DBNull.Value), new SqlParameter("@USOCIELO", arquivoCieloTrailer.UsoCielo ?? (object)DBNull.Value) });
                            }
                        }

                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public ArquivoCielo ObterPorNome(string nome)
        {
            return Db.Database.SqlQuery<ArquivoCielo>("EXECUTE [dbo].[SPU_OBTER_POR_NOME] @NOME", new SqlParameter("@NOME", nome)).FirstOrDefault();
        }

        public IEnumerable<ArquivoCielo> ObterTodos()
        {
            return Db.Database.SqlQuery<ArquivoCielo>("EXECUTE [dbo].[SPU_OBTER_TODOS]").ToList();
        }

        public IEnumerable<ArquivoCieloRm> BuscarArquivoNoBanco(Guid id)
        {
            return Db.Database.SqlQuery<ArquivoCieloRm>("EXECUTE [dbo].[SPU_BUSCA_ARQUIVO_NO_BANCO_PARA_BAIXA_RM] @Id", new SqlParameter("@Id", id)).ToList();
        }
    }
}