using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

public class HomeController : Controller
{
    private readonly UrunVt _urunVt;

    public HomeController()
    {
        _urunVt = new UrunVt();
    }

    public ActionResult Index(string searchstring)
    {
        return View();
    }

    public ActionResult Urunler(string searchString)
    {
        var urunler = _urunVt.UrunTable.ToList();

        if (!string.IsNullOrEmpty(searchString))
        {
            urunler = urunler.Where(u => u.Adi.ToUpper().Contains(searchString.ToUpper())).ToList();
        }

        return View(urunler);
    }

    public ActionResult Ekle()
    {
        return View();
    }

    public ActionResult Ekle1(UrunModel gelen)
    {
        _urunVt.UrunTable.Add(gelen);
        _urunVt.SaveChanges();
        return View("Index");
    }

    public ActionResult Delete(int gelen)
    {
        UrunModel sil = _urunVt.UrunTable.FirstOrDefault(p => p.Id == gelen);
        _urunVt.UrunTable.Remove(sil);
        List<IslemModel> silIslem = _urunVt.IslemTable.Where(p => p.Id == gelen).ToList();
        _urunVt.IslemTable.RemoveRange(silIslem);
        _urunVt.SaveChanges();
        return View("Index");
    }

    public ActionResult Update(int gelen)
    {
        UrunVt.UrunID = gelen;
        return View(_urunVt.UrunTable.FirstOrDefault(p => p.Id == gelen));
    }

    public ActionResult Update1(UrunModel yeni)
    {
        var eski = _urunVt.UrunTable.FirstOrDefault(p => p.Id == UrunVt.UrunID);
        eski.Adi = yeni.Adi;
        eski.BirimFiyat = yeni.BirimFiyat;
        eski.BirimGram = yeni.BirimGram;
        eski.BirimKoli = yeni.BirimKoli;
        eski.Fire = yeni.Fire;
        _urunVt.SaveChanges();
        return View("Index");
    }

    public ActionResult Islem(int gelen)
    {
        UrunVt.UrunID = gelen;
        return View();
    }

    public ActionResult Islem2(IslemModel gelen)
    {
        UrunModel urun = _urunVt.UrunTable.FirstOrDefault(p => p.Id == UrunVt.UrunID);
        float gram = gelen.ToplamGram - urun.Fire;
        IslemModel NewIslemModel = new IslemModel
        {
            UrunId = UrunVt.UrunID,
            ToplamGram = gram,
            Adet = gram / urun.BirimGram,
            ToplamFiyat = gram * urun.BirimFiyat,
            ToplamKoli = gram / urun.BirimKoli,
        };
        _urunVt.IslemTable.Add(NewIslemModel);
        _urunVt.SaveChanges();
        return View("Islem");
    }
}
