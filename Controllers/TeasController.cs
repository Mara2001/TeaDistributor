using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TeaDistributor.DTO;
using TeaDistributor.Services;

namespace TeaDistributor.Controllers
{
    public class TeasController : Controller
    {
        private ItemService teaService;

        public TeasController(ItemService teaService)
        {
            this.teaService = teaService;
        }

        public async Task<IActionResult> Index()
        {
            var allTeas = await teaService.GetAllTeas();
            return View(allTeas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teaItemDropdownsValues = await teaService.GetTeaItemDropdownsValues();
            ViewBag.Types = new SelectList(teaItemDropdownsValues.Types, "Id", "Name");
            ViewBag.Regions = new SelectList(teaItemDropdownsValues.Regions, "Id", "Name");
            ViewBag.Suppliers = new SelectList(teaItemDropdownsValues.Suppliers, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeaItemDTO teaItemDTO)
        {
            await teaService.Create(teaItemDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teaItemDropdownsValues = await teaService.GetTeaItemDropdownsValues();
            ViewBag.Types = new SelectList(teaItemDropdownsValues.Types, "Id", "Name");
            ViewBag.Regions = new SelectList(teaItemDropdownsValues.Regions, "Id", "Name");
            ViewBag.Suppliers = new SelectList(teaItemDropdownsValues.Suppliers, "Id", "Name");

            var teaItemDTO = await teaService.GetById(id);
            if (teaItemDTO == null)
            {
                return View("NotFound");
            }
            return View(teaItemDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeaItemDTO teaItemDTO)
        {
            await teaService.Edit(id, teaItemDTO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var teaItemDTO = await teaService.GetById(id);
            if (teaItemDTO == null)
            { return View("NotFound"); }
            await teaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
