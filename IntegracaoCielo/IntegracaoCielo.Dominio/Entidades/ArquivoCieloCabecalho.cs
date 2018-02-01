using FileHelpers;

namespace IntegracaoCielo.Dominio.Entidades
{
    /// <summary>
    /// Tipo 0 - Header
    /// </summary>
    [FixedLengthRecord()]
    public class ArquivoCieloCabecalho
    {
        /// <summary>
        /// Tipo de registro
        /// Constante 0: identifica o tipo de registro header (início do arquivo).
        /// </summary>
        [FieldFixedLength(1)]
        public string TipoDeRegistro;

        /// <summary>
        /// Estabelecimento Matriz
        /// Número do estabelecimento matriz da cadeia de extrato eletrônico.
        /// </summary>
        [FieldFixedLength(10)]
        public string EstabelecimentoMatriz;

        /// <summary>
        /// Data de processamento
        /// AAAAMMDD data em que o arquivo foi gerado.
        /// </summary>
        [FieldFixedLength(8)]
        public string DataDeProcessamento;

        /// <summary>
        /// Período inicial
        /// AAAAMMDD menor data de captura encontrada no movimento.
        /// </summary>
        [FieldFixedLength(8)]
        public string PeriodoInicial;

        /// <summary>
        /// Período final
        /// AAAAMMDD maior data de captura encontrada no movimento.
        /// </summary>
        [FieldFixedLength(8)]
        public string PeriodoFinal;

        /// <summary>
        /// Sequência
        /// Número sequencial do arquivo. Nos casos de recuperação, este dado será enviado como 9999999.
        /// </summary>
        [FieldFixedLength(7)]
        public string Sequencia;

        /// <summary>
        /// Empresa adquirente
        /// Constante Cielo.
        /// </summary>
        [FieldFixedLength(5)]
        public string EmpresaAdquirente;

        /// <summary>
        /// Opção de extrato
        /// Tabela I.
        /// 03 - Vendas com Plano Parcelado
        /// 04 - Pagamentos
        /// 06 - Antecipação de Recebíveis
        /// 07 - Cessão de Recebíveis
        /// 08 - Parcelas Pendentes
        /// 09 - Saldo em Aberto
        /// </summary>
        [FieldFixedLength(2)]
        public string OpcaoDeExtrato;

        /// <summary>
        /// VAN
        /// "I" - Open Text (antiga GXS).
        /// "P" - TIVIT.
        /// </summary>
        [FieldFixedLength(1)]
        public string Van;

        /// <summary>
        /// Caixa Postal
        /// Informação obtida no formulário de cadastro na VAN.
        /// </summary>
        [FieldFixedLength(20)]
        public string CaixaPostal;

        /// <summary>
        /// Versão Layout
        /// Constante 001.
        /// </summary>
        [FieldFixedLength(3)]
        public string VersaoLayout;

        /// <summary>
        /// Uso Cielo
        /// Em Branco. Reservado para Cielo.
        /// </summary>
        [FieldFixedLength(177)]
        public string UsoCielo;
    }
}
