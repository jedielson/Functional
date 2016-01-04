namespace Functional.Mvc.Controllers
{
    using System;
    using System.Web.Mvc;

    using Functional.Application.Interfaces;
    using Functional.Mvc.ViewModels;

    public class CasoDeUsoController : Controller
    {

        private readonly ICasoDeUsoAppService _casoDeUsoAppService;

        private readonly IRequisitoAppService _requisitoAppService;

        private readonly IProjetoAppService _projetoAppService;

        public CasoDeUsoController(ICasoDeUsoAppService casoDeUsoAppService, IRequisitoAppService requisitoAppService, IProjetoAppService projetoAppService)
        {
            this._casoDeUsoAppService = casoDeUsoAppService;
            this._requisitoAppService = requisitoAppService;
            this._projetoAppService = projetoAppService;
        }

        public ActionResult Index()
        {
            return View(new CasoDeUsoIndexViewModel());
        }

        [HttpPost]
        public ActionResult Index(Guid projetoId)
        {
            var model = new CasoDeUsoIndexViewModel
                            {
                                ProjetoId = projetoId,
                                Projetos = ProjetoViewModel.ToViewModel(this._projetoAppService.All())
                            };
            return this.View(model);
        }
        
        public ActionResult CarregaWorkArea(Guid projetoId)
        {
            var model = new CasoDeUsoIndexViewModel
            {
                ProjetoId = projetoId,
                Projetos = ProjetoViewModel.ToViewModel(this._projetoAppService.All())
            };
            return this.PartialView("WorkArea",model);
        }

        [HttpGet]
        public ActionResult Create(Guid projetoId)
        {
            var requisitos = this._requisitoAppService.Find(x => x.ProjetoId == projetoId, true);

            var model = new CasoDeUsoViewModel
                            {
                                Requisitos = RequisitoViewModel.ToViewModel(requisitos)
                            };
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCasoDeUso(CasoDeUsoViewModel model)
        {
            return null;
        }
    }
}