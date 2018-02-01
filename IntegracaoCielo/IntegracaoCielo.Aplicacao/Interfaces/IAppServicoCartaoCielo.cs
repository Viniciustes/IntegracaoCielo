using IntegracaoCielo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Web;

namespace IntegracaoCielo.Aplicacao.Interfaces
{
    public interface IAppServicoCartaoCielo
    {
        IEnumerable<ArquivoCielo> ObterTodos();
        bool AdicionarProcessarArquivo(HttpFileCollectionBase files);
        void ProcessarArquivo(Guid id);
    }
}