using Microsoft.AspNetCore.Mvc;
using FirstWebStore.Models;
using Microsoft.EntityFrameworkCore;
using FirstWebStore.Entities;

namespace FirstWebStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;        
       
        public HomeController(ApplicationContext context)
        {
            db = context;       
        }

        public async Task<IActionResult> Index(string name, ProductTypes type)
        {
            IEnumerable<ProductBase> productBase = await db.ProductBases.ToListAsync();
            if(!string.IsNullOrEmpty(name))
            {
                productBase = productBase.Where(p => p.Name!.Contains(name));
            }
            if(type != 0)
            {
                productBase = productBase.Where(p => p.Type == type);
            }

            IndexViewModel viewModel = new IndexViewModel(productBase, new FilterViewModel(name));
            return View(viewModel);
        }   
        public async Task<IActionResult> Sale(string name, MotocycleType type)
        {
            IEnumerable<Motocycle> motocycles = await db.Motocycles.ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                motocycles = motocycles.Where(p => p.Name!.Contains(name));
            }  
            if(type != 0)
            {
                motocycles = motocycles.Where(p=>p.MotoType == type);
            }

            IndexViewModel viewModel = new IndexViewModel(motocycles, new FilterViewModel(name));
            return View(viewModel);
        }
        public async Task<IActionResult> Equipment(string name, EquipmentType type)
        {
            IEnumerable<Equipment> equipmants = await db.Equipments.ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                equipmants = equipmants.Where(p => p.Name!.Contains(name));
            }
            if(type != 0)
            {
                equipmants = equipmants.Where(p=>p.EquipType == type);
            }
            IndexViewModel viewModel = new IndexViewModel(equipmants, new FilterViewModel(name));
            return View(viewModel);
        }
        public async Task<IActionResult> SpareParts(string name, SparePartType type)
        {
            IEnumerable<SparePart> spareParts = await db.SpareParts.ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                spareParts = spareParts.Where(p => p.Name!.Contains(name));
            }
            if(type != 0)
            {
                spareParts = spareParts.Where(p => p.PartsType == type);
            }

            IndexViewModel viewModel = new IndexViewModel(spareParts, new FilterViewModel(name));
            return View(viewModel);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id != null)
            {
                ProductBase? product = await db.ProductBases.FirstOrDefaultAsync(p => p.Id == id);
                db.ProductBases.Remove(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                ProductBase? product = await db.ProductBases.FirstOrDefaultAsync(p => p.Id == id);
                if(product != null) return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductBase product)
        {
            db.ProductBases.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult CreateEquipment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {
            equipment.Type = ProductTypes.Equipment;
            db.ProductBases.Add(equipment);          
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult CreateMoto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMoto(Motocycle motocycle)
        {
            motocycle.Type = ProductTypes.Motocycle;
            db.ProductBases.Add(motocycle);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult CreateSpareParts()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpareParts(SparePart sparePart)
        {
            sparePart.Type = ProductTypes.SparePart;
            db.ProductBases.Add(sparePart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
