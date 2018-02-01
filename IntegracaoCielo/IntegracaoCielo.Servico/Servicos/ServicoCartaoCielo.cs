using IntegracaoCielo.Dominio.Entidades;
using IntegracaoCielo.Dominio.Interfaces.Repositorios;
using IntegracaoCielo.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace IntegracaoCielo.Servico.Servicos
{
    public class ServicoCartaoCielo : IServicoCartaoCielo
    {
        private readonly IRepositorioCartaoCielo _repositorioCartaoCielo;

        public ServicoCartaoCielo(IRepositorioCartaoCielo repositorioCartaoCielo)
        {
            _repositorioCartaoCielo = repositorioCartaoCielo;
        }

        public bool AdicionarProcessarArquivo(HttpFileCollectionBase files)
        {
            if (!VerificarArquivo(files)) return false;

            var serviceArquivoUpload = new ServicoArquivoUpload();
            var arquivo = serviceArquivoUpload.Upload(files);
            var serviceLerArquivo = new ServicoLerArquivo();
            var retornoArquivo = serviceLerArquivo.LerArquivo(arquivo[2]);

            var arquivoCielo = new ArquivoCielo(arquivo[0], arquivo[1]);

            return _repositorioCartaoCielo.GravarArquivoNoBanco(arquivoCielo, retornoArquivo);
        }

        public IEnumerable<ArquivoCielo> ObterTodos()
        {
            return _repositorioCartaoCielo.ObterTodos();
        }

        public void ProcessarArquivo(Guid id)
        {
            var arquivoCieloRM = _repositorioCartaoCielo.BuscarArquivoNoBanco(id);
            throw new NotImplementedException();
        }

        private bool VerificarArquivo(HttpFileCollectionBase files)
        {
            var httpPostedFileBase = files[0];
            var extension = Path.GetExtension(httpPostedFileBase?.FileName);
            if (extension == null) return false;
            var extensao = extension.Replace(".", "");
            var nome = httpPostedFileBase.FileName;

            return ServicoArquivoValidar.VerificarExtensaoArquivo(extensao) && VerificarArquivoExiste(nome);
        }

        private bool VerificarArquivoExiste(string nome)
        {
            var arquivo = _repositorioCartaoCielo.ObterPorNome(nome);
            return arquivo == null;
        }
    }
}
