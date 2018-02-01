using IntegracaoCielo.Aplicacao.Interfaces;
using IntegracaoCielo.Dominio.Entidades;
using IntegracaoCielo.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;

namespace IntegracaoCielo.Aplicacao.Servicos
{
    public class AppServicoCartaoCielo : IAppServicoCartaoCielo
    {
        private IServicoCartaoCielo _servicoCartaoCielo;

        public AppServicoCartaoCielo(IServicoCartaoCielo servicoCartaoCielo)
        {
            _servicoCartaoCielo = servicoCartaoCielo;
        }

        public bool AdicionarProcessarArquivo(HttpFileCollectionBase files)
        {
            return _servicoCartaoCielo.AdicionarProcessarArquivo(files);
        }

        public IEnumerable<ArquivoCielo> ObterTodos()
        {
            return _servicoCartaoCielo.ObterTodos();
        }

        public void ProcessarArquivo(Guid id)
        {
            _servicoCartaoCielo.ProcessarArquivo(id);
        }
    }
}