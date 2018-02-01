using IntegracaoCielo.Aplicacao.Interfaces;
using System;
using System.Web.Mvc;

namespace IntegracaoCielo.Apresentacao.Controllers
{
    public class CieloController : Controller
    {
        private readonly IAppServicoCartaoCielo _appServicoCartaoCielo;

        public CieloController(IAppServicoCartaoCielo appServicoCartaoCielo)
        {
            _appServicoCartaoCielo = appServicoCartaoCielo;
        }

        // GET: Cielo
        public ActionResult Index()
        {
            var listaArquivosCielo =_appServicoCartaoCielo.ObterTodos();
            return View(listaArquivosCielo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarArquivo()
        {
            var files = Request.Files;

            if (files.Count <= 0) return RedirectToAction("MostraErro");

            var adicionou = _appServicoCartaoCielo.AdicionarProcessarArquivo(files);

            return adicionou ? RedirectToAction("Index") : RedirectToAction("MostraErro");
        }

        public ActionResult ProcessarArquivo(Guid id)
        {
            _appServicoCartaoCielo.ProcessarArquivo(id);
            return RedirectToAction("Index");
        }

        public ActionResult MostraErro()
        {
            return View();
        }
    }
}