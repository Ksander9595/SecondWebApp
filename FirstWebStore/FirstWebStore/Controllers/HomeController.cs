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

        public async Task<IActionResult> Index()
        {
            return View(await db.ProductBases.ToListAsync());
        }
        public async Task<IActionResult> Sale()
        {
            var MotoList = await db.ProductBases.Where(m=>m.Type == ProductTypes.Motocycle).ToListAsync();
            return View(MotoList);
        }
        public IActionResult Equipment()
        {
            return View();
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
