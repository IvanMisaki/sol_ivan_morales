using SOL_IVAN_MORALES.Context;
using SOL_IVAN_MORALES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_IVAN_MORALES.Controllers
{
    public class LibroController : Controller
    {

        // GET: Libro
        public ActionResult Index()
        {
            using (var context = new OracleDbContext())
            {
                List<LIBRO> libros = new List<LIBRO>();
                libros = context.Libro.ToList();
                return View(libros);
            }

        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(LIBRO oLibro)
        {
            using (var context = new OracleDbContext())
            {
                context.Libro.Add(oLibro);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            using (var context = new OracleDbContext())
            {
                var libroExistente = context.Libro.FirstOrDefault(l => l.ID == Id);
                return View(libroExistente);
            }
        }

        [HttpPost]
        public ActionResult Edit(LIBRO oLibro)
        {
            using (var context = new OracleDbContext())
            {
                var libroExistente = context.Libro.FirstOrDefault(l => l.ID == oLibro.ID);
                libroExistente.NOMBRE = oLibro.NOMBRE;
                libroExistente.CATEGORIA = oLibro.CATEGORIA;
                libroExistente.AUTOR = oLibro.AUTOR;
                libroExistente.PAIS = oLibro.PAIS;
                libroExistente.EDITORIAL = oLibro.EDITORIAL;
                libroExistente.FECHA_PUBLICACION = oLibro.FECHA_PUBLICACION;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (var context = new OracleDbContext())
            {
                var libroExistente = context.Libro.FirstOrDefault(l => l.ID == Id);
                return View(libroExistente);
            }
        }

        [HttpPost]
        public ActionResult Delete(LIBRO oLibro)
        {
            using (var context = new OracleDbContext())
            {
                var libroExistente = context.Libro.FirstOrDefault(l => l.ID == oLibro.ID);
                context.Libro.Remove(libroExistente);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            using (var context = new OracleDbContext())
            {
                var libroExistente = context.Libro.FirstOrDefault(l => l.ID == Id);
                return View(libroExistente);
            }
        }
    }
}