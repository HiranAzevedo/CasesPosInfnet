using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.ViewModels;
using ProjetoDDD.Infra.CrossCutting.MvcFilters;
using Microsoft.Ajax.Utilities;

namespace ProjetoDDD.UI.Mvc.Controllers
{
    [RoutePrefix("administrativo-clientes")]
    [Route("{action=listar}")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        [Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);

                if (!clienteEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(clienteEnderecoViewModel);
                }


                if (!clienteEnderecoViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = clienteEnderecoViewModel.ValidationResult.Message;
                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.ClienteId = id;
            return View(clienteViewModel);
        }

        [Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult ListarEnderecos(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_EnderecosList", _clienteAppService.ObterPorId(id).Enderecos);
        }

        [Route("adicionar-endereco")]
        public ActionResult AdicionarEndereco(Guid id)
        {
            ViewBag.ClienteId = id;
            return PartialView("_AdicionarEndereco");
        }

        [Route("adicionar-endereco")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AdicionarEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Clientes", new { id = enderecoViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarEndereco", enderecoViewModel);
        }

        [Route("adicionar-endereco/{id:guid}")]
        public ActionResult AtualizarEndereco(Guid id)
        {
            return PartialView("_AtualizarEndereco", _clienteAppService.ObterEnderecoPorId(id));
        }

        [Route("adicionar-endereco/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarEndereco(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.AtualizarEndereco(enderecoViewModel);

                string url = Url.Action("ListarEnderecos", "Clientes", new { id = enderecoViewModel.ClienteId });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarEndereco", enderecoViewModel);
        }

        [Route("excluir-endereco/{id:guid}")]
        public ActionResult DeletarEndereco(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enderecoViewModel = _clienteAppService.ObterEnderecoPorId(id.Value);
            if (enderecoViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarEndereco", enderecoViewModel);
        }

        // POST: Clientes/Delete/5

        [Route("excluir-endereco/{id:guid}")]
        [HttpPost, ActionName("DeletarEndereco")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarEnderecoConfirmed(Guid id)
        {
            var clienteId = _clienteAppService.ObterEnderecoPorId(id).ClienteId;
            _clienteAppService.RemoverEndereco(id);

            string url = Url.Action("ListarEnderecos", "Clientes", new { id = clienteId });
            return Json(new { success = true, url = url });
        }

        public ActionResult ObterImagemCliente(Guid id)
        {
            var root = @"C:\ProjetoDDD\clientes\";
            var foto = Directory.GetFiles(root, id+"*").FirstOrDefault();
           
            if (foto != null && !foto.StartsWith(root))
            {
                // Validando qualquer acesso indevido além da pasta permitida
                throw new HttpException(403, "Acesso Negado");
            }

            if(foto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return File(foto, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
