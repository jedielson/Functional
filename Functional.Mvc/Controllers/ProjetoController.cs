using System;
using System.Web.Mvc;
using Functional.Application.Interfaces;
using Functional.Mvc.ViewModels;
using Functional.Mvc.Controllers.Common;

namespace Functional.Mvc.Controllers
{
    using Functional.Mvc.Helpers;

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
            
            return this.DialogResult();
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

            return this.DialogResult();
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(Guid modelId)
        {
            throw new NotImplementedException();
        }
    }
}