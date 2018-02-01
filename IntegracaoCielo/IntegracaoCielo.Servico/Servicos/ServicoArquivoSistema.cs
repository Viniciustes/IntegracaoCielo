using System.IO;
using System.Web;

namespace IntegracaoCielo.Servico.Servicos
{
    internal class ServicoArquivoSistema
    {
        public void Save(HttpPostedFileBase file, string filename)
        {
            file.SaveAs(filename);
        }

        public DirectoryInfo CreateDirectory(string directoryName)
        {
            return Directory.CreateDirectory(directoryName);
        }
    }
}
