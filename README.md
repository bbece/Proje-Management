
Windows form uygulaması üzerinde bir proje yönetim sistemi geliştirilmesi beklenmektedir. Proje yönetim sistemi üzerinde projelerin tanımlanması ve yürütülmesi yapılacaktır. Proje yönetim sistemini geliştirirken aşağıda verilen temel gereksinimleri yerine getirmeniz ve bu gereksinimleri zenginleştirmeniz beklenmektedir. Geliştirilecek uygulama bir veya birden fazla form sayfası bulundurabilir.

Temel Gereksinimler :

•	Proje adında temel bir sınıf olmalı ve bu proje sınıfında bulunması gerekenler.
o	Proje Adı, Stratejik Etkisi (string)
o	Proje No (bu otomatik olarak PRJ ön eki eklenerek oluşturulacaktır.)
o	Proje Yürütücüsü (Başka bir kişi sınıfından olmalı)
o	Amaç, Problem Tanımı, Kapsam (string)
o	Kayıt Tarihi, Proje Başlangıcı, Proje Bitişi, Tahmini Başlangıç ve Bitiş(Datetime)
o	Proje Durumu (Başka bir sınıf olmalı – Onay Bekliyor,Devam Ediyor, Tamamlandı, vb durumlar)
o	Parasal Getirisi(numeric)
o	Parasal Getiri Tipi(Günlük, Aylık, Yıllık) 
o	Proje Ekibi(Bir veya birden fazla kişi)
o	Proje Dokümanları(word,pdf,excel,vb. Doküman ekleme)(bir veya birden Fazla)
o	Proje Tipi(Ayrı bir yerden sınıf ya da enum)(Örn. Yurtdışı,Tübitak,Kobi,vb.)
o	Proje Kilometre Taşları ve Görevler
	Her projede 1-n sayıda kilometre taşı olabilir.
	Her kilometre taşında 1-n sayıda görev olabilir.
	Proje-Kilometre Taşı-Görev yapısı treeview olarak gösterilecektir.
![resim](https://github.com/bbece/Proje-Management/assets/85908221/d72c3b7c-9f57-49ea-93f6-e4f14c85ff04)
