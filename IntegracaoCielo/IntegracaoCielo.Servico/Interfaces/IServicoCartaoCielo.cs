using IntegracaoCielo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Web;

namespace IntegracaoCielo.Servico.Interfaces
{
    public interface IServicoCartaoCielo
    {
        IEnumerable<ArquivoCielo> ObterTodos();
        bool AdicionarProcessarArquivo(HttpFileCollectionBase files);
        void ProcessarArquivo(Guid id);
    }
}