using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
	public class CategoriasController: Controller
	{
		private readonly AppDbContext repositorioCategorias;

		public CategoriasController(AppDbContext context)
		{
			repositorioCategorias = context;
		}

		[HttpGet]
		public async Task<ActionResult> IniCategoria()
		{
			var categorias = await repositorioCategorias.Categorias.ToListAsync();
			return View(categorias);
		}

		public async Task<IActionResult> CrearCat(Categoria categoria)
		{
			if (ModelState.IsValid) 
			{
				repositorioCategorias.Add(categoria);
				await repositorioCategorias.SaveChangesAsync();
				return RedirectToAction(nameof(IniCategoria));
			}
			return View(categoria);
		}
	}
}
