using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Manual_ASP_NET_WEB.Models;

namespace Manual_ASP_NET_WEB.Controllers
{
    public class ConsultasController : Controller
    {
        private MANUAL_ASP_NET_DBEntities db = new MANUAL_ASP_NET_DBEntities();

        // GET: Consultas
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(consultas.ToList());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            if (PacienteId == null || MedicoId == null || Fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(PacienteId, MedicoId, Fecha);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nombre");
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaciente,IdMedico,Fecha,Sintomas,Diagnostico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nombre", consulta.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre", consulta.IdPaciente);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            if (PacienteId == null || MedicoId == null || Fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(PacienteId, MedicoId, Fecha);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nombre", consulta.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre", consulta.IdPaciente);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaciente,IdMedico,Fecha,Sintomas,Diagnostico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMedico = new SelectList(db.Medicos, "Id", "Nombre", consulta.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Pacientes, "Id", "Nombre", consulta.IdPaciente);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            if (PacienteId == null || MedicoId == null || Fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(PacienteId, MedicoId, Fecha);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            Consulta consulta = db.Consultas.Find(PacienteId, MedicoId, Fecha);
            db.Consultas.Remove(consulta);
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
