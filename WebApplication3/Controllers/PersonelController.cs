using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PersonelController : Controller
    {
        private readonly AppDbContext _context;
        //değişen int a;
        //a=1

        //costructor oluşturuyor...
        public PersonelController(AppDbContext context)
        {
            _context = context;
        }


        //AppContext _context isim veriyorum...

        public IActionResult Index()
        {
            var veri = _context.Personels.ToList();
            //Linq ile veri çekiyorum tüm personel listesini 
            //çekiyorum 
            return View(veri);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personel gelen)
        {
            if(ModelState.IsValid)
            {
                Personel personel = new Personel();
                personel.Ad = gelen.Ad;
                personel.Soyad = gelen.Soyad;
                personel.Departman = gelen.Departman;
                personel.Maas = gelen.Maas;
                _context.Personels.Add(personel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var veri=_context.Personels.Where(x=>x.Id == id).FirstOrDefault();
            return View(veri);
        }
        [HttpPost]
        public IActionResult Edit(Personel gelen)
        {   var veri=_context.Personels.Where(x=>x.Id==gelen.Id).FirstOrDefault();
            //değiştirilecek kaydı bul...
            veri.Ad=gelen.Ad;
            veri.Soyad = gelen.Soyad;
            veri.Departman = gelen.Departman;
            veri.Maas = gelen.Maas;
            _context.Personels.Update(veri);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var veri = _context.Personels.Where(x => x.Id == id).FirstOrDefault();
            return View(veri);
        }
        [HttpPost]
        public IActionResult Delete(Personel gelen)
        {
            var veri=_context.Personels.Where(x=>x.Id== gelen.Id).FirstOrDefault();
            _context.Personels.Remove(veri);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
