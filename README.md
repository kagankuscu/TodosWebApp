# TodosWebApp
**Özet**

Bu proje, ASP.NET Core MVC kullanarak bir yapılacaklar listesi uygulaması oluşturmak için tasarlanmıştır. Uygulama, kullanıcıların yapılacaklar listesi oluşturmalarına, bunları yönetmelerine ve görevleri tamamladıklarında bunları işaretlemelerine olanak tanır.

**Hedef kitle**

Bu proje, ASP.NET Core MVC ile yeni başlayanlar için tasarlanmıştır. Proje, ASP.NET Core MVC'nin temellerini öğrenmek ve pratik yapmak için bir fırsat sunar.

**Temel özellikler**

-   Kullanıcılar, yapılacaklar listesi oluşturabilir, bunları düzenleyebilir ve silebilir.
-   Kullanıcılar, görevleri tamamladıklarında bunları işaretleyebilir.
-   Adminler, kullanıcıları görüntüleyebilir, güncelleyebilir ve silebilir.
-   Adminler, etiketler ve öncelikler ekleyebilir.

**N-Layer architecture**

Bu proje, N-Layer architecture kullanılarak oluşturulmuştur. Bu mimari, uygulamayı daha kolay anlaşılır ve yönetilebilir hale getiren, farklı katmanlara ayrılmış bir yapıdır.

**Kullanılan teknolojiler**

Bu proje, aşağıdaki teknolojileri kullanmaktadır:

-   .NET 8
-   ASP.NET MVC Core
-   C# Programlama dili
-   Entity Framework Core (EF-core)
-   MSSQL Veri Tabani
-   HTML, CSS3, Javascript, JQuery
-   Bootstrap
-   Parsley.js
-   DataTable
-   Sweet Alert

**Kurulum**

Projeyi kurmak için aşağıdaki adımları takip edin:

1.  Visual Studio 2022 veya üzerini açın.
2.  "Yeni Proje"ye tıklayın.
3.  "ASP.NET Core Web Uygulaması"nı seçin.
4.  "Uygulama adını" girin.
5.  "Çözüm konumunu" seçin.
6.  "Oluştur"a tıklayın.

Proje oluşturulduktan sonra, aşağıdaki adımları takip ederek projeyi çalıştırın:

1.  Projeye sağ tıklayın.
2.  "Çalıştır"a tıklayın.

**Kullanım**

Uygulamayı kullanmak için aşağıdaki adımları takip edin:

1.  Uygulamayı çalıştırın.
2.  "Giriş" sayfasına gidin.
3.  "Kullanıcı adı" ve "Şifre" alanlarını doldurun.
4.  "Giriş"e tıklayın.

Giriş yaptıktan sonra, "Yapılacaklar Listesi" sayfasına yönlendirileceksiniz. Bu sayfadan, yapılacaklar listenizi oluşturabilir, düzenleyebilir ve silebilirsiniz.

Bir görev oluşturmak için, "Yeni Görev" düğmesine tıklayın. Görevin "Başlık" ve "Açıklama" alanlarını doldurun. İsterseniz, "Öncelik" ve "Etiket" seçeneklerini de kullanabilirsiniz.

Bir görevi tamamlamak için, görevin yanındaki kutuyu işaretleyin.

**Ek bilgiler**

Bu proje, MIT lisansı altında dağıtılmaktadır.

N-Layer architecture, uygulamayı aşağıdaki katmanlara ayırır:

-   **Presentation layer** (Sunum katmanı): Kullanıcı arayüzü ile ilgili kodları içerir.
-   **Application layer** (Uygulama katmanı): Uygulamanın iş mantığını içerir.
-   **Data access layer** (Veri erişim katmanı): Veritabanı ile ilgili kodları içerir.
-   **Model layer** (Model katmanı): Uygulamanın veri modellerini içerir.
-   **DTO layer** (Data Transfer Object katmanı): Veri transferi için kullanılan modelleri içerir.

Bu projede, sunum katmanı ASP.NET Core MVC kullanılarak oluşturulmuştur. Uygulama katmanı, kullanıcıların yapılacaklar listesini oluşturmasına, yönetmesine ve görevleri tamamlamasına olanak tanıyan kodları içerir. Veri erişim katmanı, veritabanı ile ilgili kodları içerir.

**Uygulamadan Resimler**

**Login**

![Login](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/Login.png)
![Register](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/Register.png)

---

**Admin Paneli**

![AdminPanel](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/AdminPanel.png)
![AdminPriorityPanel](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/AdminPriority.png)
![AdminTagPanel](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/AdminTags.png)

---

**Ana Sayfa**

![MainPage](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/MainPage.png)
![Upcoming](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/Upcoming.png)
![History](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/History.png)

---

**Drop List**

![Priorities](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/Priorities.png)
![Tags](https://github.com/kagankuscu/TodosWebApp/blob/ReadmeFile/Images/Tags.png)