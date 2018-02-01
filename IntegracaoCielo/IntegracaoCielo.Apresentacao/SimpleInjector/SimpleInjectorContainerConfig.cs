using IntegracaoCielo.Aplicacao.Interfaces;
using IntegracaoCielo.Aplicacao.Servicos;
using IntegracaoCielo.Dominio.Interfaces.Repositorios;
using IntegracaoCielo.Infraestrutura.Repositorios;
using IntegracaoCielo.Servico.Interfaces;
using IntegracaoCielo.Servico.Servicos;
using SimpleInjector;

namespace SimpleInjectorExample.SimpleInjector
{
    //Necessário instalação atravéz do Package Manage Console do Simple Injector
    //Install-Package SimpleInjector.Integration.Web.Mvc
    //Necessário chamar a classe no Global.asax do projeto no método Application_Start
    public static class SimpleInjectorContainerConfig
    {
        public static Container Config()
        {
            var container = new Container();

            container.Register<IAppServicoCartaoCielo, AppServicoCartaoCielo>(Lifestyle.Singleton);
            container.Register<IServicoCartaoCielo, ServicoCartaoCielo>(Lifestyle.Singleton);
            container.Register<IRepositorioCartaoCielo, RepositorioCartaoCielo>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }
    }
}