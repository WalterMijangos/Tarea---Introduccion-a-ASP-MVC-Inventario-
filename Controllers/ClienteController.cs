using Inventario.Data;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Controllers
{
    public class ClientesController : Controller
    {

        private readonly AppDbContext repositorioClientes;

        public ClientesController(AppDbContext context)
        {
            repositorioClientes = context;
        }

        [HttpGet]
        public async Task<ActionResult> InicioCli()
        {
            var clientes = await repositorioClientes.Clientes.ToListAsync();
            return View(clientes);
        }

        public async Task<IActionResult> CrearCli(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                repositorioClientes.Add(cliente);
                await repositorioClientes.SaveChangesAsync();
                return RedirectToAction(nameof(InicioCli));
            }
            return View(cliente);
        }

    }
}
