using FileHelpers;
using IntegracaoCielo.Dominio.Entidades;
using System;

namespace IntegracaoCielo.Servico.Servicos
{
    internal class ServicoLerArquivo
    {
        public object[] LerArquivo(string urlArquivo)
        {
            var engine = new MultiRecordEngine(typeof(ArquivoCieloCabecalho), typeof(ArquivoCieloDetalhes),
                typeof(ArquivoCieloDetalhesCv), typeof(ArquivoCieloTrailer))
            {
                RecordSelector = CustomSelector
            };

            return engine.ReadFile(urlArquivo);
        }

        private static Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            switch (recordLine.Substring(0, 1))
            {
                case "0":
                    return typeof(ArquivoCieloCabecalho);
                case "1":
                    return typeof(ArquivoCieloDetalhes);
                case "2":
                    return typeof(ArquivoCieloDetalhesCv);
                case "9":
                    return typeof(ArquivoCieloTrailer);
                default:
                    return null;
            }
        }
    }
}