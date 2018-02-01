using System;

namespace IntegracaoCielo.Dominio.Entidades
{
    public class ArquivoCieloRm
    {
        public Guid Id { get; set; }
        public string CodigoDeAutorizacao { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorDaComissao { get; set; }
        public decimal TaxaDeComissao { get; set; }
        public decimal ValorBrutoLote { get; set; }
        public decimal ValorLiquidoLote { get; set; }
        public decimal ValorDaComissaoLote { get; set; }
        public int QtdItensLote { get; set; }
    }
}
