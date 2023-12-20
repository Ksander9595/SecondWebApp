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
            return View(await db.Products.ToListAsync());
        }
        public IActionResult Sale()
        {
            return View();
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
                Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if(product != null) return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductBase product)
        {
            db.Products.Update(product);
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
            db.Equipments.Add(equipment);
            await db.SaveChangesAsync();
            Product? product = new Product();
            product.EquipmentId = equipment.Id;
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult CreateMoto()
        {
            return View();
        }
        public IActionResult CreateSpareParts()
        {
            return View();
        }
        
    }
}
