using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicExtendedSearch
{
    class Search
    {
        private List<Datas> data;
        public Search(List<Datas> data)
        {
            this.data = data;
        }
       

        public void Start()
        {
            List list = new List(data);
            list.DataPull();
            Console.WriteLine("Hangi İşlemi Yapmak İstiyorsunuz ?");
            Console.WriteLine("1- Üniversite ve Bölüme Göre Tez Listele");
            Console.WriteLine("2- Hem Öğrenci Hem de Akademisyen Olanları Listele");
            Console.WriteLine("3- Danışman Adı ile Denetlediği Tüm Tezleri Listele");
            Console.WriteLine("4- En Fazla Yayınlanmış Tezin Bulunduğu Ülkeyi Listele");
            Console.WriteLine("5- Danışman Adı İle Çalıştığı Üniversiteleri Listele");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    list.BolumveUniyeGore();
                    break;
                case 2:
                    list.DanismanveOgrenci();
                    break;
                case 3:
                    list.DanismanAdinaGoreDenetlenenTez();
                    break;
                case 4:
                    list.EnFazlaTezYayinlayanUlke();
                    break;
                case 5:
                    list.DanismanAdiIleCalistigiUniler();
                    break;
                default:
                    Console.WriteLine("Hatalı Seçim");
                    break;
            }
            Console.Read();
            
        }
    }
}
