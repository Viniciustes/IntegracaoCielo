using System;

namespace IntegracaoCielo.Dominio.Entidades
{
    public class ArquivoCielo
    {
        public ArquivoCielo()
        {

        }
        public ArquivoCielo(string nomeArquivo, string tipoArquivo)
        {
            Id = Guid.NewGuid();
            NomeArquivo = nomeArquivo;
            TipoArquivo = tipoArquivo;
            DataImportacao = DateTime.Now;
            StatusProcessamento = true;
            DataImportacaoRm = null;
            StatusProcessamentoRm = false;
        }

        public Guid Id { get; private set; }
        public string NomeArquivo { get; private set; }
        public string TipoArquivo { get; private set; }
        public DateTime DataImportacao { get; private set; }
        public bool StatusProcessamento { get; private set; }
        public DateTime? DataImportacaoRm { get; private set; }
        public bool StatusProcessamentoRm { get; private set; }
    }
}
