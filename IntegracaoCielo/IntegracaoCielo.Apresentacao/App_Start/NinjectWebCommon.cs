[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IntegracaoCielo.Apresentacao.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(IntegracaoCielo.Apresentacao.App_Start.NinjectWebCommon), "Stop")]

namespace IntegracaoCielo.Apresentacao.App_Start
{

    using IntegracaoCielo.Aplicacao.Interfaces;
using IntegracaoCielo.Aplicacao.Servicos;
using IntegracaoCielo.Dominio.Interfaces.Repositorios;
using IntegracaoCielo.Infraestrutura.Contexto;
using IntegracaoCielo.Infraestrutura.Repositorios;
using IntegracaoCielo.Servico.Interfaces;
using IntegracaoCielo.Servico.Servicos;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;


    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IntegracaoDbContexto>().ToSelf().InRequestScope();

            kernel.Bind<IAppServicoCartaoCielo>().To<AppServicoCartaoCielo>().InRequestScope();
            kernel.Bind<IServicoCartaoCielo>().To<ServicoCartaoCielo>().InRequestScope();
            kernel.Bind<IRepositorioCartaoCielo>().To<RepositorioCartaoCielo>().InRequestScope();
        }
    }
}