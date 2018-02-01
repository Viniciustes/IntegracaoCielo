using FileHelpers;

namespace IntegracaoCielo.Dominio.Entidades
{
    /// <summary>
    /// Tipo 2 - Detalhe do Comprovante de Venda (CV)
    /// </summary>
    [FixedLengthRecord()]
    public class ArquivoCieloDetalhesCv
    {
        /// <summary>
        /// Constante 2 identifica o tipo de registro de detalhe do Comprovante de Venda (CV).
        /// </summary>
        [FieldFixedLength(1)]
        public string TipoDeRegistro;

        /// <summary>
        /// Estabelecimento Submissor
        /// Número do estabelecimento e/ou filial onde a venda foi realizada.
        /// </summary>
        [FieldFixedLength(10)]
        public string EstabelecimentoSubmissor;

        /// <summary>
        /// Número do RO
        /// Número do resumo de operação.
        ///Contêm informações referentes a um grupo de vendas realizadas em uma determinada data.
        /// </summary>
        [FieldFixedLength(7)]
        public string NumeroDoRo;

        /// <summary>
        /// Número do cartão truncado
        /// Número do cartão truncado: número do cartão que efetuou a compra com número truncado. Conterá zeros para compras via mobile payment ou comércio eletrônico, sendo para o último opcional.
        /// </summary>
        [FieldFixedLength(19)]
        public string NumeroDoCartaoTruncado;

        /// <summary>
        /// Data da venda/ajuste
        /// AAAAMMDD Data em que a venda ou o ajuste foi realizado.
        /// </summary>
        [FieldFixedLength(8)]
        public string DataDaVendaAjuste;

        /// <summary>
        /// Sinal do valor da compra ou valor da parcela
        /// "+" - Identifica valor a crédito.
        /// "-" - Identifica valor a débito
        /// </summary>
        [FieldFixedLength(1)]
        public string SinalDoValorDaCompraOuValorDaParcela;

        /// <summary>
        /// Valor da compra ou valor da parcela
        /// Valor da compra ou da parcela que foi liberada, no caso de venda parcelada na loja.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorDaCompraOuValorDaParcela;

        /// <summary>
        /// Parcela
        /// No caso de venda parcelada, será formatado com o número da parcela que está sendo liberada. No caso de venda à vista, será formatado com zeros.
        /// </summary>
        [FieldFixedLength(2)]
        public string Parcela;

        /// <summary>
        /// Total de parcelas
        /// Número total de parcelas da venda. No caso de venda à vista, será formatado com zero.
        /// </summary>
        [FieldFixedLength(2)]
        public string TotalDeParcelas;

        /// <summary>
        /// Motivo da rejeição
        /// Vide Tabela VIII, caso não possua rejeição o campo é formatado em branco.
        /// </summary>
        [FieldFixedLength(3)]
        public string MotivoDaRejeicao;

        /// <summary>
        /// Código de autorização
        /// Código de autorização da transação. Este número não é único e pode se repetir. Para efeito de conciliação deverá ser combinado com outras chaves.
        /// </summary>
        [FieldFixedLength(6)]
        public string CodigoDeAutorizacao;

        /// <summary>
        /// TID
        /// Identificação da transação realizada no comércio eletrônico ou mobile payment.
        /// </summary>
        [FieldFixedLength(20)]
        public string Tid;

        /// <summary>
        /// NSU/DOC
        /// Número sequencial, também conhecido como DOC (número do documento), que identifica a transação no dia em que ela foi realizada. Este número não é único e pode se repetir.
        ///Caso a venda tenha sido reprocessada, o NSU pode ser alterado.
        /// </summary>
        [FieldFixedLength(6)]
        public string Nsudoc;

        /// <summary>
        /// Valor Complementar
        /// Valor da transação de Saque com cartão de Débito ou Agro Electron de acordo com indicador de produto do RO.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorComplementar;

        /// <summary>
        /// Dig Cartão
        /// Número de dígitos do cartão
        /// </summary>
        [FieldFixedLength(2)]
        public string DigCartao;

        /// <summary>
        /// Valor total da venda no caso de Parcelado Loja
        /// O valor total da venda parcelada na loja é enviado somente no arquivo de vendas em todas as parcelas. Para os demais casos estará vazio.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorTotalDaVendaNoCasoDeParceladoLoja;

        /// <summary>
        /// Valor da próxima parcela
        /// O valor das próximas parcelas da venda é enviado somente no arquivo de vendas.
        ///Para clientes sem plano parcelado, será enviado em todas as parcelas da venda, com exceção da última parcela.
        ///Para clientes com plano parcelado será enviado na primeira parcela capturada e no detalhe da primeira parcela acelerada.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorDaProximaParcela;

        /// <summary>
        /// Número da Nota Fiscal
        /// Número da nota fiscal para estabelecimentos que capturam esta
        /// informação no POS.Quando não disponível será formatado com zeros.
        /// </summary>
        [FieldFixedLength(9)]
        public string NumeroDaNotaFiscal;

        /// <summary>
        /// Indicador de cartão emitido no exterior
        /// Identifica se o cartão que realizou a compra foi emitido no exterior conforme abaixo: 
        /// 0000 - Serviço não atribuído 
        /// 0001 - Cartão emitido no Brasil 
        /// 0002 - Cartão emitido no exterior
        /// </summary>
        [FieldFixedLength(4)]
        public string IndicadorDeCartaoEmitidoNoExterior;

        /// <summary>
        /// Número lógico do terminal
        /// Número lógico do terminal onde foi efetuada a venda.
        ///Quando o Meio de Captura for 06, desconsiderar esta informação.
        /// </summary>
        [FieldFixedLength(8)]
        public string NumeroLogicoDoTerminal;

        /// <summary>
        /// Identificador de taxa de embarque ou valor de entrada
        /// Identificação da transação referente à taxa de embarque ou valor de entrada:
        ///TX - Taxa de embarque;
        ///VE - Valor da entrada;
        ///Brancos - para demais tipos de transação.
        /// </summary>
        [FieldFixedLength(2)]
        public string IdentificadorDeTaxaDeEmbarqueOuValorDeEntrada;

        /// <summary>
        /// Referência/código do pedido
        /// Referência ou código do pedido informado em uma transação
        /// mobile payment e comércio eletrônico.
        /// Quando não disponível, será formatado com brancos.
        /// </summary>
        [FieldFixedLength(20)]
        public string ReferenciaCodigoDoPedido;

        /// <summary>
        /// Hora da transação
        /// Hora da transação apresentada no formado HHMMSS.
        ///Essa informação será gerada somente nos registros de venda do arquivo de venda com CV original.
        ///Nos demais casos, o campo será formatado com zeros.
        /// </summary>
        [FieldFixedLength(6)]
        public string HoraDaTransacao;

        /// <summary>
        /// Número único da transação
        /// Número Único que identifica cada transação.
        /// </summary>
        [FieldFixedLength(29)]
        public string NumeroUnicoDaTransacao;

        /// <summary>
        /// Indicador Cielo Promo
        /// Identificador do Produto Cielo Promo = "S".
        ///Identifica que a venda participou de campanha na Plataforma Promocional.
        ///Caso contrário, será formatado com brancos.
        /// </summary>
        [FieldFixedLength(1)]
        public string IndicadorCieloPromo;

        /// <summary>
        /// Uso Cielo
        /// Em Branco. Reservado para Cielo.
        /// </summary>
        [FieldFixedLength(32)]
        public string UsoCielo;
    }
}
