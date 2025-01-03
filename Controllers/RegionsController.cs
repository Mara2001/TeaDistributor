using Microsoft.AspNetCore.Mvc;
using TeaDistributor.DTO;
using TeaDistributor.Services;

namespace TeaDistributor.Controllers
{
    public class RegionsController : Controller
    {
        private RegionService regionService;

        public RegionsController(RegionService regionService)
        {
            this.regionService = regionService;
        }

        public async Task<IActionResult> Index()
        {
            var allRegions = await regionService.GetAllRegions();
            return View(allRegions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeaRegionDTO teaRegionDTO)
        {
            await regionService.Create(teaRegionDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teaRegionDTO = await regionService.GetById(id);
            if (teaRegionDTO == null)
            {
                return View("NotFound");
            }
            return View(teaRegionDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeaRegionDTO teaRegionDTO)
        {
            await regionService.Edit(id, teaRegionDTO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var teaRegionDTO = await regionService.GetById(id);
            if (teaRegionDTO == null)
            { return View("NotFound"); }
            await regionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
