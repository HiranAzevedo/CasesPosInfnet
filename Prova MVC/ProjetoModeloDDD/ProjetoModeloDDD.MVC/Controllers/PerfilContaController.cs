using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.MVC.Mapper;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PerfilContaController : Controller
    {
        private readonly IPerfilAppService perfilApp;
        private readonly IContaAppService contaApp;

        public PerfilContaController(IPerfilAppService perfilApp, IContaAppService contaApp)
        {
            this.perfilApp = perfilApp;
            this.contaApp = contaApp;
        }

        // GET: PerfilConta
        public ActionResult Index()
        {
            var allContas = contaApp.GetAll().ToList();
            var allPerfis = perfilApp.GetAll().ToList();
            var perfilContas = new List<PerfilContaViewModel>();

            for (int i = 0; i < allContas.Count; i++)
            {
                perfilContas.Add(PerfilContaMapper.BuildViewModelFromContaPerfil(allContas[i], allPerfis[i]));
            }

            return View(perfilContas);
        }

        // GET: PerfilConta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var conta = contaApp.GetById(id.Value);
            var perfil = perfilApp.GetById(id.Value);

            var perfilContaViewModel = PerfilContaMapper.BuildViewModelFromContaPerfil(conta, perfil);

            if (conta == null && perfil == null)
            {
                return HttpNotFound();
            }

            return View(perfilContaViewModel);
        }

        // GET: PerfilConta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilConta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,SobreNome,NomeUsuario,Senha,Local")] PerfilContaViewModel perfilContaViewModel)
        {
            if (ModelState.IsValid)
            {
                var conta = PerfilContaMapper.ExtractContaFromViewModel(perfilContaViewModel);
                var perfil = PerfilContaMapper.ExtractPerfilFromViewModel(perfilContaViewModel);

                contaApp.Add(conta);

                perfil.IdConta = conta.IdConta;
                perfilApp.Add(perfil);

                return RedirectToAction(nameof(Index));
            }

            return View(perfilContaViewModel);
        }

        // GET: PerfilConta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var perfilContaViewModel = PerfilContaMapper.BuildViewModelFromContaPerfil(contaApp.GetById(id.Value), perfilApp.GetById(id.Value));

            if (perfilContaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(perfilContaViewModel);
        }

        // POST: PerfilConta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConta,Nome,SobreNome,NomeUsuario,Senha,Local")] PerfilContaViewModel perfilContaViewModel)
        {
            if (ModelState.IsValid)
            {
                var conta = PerfilContaMapper.ExtractContaFromViewModel(perfilContaViewModel);
                contaApp.Update(conta);

                var perfil = PerfilContaMapper.ExtractPerfilFromViewModel(perfilContaViewModel);
                perfilApp.Update(perfil);

                return RedirectToAction(nameof(Index));
            }
            return View(perfilContaViewModel);
        }

        // GET: PerfilConta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var conta = contaApp.GetById(id.Value);
            var perfil = perfilApp.GetById(id.Value);

            var perfilContaViewModel = PerfilContaMapper.BuildViewModelFromContaPerfil(conta, perfil);

            if (perfilContaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(perfilContaViewModel);
        }

        // POST: PerfilConta/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            perfilApp.Remove(perfilApp.GetById(id));
            contaApp.Remove(contaApp.GetById(id));

            return RedirectToAction(nameof(Index));
        }
    }
}
