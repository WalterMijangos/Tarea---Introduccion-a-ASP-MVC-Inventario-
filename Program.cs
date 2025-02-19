using Inventario.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ProductosDb"));
			builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ClientesDb"));
			builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MarcasDb"));
			builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CategoriasDb"));
			builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("EmpleadosDb"));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Inicio}/{id?}");

            app.Run();
        }
    }
}
