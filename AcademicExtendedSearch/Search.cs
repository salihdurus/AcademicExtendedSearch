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
            this.setData(data);
        }

        private void setData(List<Datas> _data)
        {
            this.data = _data;
        }
       

        public void Start()
        {
            Console.Clear();
            List list = new List(data);
            list.DataPull();
            Console.WriteLine("Hangi İşlemi Yapmak İstiyorsunuz ?");
            Console.WriteLine("1- Üniversite ve Bölüme Göre Tez Listele");
            Console.WriteLine("2- Hem Öğrenci Hem de Akademisyen Olanları Listele");
            Console.WriteLine("3- Danışman Adı ile Denetlediği Tüm Tezleri Listele");
            Console.WriteLine("4- En Fazla Yayınlanmış Tezin Bulunduğu Ülkeyi Listele");
            Console.WriteLine("5- Danışman Adı İle Çalıştığı Üniversiteleri Listele");
            Console.WriteLine();
            Console.Write("Yapmak İstediğiniz İşlemin Numarasını Giriniz :");
            string num = Console.ReadLine();
            while (num!="1"&&num!="2"&& num != "3" && num != "4" && num != "5" )
            {
                Console.Write("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyin :");
                num = Console.ReadLine();}
            switch (num)
            {
                case "1":
                    list.BolumveUniyeGore();
                    break;
                case "2":
                    list.DanismanveOgrenci();
                    break;
                case "3":
                    list.DanismanAdinaGoreDenetlenenTez();
                    break;
                case "4":
                    list.EnFazlaTezYayinlayanUlke();
                    break;
                case "5":
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
