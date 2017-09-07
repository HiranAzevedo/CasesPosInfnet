using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.MVC.Mapper;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PublicacaoComentarioController : Controller
    {
        private readonly IPublicacaoAppService publicacaoApp;
        private readonly IComentarioAppService comentarioApp;

        public PublicacaoComentarioController(IPublicacaoAppService publicacaoApp, IComentarioAppService comentarioApp)
        {
            this.publicacaoApp = publicacaoApp;
            this.comentarioApp = comentarioApp;
        }

        // GET: PublicacaoComentario
        public ActionResult Index()
        {
            var allPublicacao = publicacaoApp.GetAll();
            var allComentario = comentarioApp.GetAll();

            var publicacoesViewModel = new List<PublicacaoComentarioViewModel>();

            foreach (var pub in allPublicacao)
            {
                var vm = PublicacaoComentarioMapper.BuildViewModelFromPublicacaoComentario(pub, allComentario.Where(x => x.IdPublicacao == pub.IdPublicacao));
                publicacoesViewModel.Add(vm);
            }
            return View(publicacoesViewModel);
        }

        // GET: PublicacaoComentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pub = publicacaoApp.GetById(id.Value);

            if (pub == null)
            {
                return HttpNotFound();
            }

            var comentarios = comentarioApp.GetAll().Where(x => x.IdPublicacao == id.Value);

            var publicacaoComentarioViewModel = PublicacaoComentarioMapper.BuildViewModelFromPublicacaoComentario(pub, comentarios);

            return View(publicacaoComentarioViewModel);
        }

        // GET: PublicacaoComentario/Create
        public ActionResult Create()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
