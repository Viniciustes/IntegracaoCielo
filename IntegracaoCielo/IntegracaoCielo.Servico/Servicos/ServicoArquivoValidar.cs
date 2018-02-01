namespace IntegracaoCielo.Servico.Servicos
{
    internal static class ServicoArquivoValidar
    {
        internal static bool VerificarExtensaoArquivo(string extensao)
        {
            const string tipoArquivo = "cmp";
            return extensao == tipoArquivo;
        }
    }
}
