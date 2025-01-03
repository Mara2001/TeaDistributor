using Microsoft.AspNetCore.Mvc;
using TeaDistributor.DTO;
using TeaDistributor.Services;

namespace TeaDistributor.Controllers
{
    public class SuppliersController : Controller
    {
        private SupplierService supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var allSuppliers = await supplierService.GetAllSuppliers();
            return View(allSuppliers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeaSupplierDTO teaSupplierDTO)
        {
            await supplierService.Create(teaSupplierDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teaSupplierDTO = await supplierService.GetById(id);
            if (teaSupplierDTO == null)
            {
                return View("NotFound");
            }
            return View(teaSupplierDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TeaSupplierDTO teaSupplierDTO)
        {
            await supplierService.Edit(id, teaSupplierDTO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var teaSupplierDTO = await supplierService.GetById(id);
            if (teaSupplierDTO == null)
            { return View("NotFound"); }
            await supplierService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
