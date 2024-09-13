using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class MarcasController: Controller
    {
        private readonly AppDbContext repositorioMarcas;

        public MarcasController(AppDbContext context)
        {
            repositorioMarcas = context;
        }


        [HttpGet]
        public async Task<ActionResult> InicioMar()
        {
            var marcas =  await repositorioMarcas.Marcas.ToListAsync();
            return View(marcas);
        }

        public async Task<IActionResult> CrearMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                repositorioMarcas.Add(marca);
                await repositorioMarcas.SaveChangesAsync();
                return RedirectToAction(nameof(InicioMar));
            }
            return View(marca);
        }
    }
}
