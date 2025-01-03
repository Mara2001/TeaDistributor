using Microsoft.AspNetCore.Mvc;
using TeaDistributor.DTO;
using TeaDistributor.Services;

namespace TeaDistributor.Controllers
{
    public class TypesController : Controller
    {
        private TypeService typeService;

        public TypesController(TypeService typeService)
        {
            this.typeService = typeService;
        }

        public async Task<IActionResult> Index()
        {
            var allTypes = await typeService.GetAllTypes();
            return View(allTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeaTypeDTO teaTypeDTO)
        {
            await typeService.Create(teaTypeDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teaTypeDTO = await typeService.GetById(id);
            if (teaTypeDTO == null)
            {
                return View("NotFound");
            }
            return View(teaTypeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeaTypeDTO teaTypeDTO)
        {
            await typeService.Edit(id, teaTypeDTO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var teaTypeDTO = await typeService.GetById(id);
            if (teaTypeDTO == null)
            { return View("NotFound"); }
            await typeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
