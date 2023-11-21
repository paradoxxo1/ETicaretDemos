using ETicaretDemos.Dto;
using ETicaretDemos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretDemos.Controllers
{
    public class HomeController : Controller
    {
        Context con = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Login(Login login)
        {
            if(login.Email== "deneme@gmail.com" && login.Password =="1")
            {
                return RedirectToAction("Home", "Home");
            }
            TempData["hata"] = "Şifre ya da kullanıcı adı hatalıdır";
            return RedirectToAction("Index", "Home");


        }

        [HttpGet] 
        public IActionResult Home()
        {
            //SqlDataAdapter adapter = new SqlDataAdapter("Select*from Urunler", connection);
            //DataTable dataTable = new DataTable();
            //dataTable.Clear();
            //adapter.Fill(dataTable);

            //
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    Urun urunler = new Urun();
            //    urunler.Id = Convert.ToInt16(dataTable.Rows[i]["Id"].ToString());
            //    urunler.UrunAdi = dataTable.Rows[i]["Urunadi"].ToString();
            //    urunler.Resim = dataTable.Rows[i]["Resim"].ToString();
            //    urunler.BirimFiyati =Convert.ToDecimal(dataTable.Rows[i]["BirimFiyati"].ToString());

            //    urunlerim.Add(urunler);
            //}

            List<Urun> urunlerim = new List<Urun>();
            urunlerim = con.Urunler.ToList();

            List<Sepet> sepetim = new List<Sepet>();
            sepetim = con.Sepetim.ToList();

            HomeDto list = new HomeDto();
            list.Urunlerim = urunlerim;
            list.Sepetim = sepetim;



            return View(list);
        }

        [HttpPost]
        public IActionResult SepeteEkle(int id,int adet)
        {
            Urun urun = con.Urunler.Where(p=> p.Id == id).FirstOrDefault();

            Sepet sepet = new Sepet();
            sepet.UrunAdi = urun.UrunAdi;
            sepet.Adet = adet;
            sepet.BirimFiyati = urun.BirimFiyati;
            sepet.Toplam = sepet.Adet * sepet.BirimFiyati;

            con.Sepetim.Add(sepet);
            con.SaveChanges();


            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public IActionResult SepettekiUrunuSil(int id)
        {
            Sepet sepet = con.Sepetim.Where(p=> p.Id == id).FirstOrDefault();
            con.Sepetim.Remove(sepet);
            con.SaveChanges();

            return RedirectToAction("Home", "Home");

        }

        [HttpPost]
        public IActionResult OdemeYap()
        {
            var result = con.Sepetim.ToList();
            foreach (var item in result)
            {
                con.Sepetim.Remove(item);
                con.SaveChanges();
            }
            TempData["odeme"] = "Ödeme Başarıyla Yapıldı";

            return RedirectToAction("Home", "Home");

        }
    }
}