using SistemAntrianAlat.DAL;
using SistemAntrianAlat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemAntrianAlat.Controllers
{
    public class PengajuanController : Controller
    {
        // GET: Pengajuan
        ApplicationContext db = new ApplicationContext();

        // GET: Project
        public ActionResult Index()
        {
            var projects = db.Pengajuan.OrderByDescending(x => x.PengajuanId).ToList();
            return View(projects);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(string unitkerja, string alat, string alasan)
        {
            Pengajuan data = new Pengajuan
            {
                UnitKerja = unitkerja,
                Alat = alat,
                Alasan = alasan,
                Status = "Menunggu",
                TglPengajuan =DateTime.Now
            };
            db.Pengajuan.Add(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var project = db.Pengajuan.FirstOrDefault(p => p.PengajuanId == id);

            var antrian = db.Pengajuan
                              .Where(s => s.PengajuanId == id && s.Status != "Selesai")
                              .ToList();

            ViewBag.antrian = antrian;

            return View(project);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int pengajuanId, string status)
        {
            var data = db.Pengajuan.FirstOrDefault(x => x.PengajuanId == pengajuanId);
            if (data == null)
                return HttpNotFound();

            data.Status = status;
            db.SaveChanges();

            return RedirectToAction("Details", new { id = pengajuanId });
        }
    }
}