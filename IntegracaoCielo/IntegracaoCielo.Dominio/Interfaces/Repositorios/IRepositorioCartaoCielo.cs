using IntegracaoCielo.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace IntegracaoCielo.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioCartaoCielo
    {
        IEnumerable<ArquivoCielo> ObterTodos();
        bool GravarArquivoNoBanco(ArquivoCielo arquivoCielo, object[] retornoArquivo);
        IEnumerable<ArquivoCieloRm> BuscarArquivoNoBanco(Guid id);
        ArquivoCielo ObterPorNome(string nome);
    }
}