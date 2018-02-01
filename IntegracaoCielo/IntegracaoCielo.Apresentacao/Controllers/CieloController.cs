using IntegracaoCielo.Aplicacao.Interfaces;
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
            _appServicoCartaoCielo.ObterTodos();
            _appServicoCartaoCielo.AdicionarProcessarArquivo(null);
            return View();
        }
    }
}