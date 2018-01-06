# Mersin Üniversitesi Sosyal Paylaşım Sistemi
Mersin Üniversitesi öğrenci ve öğretmen sosyal paylaşım platformu.

[![Build status](https://ci.appveyor.com/api/projects/status/cyl9cynl0s6r649q/branch/master?svg=true)](https://ci.appveyor.com/project/yunuskorkmaz/meuclassapp/branch/master)

### Proje Mimarisi

| Proje Katmanı        | Açıklama|
|-------------         |:-------------|
|   MeuClass.Business  |Proje arayüzü ile veritabanı arasında iletişim ve verilerin yönetildiği katmandır.  |
|   MeuClass.Data      |Veritabanına erişim için gerekli olan DbContext sıfınını içerir. |
|   MeuClass.Entity    |Veritabanı tablolarının model sınıflarını içeirir.  |
|   MeuClass           |Projenin arayüz katmanıdır. ASP.NET MVC |


### Bağımlılıklar
* MeuClass.Business, MeuClass.Data, MeuClass.Entity ve MeuClass katmanları içinde ki  **packages.config** dosyaları içinde ki paketlerin **nuget** paket yöneticisinden yüklenmesi gerekir.
*  **SASS** dosyaları **gulp.js** ile derlenmektedir. **gulp.js** çalıştırılması için **MeuClass** dizini içinde terminal'e
``` sh
npm install
```
Sonrasında
``` sh
gulp
```
Komutlarını çalıştırabilirsiniz.

 Proje http://localhost:3000 adresinde gulp.js ile http://localhost:55007 adresinde IISExpress ile Debug modunda çalışacak şekilde ayarlandı.
