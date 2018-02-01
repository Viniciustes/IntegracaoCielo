using FileHelpers;

namespace IntegracaoCielo.Dominio.Entidades
{
    /// <summary>
    /// Tipo 1 - Detalhe do Resumo de Operações (RO)
    /// </summary>
    [FixedLengthRecord()]
    public class ArquivoCieloDetalhes
    {
        /// <summary>
        /// Constante 1 - Identifica o tipo de registro detalhe do RO.
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
        /// Número do resumo de operação. Contêm informações referentes a um grupo de vendas realizadas em uma determinada data.
        /// </summary>
        [FieldFixedLength(7)]
        public string NumeroDoRo;

        /// <summary>
        /// Parcela
        /// No caso de venda parcelada, será formatado com o número da parcela que está sendo liberada na data do envio do arquivo.
        /// No caso de venda à vista, será formatado com brancos.
        /// </summary>
        [FieldFixedLength(2)]
        public string Parcela;

        /// <summary>
        /// "/" - Para vendas parceladas.
        /// "a" - Aceleração des parcelas.
        /// " " - Demais situações.
        /// </summary>
        [FieldFixedLength(1)]
        public string Filler;

        /// <summary>
        /// Plano
        /// No caso de venda parcelada, será formatado com o maior número de parcelas encontradas naquele grupo de vendas. Se o RO tiver vendas em 03, 04 ou 06 parcelas, será preenchido com 06.
        ///Se for uma aceleração de parcelas, será formatado com a maior parcela acelerada.
        ///Exemplo: (posições 019 a 023)
        ///02A02 indica a aceleração da parcela 02 até a 02, ou seja, somente uma parcela.
        ///03A08 indica a aceleração da parcela 03 até a parcela 08 do plano da venda, ou seja, foram aceleradas 06 parcelas.
        ///No caso de venda à vista, será formatado com brancos.
        /// </summary>
        [FieldFixedLength(2)]
        public string Plano;

        /// <summary>
        /// Tipo de Transação
        /// Código que identifica a transação vide Tabela II.
        ///Preenchido com 00 no Extrato de Saldo em Aberto(09) para o SaldoParcelado.
        /// </summary>
        [FieldFixedLength(2)]
        public string TipoDeTransacao;

        /// <summary>
        /// Data de apresentação
        /// AAMMDD Data em que o RO foi transmitido para a Cielo.
        /// </summary>
        [FieldFixedLength(6)]
        public string DataDeApresentacao;

        /// <summary>
        /// Data prevista de pagamento
        /// AAMMDD Data prevista de pagamento. Na recuperação, pode ser atualizada após o processamento da transação ou ajuste.
        /// </summary>
        [FieldFixedLength(6)]
        public string DataPrevistaDePagamento;

        /// <summary>
        /// Data de envio para o banco
        /// AAMMDD Data em que o arquivo de pagamento foi enviado ao banco.
        ///Na recuperação, pode ser atualizada após o processamento da transação ou ajuste.
        /// </summary>
        [FieldFixedLength(6)]
        public string DataDeEnvioParaoBanco;

        /// <summary>
        /// Sinal valor bruto
        /// "+" - Identifica valor a crédito.
        /// "-" - Identifica valor a débito.
        /// </summary>
        [FieldFixedLength(1)]
        public string SinalValorBruto;

        /// <summary>
        /// Valor bruto
        /// Somatória dos valores de venda.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorBruto;

        /// <summary>
        /// Sinal da comissão
        /// "+" - Identifica valor a crédito.
        /// "-" - Identifica valor a débito.
        /// </summary>
        [FieldFixedLength(1)]
        public string SinalDaComissao;

        /// <summary>
        /// Valor da comissão
        /// Valor da comissão descontada sobre as vendas.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorDaComissao;

        /// <summary>
        /// Sinal do valor rejeitado
        /// "+" - Identifica valor a crédito.
        /// "-" - Identifica valor a débito.
        /// </summary>
        [FieldFixedLength(1)]
        public string SinalDoValorRejeitado;

        /// <summary>
        /// Valor rejeitado
        /// Se houver rejeição, será preenchido com a somatória das transações rejeitadas.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorRejeitado;

        /// <summary>
        /// Sinal do valor líquido
        /// "+" - Identifica valor a crédito.
        /// "-" - Identifica valor a débito.
        /// </summary>
        [FieldFixedLength(1)]
        public string SinalDoValorLiquido;

        /// <summary>
        /// Valor líquido
        /// Valor das vendas descontado o valor da comissão.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorLiquido;

        /// <summary>
        /// Banco
        /// Código do banco no qual os valores foram depositados.
        /// </summary>
        [FieldFixedLength(4)]
        public string Banco;

        /// <summary>
        /// Agência
        /// Código da agência na qual os valores foram depositados.
        /// </summary>
        [FieldFixedLength(5)]
        public string Agencia;

        /// <summary>
        /// Conta-corrente
        /// Conta-corrente na qual os valores foram depositados.
        /// </summary>
        [FieldFixedLength(14)]
        public string ContaCorrente;

        /// <summary>
        /// Status do pagamento
        /// Identifica a situação em que se encontram os créditos enviados ao banco vide Tabela III. Na recuperação, o status é atualizado de acordo com o envio e retorno de confirmação de pagamento por parte do banco.
        /// </summary>
        [FieldFixedLength(2)]
        public string StatusDoPagamento;

        /// <summary>
        /// Quantidade de CVs aceitos
        /// Quantidades de vendas aceitas no RO.
        /// </summary>
        [FieldFixedLength(6)]
        public string QuantidadeDeCVsAceitos;

        /// <summary>
        /// Código do Produto (Desconsiderar)
        /// A partir de 01/03/2014, o Identificador do produto passa a ser enviado nas posições 233-235 com três caracteres. Desconsidere a informação enviada nesta posição.
        /// </summary>
        [FieldFixedLength(2)]
        public string CodigoDoProdutoDesconsiderar;

        /// <summary>
        /// Quantidades de CVs rejeitados
        /// Quantidade de vendas rejeitadas no RO.
        /// </summary>
        [FieldFixedLength(6)]
        public string QuantidadesDeCVsRejeitados;

        /// <summary>
        /// Identificador de revenda/aceleração
        /// Identifica as ocorrências de manutenção em transações parceladas na loja:
        /// "R" - Revenda 
        /// "A"- Aceleração Brancos 
        /// " " - (nenhuma ocorrência)
        /// </summary>
        [FieldFixedLength(1)]
        public string IdentificadorDeRevendaAceleracao;

        /// <summary>
        /// Data da captura de transação
        /// AAMMDD - Data em que a transação foi capturada pela Cielo.
        /// Na recuperação, pode ser atualizada após o processamento da transação ou ajuste.
        /// </summary>
        [FieldFixedLength(6)]
        public string DataDaCapturaDeTransacao;

        /// <summary>
        /// Origem do ajuste
        /// Identifica o tipo de ajuste vide Tabela V. Preenchido se o tipo de transação for:
        ///02 Ajuste crédito
        ///03 Ajuste débito
        ///04 Ajuste aluguel
        /// </summary>
        [FieldFixedLength(2)]
        public string OrigemDoAjuste;

        /// <summary>
        /// Valor complementar
        /// Valor do saque quando o produto for igual a 36 ou valor do Agro Electron para transações dos produtos 22 23 ou 25 apresentados na Tabela IV.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorComplementar;

        /// <summary>
        /// Identificador de Antecipação
        /// Identificador de antecipação do RO:
        /// " " Não antecipado; 
        /// "A" Antecipado na Cielo - ARV;
        /// "C" Antecipado no banco - Cessão de Recebíveis.
        /// </summary>
        [FieldFixedLength(1)]
        public string IdentificadorDeAntecipacao;

        /// <summary>
        /// Número da operação de Antecipação
        /// Identifica o número da operação de Antecipação apresentada no registro tipo 5 campo 12 ao 20, associada ao RO antecipado/cedido na Cielo ou no banco.
        ///Conterá zeros, caso o RO não tenha sido antecipado.
        /// </summary>
        [FieldFixedLength(9)]
        public string NumeroDaOperacaoDeAntecipacao;

        /// <summary>
        /// Sinal do valor Bruto antecipado
        /// "+" - Identifica valor a crédito.
        /// "-" - Identifica valor a débito.
        /// </summary>
        [FieldFixedLength(1)]
        public string SinalDoValorBrutoAntecipado;

        /// <summary>
        /// Valor Bruto Antecipado
        /// Valor bruto antecipado, fornecido quando o RO for antecipado/cedido. Será preenchido com zeros quando não houver antecipação. O valor bruto antecipado corresponde ao valor líquido do RO.
        /// </summary>
        [FieldFixedLength(13)]
        public string ValorBrutoAntecipado;

        /// <summary>
        /// Bandeira
        /// Código da Bandeira:
        /// 001 VISA
        /// 002 Mastercard
        /// 006 Sorocred
        /// 007 ELO
        /// 009 Diners
        /// 011 Agiplan
        /// 015 Banescard
        /// 023 Cabal
        /// 029 Credsystem
        /// 035 Esplanada
        /// 064 Credz
        /// </summary>
        [FieldFixedLength(3)]
        public string Bandeira;

        /// <summary>
        /// Número Único do RO
        /// Número Único de identificação do RO formatado da seguinte forma:
        /// Primeira parte(fixa) 15 posições fixas: identifica o resumo mantendo
        // o seu histórico na Cielo;
        /// Segunda parte(variável) 07 posições variáveis: Identifica as alterações
        /// realizadas no RO.
        /// </summary>
        [FieldFixedLength(22)]
        public string NumeroUnicoDoRo;

        /// <summary>
        /// Taxa de Comissão
        /// Percentual de comissão aplicado no valor da transação.
        /// </summary>
        [FieldFixedLength(4)]
        public string TaxaDeComissao;

        /// <summary>
        /// Tarifa
        /// Tarifa cobrada por transação.
        /// </summary>
        [FieldFixedLength(5)]
        public string Tarifa;

        /// <summary>
        /// Taxa de Garantia
        /// Percentual de desconto aplicado sobre transações Electron Pré-Datado.
        /// </summary>
        [FieldFixedLength(4)]
        public string TaxaDeGarantia;

        /// <summary>
        /// Meio de Captura
        /// Vide tabela VII.
        ///Caso a venda tenha sido reprocessada, o sistema enviará o meio de captura 06: Meio de captura manual.Neste caso, desconsiderar o valor informado no número lógico do terminal.Campo não disponível para vendas a débito no arquivo de pagamento diário e segunda parcela em diante das vendas parceladas no arquivo de pagamento diário e recuperado.
        /// </summary>
        [FieldFixedLength(2)]
        public string MeioDeCaptura;

        /// <summary>
        /// Número lógico do terminal
        /// Número lógico do terminal onde foi efetuada a venda. Quando o meio de captura for igual a 06, desconsiderar o número lógico do terminal, pois este será um número interno da Cielo.
        /// </summary>
        [FieldFixedLength(8)]
        public string NumeroLogicoDoTerminal;

        /// <summary>
        /// Código do Produto
        /// Código que identifica o produto vide Tabela IV.
        /// </summary>
        [FieldFixedLength(3)]
        public string CodigoDoProduto;

        /// <summary>
        /// Matriz de Pagamento
        /// Estabelecimento matriz da cadeia centralizada de pagamento.
        /// </summary>
        [FieldFixedLength(10)]
        public string MatrizDePagamento;

        /// <summary>
        /// Uso Cielo
        /// Em Branco. Reservado para Cielo.
        /// </summary>
        [FieldFixedLength(5)]
        public string UsoCielo;
    }
}
