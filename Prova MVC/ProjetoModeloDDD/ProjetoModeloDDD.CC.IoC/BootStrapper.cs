using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Infra.Data.Context;
using ProjetoModeloDDD.Infra.Data.Repositories;
using SimpleInjector;


namespace ProjetoModeloDDD.CC.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            //App
            container.Register<IComentarioAppService, ComentarioAppService>(Lifestyle.Scoped);
            container.Register<IPublicacaoAppService, PublicacaoAppService>(Lifestyle.Scoped);
            container.Register<IContaAppService, ContaAppService>(Lifestyle.Scoped);
            container.Register<IPerfilAppService, PerfilAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IComentarioService, ComentarioService>(Lifestyle.Scoped);
            container.Register<IPublicacaoService, PublicacaoService>(Lifestyle.Scoped);
            container.Register<IContaService, ContaService>(Lifestyle.Scoped);
            container.Register<IPerfilService, PerfilService>(Lifestyle.Scoped);

            //Infra
            container.Register<IComentarioRepository, ComentarioRepository>(Lifestyle.Scoped);
            container.Register<IPublicacaoRepository, PublicacaoRepository>(Lifestyle.Scoped);
            container.Register<IContaRepository, ContaRepository>(Lifestyle.Scoped);
            container.Register<IPerfilRepository, PerfilRepository>(Lifestyle.Scoped);
            container.Register<ProjetoModeloContext>(Lifestyle.Scoped);
        }
    }
}
