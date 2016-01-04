namespace Functional.Mvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Functional.Application.Interfaces;
    using Functional.Mvc.Controllers.Common;
    using Functional.Mvc.Helpers;
    using Functional.Mvc.ViewModels;

    public class RequisitoController : BaseController
    {
        private readonly IProjetoAppService _projetoAppService;

        private readonly IRequisitoAppService _requisitoAppService;

        public RequisitoController(IProjetoAppService projetoAppService, IRequisitoAppService requisitoAppService)
        {
            this._projetoAppService = projetoAppService;
            this._requisitoAppService = requisitoAppService;
        }

        // GET: Requisito
        public ActionResult Index()
        {
            var data = this._projetoAppService.All().Select(x => new ProjetoViewModel
                                                                     {
                                                                         ProjetoId = x.ProjetoId,
                                                                         Nome = x.Codigo + " - " + x.Nome
                                                                     });

            var model = new RequisitosIndexViewModel
                            {
                                Projetos = data
                            };
            return View(model);
        }

        public ActionResult CarregaGrid(Guid projetoId)
        {
            var data = RequisitoViewModel.ToViewModel(this._requisitoAppService.Find(x => x.ProjetoId == projetoId).ToList());
            var model = new RequisitosIndexViewModel
                            {
                                ProjetoId = projetoId,
                                Requisitos = data
                            };

            return this.PartialView("Grid", model);
        }

        public ActionResult Create(Guid projetoId)
        {
            var model = new RequisitoViewModel
                            {
                                ProjetoId = projetoId
                            };
            return this.PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequisitoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.PartialView(model);
            }

            var result = this._requisitoAppService.Create(RequisitoViewModel.ToDomainModel(model));

            if (!result.IsValid)
            {
                AddModelErrors(result);
                return PartialView(model);
            }

            var grid = new RequisitosIndexViewModel
                            {
                                ProjetoId = model.ProjetoId,
                                Projetos = ProjetoViewModel.ToViewModel(this._projetoAppService.All(true)),
                                Requisitos = RequisitoViewModel.ToViewModel(this._requisitoAppService.All(true))
                            };

            return this.HtmlDialogResult(string.Empty, "Grid", grid);
        }

        public ActionResult Delete(Guid modelId)
        {
            var model = this._requisitoAppService.Get(modelId);
            var result = this._requisitoAppService.Remove(model);

            var grid = new RequisitosIndexViewModel
                            {
                                ProjetoId = model.ProjetoId,
                                Projetos = ProjetoViewModel.ToViewModel(this._projetoAppService.All(true)),
                                Requisitos = RequisitoViewModel.ToViewModel(this._requisitoAppService.All(true))
                            };

            return this.HtmlDialogResult(string.Empty, "Grid", grid);
        }

        public ActionResult Edit(Guid id)
        {
            var model = RequisitoViewModel.ToViewModel(this._requisitoAppService.Get(id));
            return this.PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RequisitoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.PartialView(model);
            }

            var result = this._requisitoAppService.Update(RequisitoViewModel.ToDomainModel(model));

            if (!result.IsValid)
            {
                this.AddModelErrors(result);
                return this.PartialView(model);
            }

            var grid = new RequisitosIndexViewModel
                           {
                               ProjetoId = model.ProjetoId,
                               Projetos = ProjetoViewModel.ToViewModel(this._projetoAppService.All(true)),
                               Requisitos = RequisitoViewModel.ToViewModel(this._requisitoAppService.Find(x => x.ProjetoId == model.ProjetoId))
                           };

            return this.HtmlDialogResult(string.Empty, "Grid", grid);
        }
    }
}