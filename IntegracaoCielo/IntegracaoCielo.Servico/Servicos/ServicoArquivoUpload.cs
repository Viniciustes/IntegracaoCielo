using System.IO;
using System.Linq;
using System.Web;

namespace IntegracaoCielo.Servico.Servicos
{
    internal class ServicoArquivoUpload
    {
        private readonly ServicoArquivoSistema _servicoArquivoSistema;

        public ServicoArquivoUpload()
        {
            _servicoArquivoSistema = new ServicoArquivoSistema();
        }

        public string[] Upload(HttpFileCollectionBase files)
        {
            var diskBasepath = HttpContext.Current.Server.MapPath("~/");
            var appBasepath = HttpContext.Current.Server.MapPath("~/FilesUploads/");
            var directoryPath = Path.Combine(diskBasepath, appBasepath);
            var filename = files[0].FileName.Contains("\\") ? files[0].FileName.Split('\\').Last() : files[0].FileName;
            var fname = Path.Combine(directoryPath, filename);

            _servicoArquivoSistema.CreateDirectory(directoryPath);
            _servicoArquivoSistema.Save(files[0], fname);

            return new[] { filename, Path.GetExtension(filename).Replace(".", ""), fname };
        }
    }
}