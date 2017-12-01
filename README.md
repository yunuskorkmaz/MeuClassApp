# Mersin Üniversitesi Sosyal Paylaşım Sistemi
Mersin Üniversitesi öğrenci ve öğretmen sosyal paylaşım platformu.

### Bağımlılıklar
* DataAccess ve MeuClass katlanları içinde ki  **packages.config** dosyaları içinde ki paketlerin **nuget** paket yöneticisinden yüklenmesi gerekir.
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
