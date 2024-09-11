
# MultiShop - E-Ticaret (Microservice)
MultiShop projesi, kullanıcıların oturum açarak veya ziyaretçi olarak siteye giriş yapmalarını sağlayan, kapsamlı bir e-ticaret platformudur. 
Kullanıcılar, ürünler içerisinden diledikleri ürünleri arayabilir, listeleyebilir ve sepetlerine ekleyebilirler. 
Alışveriş sürecinin sonunda, kullanıcılar siparişlerini güvenle oluşturabilirler. Oluşturdukları siparişleri kullanıcı panelinden takip edebilirler.
Bu projede, kullanıcı arayüzü ve admin paneli ile öne çıkıyor.

# Mikroservs Medir?
Mikroservis; büyük ve karmaşık uygulamaların, daha küçük ve bağımsız hizmetlere (servislere) bölünerek geliştirildiği bir yazılım mimari yaklaşımıdır. 
Her mikroservis, belirli bir işlevi yerine getiren bağımsız bir birim olarak çalışır ve diğer mikroservislerle iletişim kurarak, tüm sistemi oluşturur.
Bu yapı, uygulamanın ölçeklenebilirliğini, esnekliğini ve bakımı kolaylaştırır.

# Projeye Genel Bakış
🖱️ Admin Paneli: CRUD işlemlerini gerçekleştiren admin paneli, ana sayfadaki ürünlerin, kategorilerin ve markaların eklenmesi,
güncellenmesi ve silinmesi gibi işlemler için kapsamlı bir yönetim alanı sunar. Ayrıca, sepet yönetimi, sipariş takibi ve kullanıcı yönetimi
gibi önemli işlevler için ideal bir ortam sağlar. RabbitMQ entegrasyonu ile ürün güncellemeleri anında sepet içerisindeki ilgili bileşenlere iletilir.

👤 Kullanıcı Arayüzü: Kullanıcılar için modern ve dinamik bir tasarıma sahip bu arayüz, ürün arama, listeleme, 
sepete ekleme ve sipariş oluşturma süreçlerini kolaylaştırır. Ürün detayları görüntülenebilir, sepet yönetimi yapılabilir ve
siparişler takip edilebilir. Localization desteği ile farklı dillerde içerik sunma imkanı sağlanmıştır.

🧑‍💻 Kullanıcı Paneli: Kullanıcılar siparişlerini görebilir, admin ile mesajlaşabilir ve çeşitli işlemleri gerçekleştirebilirler.

# Teknolojik Yapı
ASP.NET Core 6.0 ile geliştirdiğim proje, mikroservis yapısı ve çeşitli modern teknolojiler kullanılarak inşa edilmiştir.
Proje, N katmanlı ve Onion mimarileriyle yapılandırılmış mikroservisleri içerir ve Repository, CQRS ve Mediator desenleri uygulanmıştır.
Güvenlik için Identity Service ve JWT kullanılmıştır. Veritabanı yönetimi Docker ile sağlanmış olup, MSSQL, MongoDB, Redis ve PostgreSQL veritabanları kullanılmıştır. 
Swagger API dokümantasyonu, Postman ise testler için tercih edilmiştir. API yönlendirmesi Ocelot Gateway ile sağlanmaktadır. 
RabbitMQ kullanılarak ürün güncellendiğinde, eğer sepet içinde varsa bu ürüne dair güncelleme bilgisi ilgili bileşenlere iletilmektedir. 
Localization kullanılarak dil desteği sağlanmış ve kullanıcıların tercihine göre farklı dillerde içerik sunulmuştur. RapidAPI çeşitli verilerin çekilmesinde kullanılmıştır.



# Kullanılan Teknolojiler
- 🤖 **Asp.Net Core 6.0 Web App**
- 🌐 **Asp.Net Web API**
- 🗃️ **MSSQL**
- 🗃️ **MongoDb**
- 🗃️ **Redis**
- 🗃️ **PostgreSQL**
- 🐳 **Docker**
- 🖥️ **DBeaver**
- 💾 **Dapper**
- 🛠️ **Postman**
- 📝 **Swagger**
- 📦 **RabbitMQ**
- 🚀 **RapidApi**
- ☁️ **Google Cloud Storage**
- 🏛️ **Onion Architecture**
- 📜 **CQRS Design Pattern**
- 🎛️ **Mediator Design Pattern**
- 🗃️ **Repository Design Pattern**
- 🔒 **IdentityServer4**
- 🌀 **Ocelot Gateway**
- 🔄 **SignalR**
- 🪙 **Json Web Token**
- 📧 **MailKit**
- ✅ **FluentValidation**
- 🌐 **Html**
- 🎨 **Css**
- 💻 **JavaScript**
- 🧩 **Bootstrap**

# Frontend
- 🌐 **Html**
- 🎨 **Css**
- 💻 **JavaScript**
- 🧩 **Bootstrap**

# Backend
- 💻 **C#**
- 🗃️ **MSSQL**
- 📝 **Swagger**
- 🐳 **Docker**
- 🗃️ **PostgreSQL**
- 🗃️ **MongoDB**
- 🖥️ **DBeaver**

# Mikroservisler ve Veritabanları
- 🛒 **Basket** - 🐳 Redis
- 📦 **Cargo** - 🐳 MSSQL
- 🗃️ **Catalog** - MongoDb
- 💬 **Comment** - 🐳 MSSQL
- 💸 **Discount** - Local MSSQL Dapper
- 🖼️ **Images** - Local SQL
- 📩 **Message** - PostgreSQL
- 📦 **Order** - 🐳 MSSQL
- 🔒 **IdentityServer4** - 🐳 MSSQL
- 💳 **Payment** - RabbitMQ
- 🔄 **SignalR**
- 🚀 **RapidApi**

# Teknik Özellikler
- 🔐 **Ziyaretçi veya Kullanıcı Girişi** - IdentityServer4
- 🤖 **Asp.Net Core 6.0**
- 🌐 **Asp.Net Core Web API**
- 🏛️ **Onion Architecture**
- 🏗️ **N-Tier Architecture**
- 🏢 **One-Tier Architecture**
- 📜 **CQRS, Mediator, Repository Design Pattern**
- 🗃️ **Entity Framework Code First LINQ**
- 💾 **Dapper**
- 🔄 **SignalR ile canlı veri takibi**
- 🗃️ **Redis ile sepete ekleme**
- 🐳 **Docker MSSQL ile yorum yapma**
- 🗃️ **MongoDB ile catalog mikroservisi consume**
- 🛠️ **Admin Paneli**
- 🧑‍💻 **Kullanıcı Paneli**
- ☁️ **Google Cloud Storage ile ürün görselleri**



  #Layout
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/feature.jpeg)
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/%C3%B6ne%C3%A7%C4%B1kanlar.jpeg)
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/footermarkalar.jpeg)
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/%C3%BCr%C3%BCndetay%C4%B1almanca.jpeg)
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/yorum1.jpeg)
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/sepetim.jpeg)
   ![d](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/ileti%C5%9Fim.jpeg)

 
    ![A](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/%C3%B6deme.jpeg)
    ![A](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/screenshot-1726079238318.png)

  #Layout
  
    ![A](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/%C3%BCr%C3%BCnlistesi.jpeg)
    ![A](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/istatislik.jpeg)
    ![A](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/googlecloud%20resiim.jpeg)
    ![A](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/googlecloud.png)
   
 
  ![lOGİN](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/sipari%C5%9Fler.jpeg)
  ![lOGİN](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/pro.png)
  ![lOGİN](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/rabbit.png)
  ![lOGİN](https://github.com/busenurdmb/MultiShop/blob/master/Frontends/MultiShop.WebUI/wwwroot/images/proje/rabbit1.png)
