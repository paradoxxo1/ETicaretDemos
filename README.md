# ETicaretDemos  
**•	-HomeController Sınıfı oluşturuldu.**  
HttpGet - Index Metodu: Ana sayfanın HTTP GET taleplerini karşılayan Index adında bir metot oluşturuldu.  
**•	HttpPost - Login Metodu:**  
Giriş işlemlerini kontrol eden Login adında bir model parametresi alan Login adında bir metot oluşturuldu.  
Giriş başarılıysa "Home" sayfasına yönlendirme yapılıyor; başarısızsa "Index" sayfasına hata mesajı ile yönlendirme yapılıyor.  
**•	HttpGet - Home Metodu:**  
Ana sayfanın HTTP GET taleplerini karşılayan Home adında bir metot oluşturuldu.  
Ürünler ve sepet içeriğini listeleyen bir HomeDto nesnesi oluşturulup, bu nesne view'e gönderiliyor.  
**•	HttpPost - SepeteEkle Metodu:**  
Belirli bir ürünü sepete eklemek için kullanılan SepeteEkle adında bir metot oluşturuldu.  
**•	HttpPost - SepettekiUrunuSil Metodu:**  
Belirli bir ürünü sepetten silmek için kullanılan SepettekiUrunuSil adında bir metot oluşturuldu.  
**•	HttpPost - OdemeYap Metodu:**  
Sepetteki tüm ürünleri satın almak için kullanılan OdemeYap adında bir metot oluşturuldu. Sepet temizleniyor ve ödeme başarılı mesajı gösteriliyor.  
**•	View ve Model Kullanımı:**  
Razor sayfaları kullanılarak, Index ve Home sayfaları oluşturulmuş.  
HomeDto modeli, view tarafında kullanılmak üzere controller tarafından view'e gönderiliyor.  
**•	Routing ve Yönlendirme:**  
RedirectToAction metodu kullanılarak, başarılı veya başarısız işlemler sonrasında ilgili sayfalara yönlendirmeler yapılıyor.  
**•	TempData Kullanımı:**  
TempData kullanılarak, bir sayfa üzerinde geçici veri saklama işlemi gerçekleştiriliyor (örneğin, hata mesajları veya ödeme bilgisi).  
**•	Entity Framework ORM Kullanımı:**  
Entity Framework ORM kullanılarak, veritabanı işlemleri gerçekleştiriliyor.  

### LocalHost HomePage Örnek Kullanıcı Bilgileri;  
**Mail Adresi: deneme@gmail.com**  
**Şifresi : 1**  

# DATABASE ÖZELLİKLERİ  
# DATABASE ADI : ETicaretDemeDb  

*SEPETİM TABLOSU*  

SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE TABLE [dbo].[Sepetim](  
	[Id] [int] IDENTITY(1,1) NOT NULL,  
	[UrunAdi] [varchar](max) NOT NULL,  
	[Adet] [int] NOT NULL,  
	[BirimFiyati] [money] NOT NULL,  
	[Toplam] [money] NOT NULL,  
 CONSTRAINT [PK_Sepet] PRIMARY KEY CLUSTERED   
(  
	[Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  
GO  

*ÜRÜNLER TABLOSU*  

SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
CREATE TABLE [dbo].[Urunler](  
	[Id] [int] IDENTITY(1,1) NOT NULL,  
	[UrunAdi] [varchar](max) NOT NULL,  
	[BirimFiyati] [money] NOT NULL,  
	[Resim] [varchar](max) NOT NULL,  
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED   
(  
	[Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  
GO  
  
