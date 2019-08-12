using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using lpeliculas.Models;

namespace lpeliculas.Controllers
{
    public class peliculasController : Controller
    {
        private lpeliculasContext db = new lpeliculasContext();

        // GET: peliculas
        public ActionResult Index(string MovieGendre,string actor, int page=1)
        {
            var gendreList = new List<string>();
            var gendreQuery = from m in db.peliculas
                              orderby m.Genero
                              select m.Genero;

            gendreList.AddRange(gendreQuery.Distinct());
            ViewBag.Moviegendre = new SelectList(gendreList);

            var movie = from d in db.peliculas
                        select d;

            if (!string.IsNullOrEmpty(actor))
            {
                movie = movie.Where(s => s.Protagonista.Contains(actor));
            }

            if (!string.IsNullOrEmpty(MovieGendre))
            {
                movie = movie.Where(x => x.Genero.Contains(MovieGendre));
            }

            var cantidadProPagina = 5;
           
                var peli = movie.OrderBy(c => c.PeliculaId)
                    .Skip((page - 1) * cantidadProPagina)
                    .Take(cantidadProPagina).ToList();

                var tRegirstros = movie.Count();

                var modelo = new IndexViewModel();
                modelo.peliculas = peli;
                modelo.PaginaActual = page;
                modelo.Totalregistros = tRegirstros;
                modelo.RegistrosporPagina = cantidadProPagina;
                modelo.ValorqueryString = new RouteValueDictionary();
                modelo.ValorqueryString["MovieGendre"] = MovieGendre;





            return View(modelo);
        }

        // GET: peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pelicula pelicula = db.peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeliculaId,Nombre,Duracion,Genero,FechaDeEstreno,Sinopsis,Protagonista")] pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pelicula pelicula = db.peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeliculaId,Nombre,Duracion,Genero,FechaDeEstreno,Sinopsis,Protagonista")] pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pelicula pelicula = db.peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pelicula pelicula = db.peliculas.Find(id);
            db.peliculas.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
