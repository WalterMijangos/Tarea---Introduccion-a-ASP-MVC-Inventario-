using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
	public class EmpleadoController: Controller
	{
		private readonly AppDbContext repositorioEmpleados;

		public EmpleadoController(AppDbContext context)
		{
			repositorioEmpleados = context;
		}

		[HttpGet]
		public async Task<ActionResult> InicioEmpleado()
		{
			var empleados = await repositorioEmpleados.Empleado.ToListAsync();
			return View(empleados);
		}

		public async Task<IActionResult> CrearEmplea(Empleado empleado)
		{
			if (ModelState.IsValid)
			{
				repositorioEmpleados.Add(empleado);
				await repositorioEmpleados.SaveChangesAsync();
				return RedirectToAction(nameof(InicioEmpleado));
			}
			return View(empleado);
		}
	}
}
