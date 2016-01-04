namespace Functional.Mvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Functional.Application.Interfaces;
    using Functional.Mvc.Controllers.Common;
    using Functional.Mvc.Helpers;
    using Functional.Mvc.ViewModels;
    using Functional.Mvc.ViewModels.Enumerations;

    public class ProjetoController : BaseController
    {
        private readonly IProjetoAppService _projetoAppService;

        public ProjetoController(IProjetoAppService projetoAppService)
        {
            _projetoAppService = projetoAppService;
        }

        //
        // GET: /Projeto/
        public ActionResult Index()
        {
            var model = ProjetoViewModel.ToViewModel(_projetoAppService.All(true));
            return View(model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProjetoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            var result = _projetoAppService.Create(ProjetoViewModel.ToDomainModel(model));

            if (!result.IsValid)
            {
                AddModelErrors(result);
                return PartialView(model);
            }

            var data = ProjetoViewModel.ToViewModel(this._projetoAppService.All(true));
            return this.HtmlDialogResult(string.Empty, nameof(this.Index), data);
        }

        public ActionResult Edit(Guid id)
        {
            var model = ProjetoViewModel.ToViewModel(_projetoAppService.Get(id));
            return PartialView(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ProjetoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            var result = _projetoAppService.Update(ProjetoViewModel.ToDomainModel(model));
            if (!result.IsValid)
            {
                AddModelErrors(result);
                return PartialView(model);
            }

            var data = this._projetoAppService.All(true);

            return this.HtmlDialogResult(string.Empty, nameof(this.Index), data);
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(Guid modelId)
        {
            throw new NotImplementedException();
        }

        public ActionResult MontaSelectProjeto(ViewModelEnumerations.TelaDropDownSelectProjeto? telaSelectProjeto)
        {
            var data = this._projetoAppService.All(true).Select(x => new ProjetoViewModel
                                {
                                    ProjetoId = x.ProjetoId,
                                    Nome = x.Codigo + " - " + x.Nome
                                });

            var model = new SelectProjetoViewModel
                            {
                                Projetos = data,
                                Tela = telaSelectProjeto
                            };
            return this.PartialView("SelectProjetos", model);
        }
    }
}