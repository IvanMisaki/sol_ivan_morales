using SOL_IVAN_MORALES.Context;
using SOL_IVAN_MORALES.Models;
using SOL_IVAN_MORALES.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOL_IVAN_MORALES.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult Index()
        {
            using (var context = new OracleDbContext())
            {
                var prestamos = (from t1 in context.Prestamo
                                 join t2 in context.Libro on t1.ID_LIBRO equals t2.ID
                                 join t3 in context.Usuario on t1.DNI_USUARIO equals t3.DNI
                                 select new PRESTAMO_DETALLE
                                 { 
                                    PRESTAMO = t1,
                                    LIBRO = t2,
                                    USUARIO = t3
                                    })
                                 .OrderByDescending(p => p.PRESTAMO.ID)
                                 .ToList();

                return View(prestamos);
            }
        }

        [HttpGet]
        public ActionResult Insert()
        {
            using (var context = new OracleDbContext())
            {
                var ultimas_24_horas = DateTime.Now.AddMinutes(-1);//valor por defecto
                string tiempo_espera = System.Configuration.ConfigurationManager.AppSettings["tiempoParaDevolverLibro"];
                try
                {
                    ultimas_24_horas = DateTime.Now.AddMinutes(Convert.ToInt32(tiempo_espera)*(-1));
                }
                catch (Exception ex) { }

                var usuarios_con_3_prestamos_hoy = context.Prestamo
                                        .Where(p => p.FECHA_PRESTAMO >= ultimas_24_horas)
                                        .GroupBy(p => p.DNI_USUARIO)
                                        .Where(g => g.Count() >= 3)
                                        .Select(g => g.Key)
                                        .ToList();

                var usuarios_con_no_devueltos_ayer = context.Prestamo
                                        .Where(p => p.FECHA_PRESTAMO < ultimas_24_horas)
                                        .Where(p => p.FECHA_DEVOLUCION == null)
                                        .GroupBy(p => p.DNI_USUARIO)
                                        .Where(g => g.Count() >= 1)
                                        .Select(g => g.Key)
                                        .ToList();

                var libros = context.Libro.ToList();
                var usuarios_ok = context.Usuario
                                .Where(u => u.ESTADO == 1
                                && !usuarios_con_3_prestamos_hoy.Contains(u.DNI)//un usuario puede pedir maximo 3 libros por día
                                && !usuarios_con_no_devueltos_ayer.Contains(u.DNI)//un usuario no puede tener libros no devuelvos mas de 1 día
                                )
                                .ToList();
                var prestamo = new PRESTAMO();
                PrestamoViewModel oPrestamoViewmodel = new PrestamoViewModel();
                oPrestamoViewmodel.PRESTAMO = prestamo;
                oPrestamoViewmodel.lstLibro = libros;
                oPrestamoViewmodel.lstUsuario = usuarios_ok;
                return View(oPrestamoViewmodel);
            }
        }

        [HttpPost]
        public ActionResult Insert(PrestamoViewModel oPrestamoViewmodel, FormCollection formCollection)
        {
            PRESTAMO oPrestamo = oPrestamoViewmodel.PRESTAMO;
            oPrestamo.ID_LIBRO = Convert.ToInt32(formCollection["ID_LIBRO"]);
            oPrestamo.DNI_USUARIO = formCollection["DNI_USUARIO"];
            oPrestamo.FECHA_PRESTAMO = DateTime.Now;
            using (var context = new OracleDbContext())
            {
                context.Prestamo.Add(oPrestamo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            using (var context = new OracleDbContext())
            {
                var prestamoExistente = context.Prestamo.FirstOrDefault(l => l.ID == Id);

                PrestamoEditViewModel oPrestamoEditViewModel = new PrestamoEditViewModel();
                oPrestamoEditViewModel.PRESTAMO = prestamoExistente;
                oPrestamoEditViewModel.libro = context.Libro.FirstOrDefault(l => l.ID == prestamoExistente.ID_LIBRO);
                oPrestamoEditViewModel.usuario = context.Usuario.FirstOrDefault(u => u.DNI == prestamoExistente.DNI_USUARIO);
                oPrestamoEditViewModel.devuelto = oPrestamoEditViewModel.PRESTAMO.FECHA_DEVOLUCION != null ? true : false;

                return View(oPrestamoEditViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(PrestamoEditViewModel oPrestamoEditViewModel, FormCollection formCollection)
        {
            string tiempo_espera = System.Configuration.ConfigurationManager.AppSettings["tiempoParaDevolverLibro"];
            TimeSpan tiempo_tregua = TimeSpan.FromMinutes(1);//valor por defecto
            try
            {
                tiempo_tregua = TimeSpan.FromMinutes(Convert.ToInt32(tiempo_espera));
            }
            catch (Exception ex) { }
            PRESTAMO oPrestamo = oPrestamoEditViewModel.PRESTAMO;
            var devuelto = formCollection["devuelto"];

            using (var context = new OracleDbContext())
            {
                var prestamoExistente = context.Prestamo.FirstOrDefault(l => l.ID == oPrestamo.ID);
                prestamoExistente.TIPO_LECTURA = oPrestamo.TIPO_LECTURA;
                if (devuelto == "1")
                {
                    prestamoExistente.FECHA_DEVOLUCION = DateTime.Now;
                    if(prestamoExistente.FECHA_DEVOLUCION- prestamoExistente.FECHA_PRESTAMO> tiempo_tregua)
                    {
                        //Deshabilitar al usuario
                        USUARIO usuario_a_deshabilitar = context.Usuario.FirstOrDefault(u => u.DNI == prestamoExistente.DNI_USUARIO);
                        usuario_a_deshabilitar.ESTADO = 0;
                        context.SaveChanges();
                    }
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (var context = new OracleDbContext())
            {
                var prestamoExistente = context.Prestamo.FirstOrDefault(l => l.ID == Id);

                return View(prestamoExistente);
            }
        }

        [HttpPost]
        public ActionResult Delete(PRESTAMO oPrestamo)
        {
            using (var context = new OracleDbContext())
            {
                var prestamoExistente = context.Prestamo.FirstOrDefault(l => l.ID == oPrestamo.ID);
                context.Prestamo.Remove(prestamoExistente);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            using (var context = new OracleDbContext())
            {
                var prestamoExistente = context.Prestamo.FirstOrDefault(l => l.ID == Id);

                PrestamoEditViewModel oPrestamoEditViewModel = new PrestamoEditViewModel();
                oPrestamoEditViewModel.PRESTAMO = prestamoExistente;
                oPrestamoEditViewModel.libro = context.Libro.FirstOrDefault(l => l.ID == prestamoExistente.ID_LIBRO);
                oPrestamoEditViewModel.usuario = context.Usuario.FirstOrDefault(u => u.DNI == prestamoExistente.DNI_USUARIO);
                oPrestamoEditViewModel.devuelto = oPrestamoEditViewModel.PRESTAMO.FECHA_DEVOLUCION != null ? true : false;

                return View(oPrestamoEditViewModel);
            }
        }
    }
}