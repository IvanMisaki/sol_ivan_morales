using SOL_IVAN_MORALES.Context;
using SOL_IVAN_MORALES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_IVAN_MORALES.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            using (var context = new OracleDbContext())
            {
                List<USUARIO> usuarios = new List<USUARIO>();
                usuarios = context.Usuario.ToList();
                return View(usuarios);
            }
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(USUARIO oUsuario)
        {
            using (var context = new OracleDbContext())
            {
                context.Usuario.Add(oUsuario);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(string DNI)
        {
            using (var context = new OracleDbContext())
            {
                var usuarioExistente = context.Usuario.FirstOrDefault(l => l.DNI == DNI);
                return View(usuarioExistente);
            }
        }

        [HttpPost]
        public ActionResult Edit(USUARIO oUsuario)
        {
            using (var context = new OracleDbContext())
            {
                var usuarioExistente = context.Usuario.FirstOrDefault(l => l.DNI == oUsuario.DNI);
                usuarioExistente.NOMBRES = oUsuario.NOMBRES;
                usuarioExistente.APELLIDOS = oUsuario.APELLIDOS;
                usuarioExistente.EMAIL = oUsuario.EMAIL;
                usuarioExistente.TELEFONO = oUsuario.TELEFONO;
                usuarioExistente.ESTADO = oUsuario.ESTADO;
                usuarioExistente.TIPO = oUsuario.TIPO;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(string DNI)
        {
            using (var context = new OracleDbContext())
            {
                var usuarioExistente = context.Usuario.FirstOrDefault(l => l.DNI == DNI);
                return View(usuarioExistente);
            }
        }

        [HttpPost]
        public ActionResult Delete(USUARIO oUsuario)
        {
            using (var context = new OracleDbContext())
            {
                var usuarioExistente = context.Usuario.FirstOrDefault(l => l.DNI == oUsuario.DNI);
                context.Usuario.Remove(usuarioExistente);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(USUARIO oUsuario)
        {
            using (var context = new OracleDbContext())
            {
                var usuarioExistente = context.Usuario.FirstOrDefault(l => l.DNI == oUsuario.DNI);
                return View(usuarioExistente);
            }
        }
    }
}