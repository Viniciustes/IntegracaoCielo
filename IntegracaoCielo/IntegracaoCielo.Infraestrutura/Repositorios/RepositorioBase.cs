using IntegracaoCielo.Infraestrutura.Contexto;
using System;

namespace IntegracaoCielo.Infraestrutura.Repositorios
{
    public class RepositorioBase : IDisposable
    {
        protected IntegracaoDbContexto Db = new IntegracaoDbContexto();

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}