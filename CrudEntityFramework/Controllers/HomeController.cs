using CrudEntityFramework.Data;
using CrudEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        //crear variable solo lectura instancia ApplicationDbContext, clase creada en data
        private readonly ApplicationDbContext _context;

        //constructor
        //tengo acceso a mi contexto: a cualquiera de las tablas que esten mapeadas en el ApplicationDbContext

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //.............................................................
        //indico que es del tipo GET: retorna una tabla 
        //peticion GET para pedir datos
        //doble click sobre Index(): crear vista y se crea Index.cshtml
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        //.............................................................
        //creo nueva vista click en create y me crea la vista, del get, consulta bbdd
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //.............................................................
        //metodo create que se dispara en crear usuario de Create.cshtml
        //es post porque ingresa datos en la bbdd
        [HttpPost]
        //metodo que protege los formulario con las peticiones post
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            //valido el modelo con el metodo propio de ASP
            //que todos los campos ingresados cumplan con los atributos obligatorios
            if (ModelState.IsValid)
            {
                //funcionalidad para enviar datos a la bbdd
                //guardo usuario
                _context.Usuario.Add(usuario);
                //guardar cambios
                await _context.SaveChangesAsync();
                //retornar Index
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //.............................................................
        //metodo de la tecla edit de index para actualizar bbdd
        //aqui me muestra los datos existentes para que los cambie
        [HttpGet]
        public IActionResult Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //busco en context el id y lo guardo en la variable
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        //.......................................................
        //metodo que actualizar un usuario en la bbdd
        //aqui envia los datos modificados a la bbdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            
            if (ModelState.IsValid)
            {
                
                _context.Usuario.Update(usuario);
                //guardar cambios
                await _context.SaveChangesAsync();
                //retornar Index
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        //..........................................................
        //boton detalles
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //busco en context el id y lo guardo en la variable
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        //............................................................
        //boton borrar
        //aqui obtiene los registros de la bbdd mediante el id que es un campo oculto
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //busco en context el id y lo guardo en la variable
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        //..........................................................
        //metodo borrar
        //aqui envia los cambios a la bbdd
        //no puede ser delete porque ya esta creado
        //action name sera delete porque asi esta en el formulario de la vista
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegistro(int? id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return View();
            }


                _context.Usuario.Remove(usuario);
                //guardar cambios
                await _context.SaveChangesAsync();
                //retornar Index
                return RedirectToAction(nameof(Index));
           
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
