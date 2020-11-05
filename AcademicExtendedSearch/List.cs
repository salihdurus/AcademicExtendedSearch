using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademicExtendedSearch
{
    class List
    {
        private List<Datas> data;
        public List(List<Datas> data)
        {
            this.data = data;
        }
        public void DataPull() {
           
            FileOperations fileOperations = new FileOperations(data);
            fileOperations.XmlReader();
        }

        void Menu()
        {
            Program.Main();
        }
        
        public void BolumveUniyeGore() { 
            Console.Clear();
            Console.WriteLine("Kayıtlı Üniversiteler \n");
            ArrayList univ = new ArrayList();
            bool k = false;
            for (int i = 0; i < data.Count; i++)
            {
                k = false;
                for (int j = i; j < data.Count; j++)
                {
                    if (i == j)
                    {

                        continue;
                    }
                    else
                    {
                        if (data[i].UniversityName == data[j].UniversityName)
                        {
                            k = true;

                        }
                    }


                }
                if (k == false)
                {
                    univ.Add(data[i].UniversityName);
                }

            }
            for (int i = 0; i < univ.Count; i++)
            {
                Console.WriteLine("{0}-{1}", i + 1, univ[i]);
            }
            Console.WriteLine();
            string[] unil = new string[data.Count];

            try
            {
                Console.Write("Üniversite Numarasını Giriniz :");
                int uni = Convert.ToInt32(Console.ReadLine());
                string department = "";
                if (uni < 0 || uni > univ.Count)
                {
                    Console.WriteLine("Hatalı Giriş Yaptınız.");
                    Console.ReadLine();
                    BolumveUniyeGore();
                }
                else
                {
                    Console.WriteLine("Bölümü Seçiniz");
                    Console.WriteLine("1- Kimya");
                    Console.WriteLine("2- Bilgisayar Bilimleri");
                    Console.WriteLine("3- Matematik");
                    Console.WriteLine("4- Fizik");
                    string num = Console.ReadLine();
                    while (num != "1" && num != "2" && num != "3" && num != "4")
                    {
                        Console.Write("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyin :");
                        num = Console.ReadLine();
                    }

                    switch (num)
                    {
                        case "1":
                            department = Department.CHEMISTRY.ToString();
                            break;
                        case "2":
                            department = Department.COMPUTER_SCIENCE.ToString();
                            break;
                        case "3":
                            department = Department.MATHEMATICS.ToString();
                            break;
                        case "4":
                            department = Department.PHYSICS.ToString();
                            break;
                        default:
                            Console.WriteLine("Hatalı Seçim !");
                            break;
                    }
                    int sayac = 1;
                    bool kontrol = false;
                    Console.Clear();
                    Console.WriteLine(univ[uni - 1].ToString() + " " + department + " Bölümündeki Tezler :\n");
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (department == data[i].Department && univ[uni - 1].ToString() == data[i].UniversityName)
                        {
                            Console.WriteLine(sayac + "- " + data[i].ThesisName);
                            sayac++;
                            Console.WriteLine();
                            kontrol = true;
                        }
                    }
                    if (kontrol == false)
                    {
                        Console.WriteLine("Bulunamadı !");
                    }
                    Console.Read();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Yaptınız");
                Console.ReadLine();
                BolumveUniyeGore();
            }
            Console.Read();
            Menu();
        }
        public void DanismanveOgrenci()
        {
            Console.Clear();
            int sayac = 0;
            ArrayList isimler = new ArrayList();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    if (data[i].AdvisorName == data[j].StudentName)
                    {
                        isimler.Add(data[i].AdvisorName);
                        sayac++;
                    }
                }
            }
            bool kontrol = false;
            int num = 1;
            for (int i = 0; i < isimler.Count; i++)
            {
                kontrol = false;
                for (int j = i; j < isimler.Count; j++)//
                {
                    if (i==j)
                    {
                        continue;
                    }
                    else {
                        if (isimler[i].ToString() == isimler[j].ToString())
                        {
                            kontrol = true;
                        }
                    }
                }
                if (kontrol == false)
                {
                    Console.WriteLine(num+"- "+isimler[i]);
                    num++;
                }
            }
            Console.ReadLine();
            Menu();
        }
        public void DanismanAdinaGoreDenetlenenTez()
        {
            Console.Clear();
            try
            {
                ArrayList danisman = new ArrayList();
                bool k = false;
                for (int i = 0; i < data.Count; i++)
                {
                    k = false;
                    for (int j = i; j < data.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        else
                        {
                            if (data[i].AdvisorName == data[j].AdvisorName)
                            {
                                k = true;
                            }
                        }

                    }
                    if (k == false)
                    {
                        danisman.Add(data[i].AdvisorName);
                    }
                }
                ArrayList kronoloji = new ArrayList();
              
                Console.WriteLine("Kayıtlı Danışmanlar \n");
                for (int i = 0; i < danisman.Count; i++)
                {
                    Console.WriteLine("{0}-{1}", i + 1, danisman[i]);
                }
                Console.WriteLine();
                Console.Write("Danışman Numarasını Girin :");
                int danismanadi = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("{0} Denetlediği Tezler",danisman[danismanadi - 1]);
                Console.WriteLine();
                int sayac = 1;
                for (int i = 0; i < data.Count; i++)
                {
                    if (danisman[danismanadi - 1].ToString() == data[i].AdvisorName)
                    {
                        kronoloji.Add(data[i].ThesisYear+" / "+data[i].ThesisName);
                    }
                }
                kronoloji.Sort();

                for (int i = 0; i < kronoloji.Count; i++)
                {
                    
                    Console.WriteLine("{0}- {1}", sayac, kronoloji[i]);
                    sayac++;
                }
              
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyin ");
                Console.ReadLine();
                DanismanAdinaGoreDenetlenenTez();
            }
            Console.ReadLine();
            Menu();
        }
        public void EnFazlaTezYayinlayanUlke()
        {
            Console.Clear();
            ArrayList ulkeler = new ArrayList();
            ArrayList tekrarsizulke = new ArrayList();
            for (int i = 0; i < data.Count; i++)
            {
                ulkeler.Add(data[i].UniversityCountry);
            }
            for (int i = 0; i < ulkeler.Count; i++)
            {
                bool kontrol = false;
                for (int j = i + 1; j < ulkeler.Count; j++)
                {
                        if (ulkeler[i].ToString() == ulkeler[j].ToString() )
                        {
                            kontrol = true;
                        }
                }
                if (kontrol == false)
                {
                    tekrarsizulke.Add(ulkeler[i]);
                }
            }
            int[] sayilar = new int[tekrarsizulke.Count];
            for (int i = 0; i < tekrarsizulke.Count; i++)
            {
                int sayac = 0;
                for (int j = 0; j < ulkeler.Count; j++)
                {
                    if (tekrarsizulke[i].ToString() == ulkeler[j].ToString()){
                        sayac++;
                    }
                }
                sayilar[i] = sayac;
            }
            int enBuyukSayi = Int32.MinValue;
            int enBuyukIndex = Int32.MinValue;
            for (int i = 0; i < sayilar.Length; i++)
            {
                if (sayilar[i] > enBuyukSayi)
                {
                    enBuyukSayi = sayilar[i];
                    enBuyukIndex = i;
                }
            }
            Console.WriteLine("En Fazla Tez Yayınlayan Ülke {0} Tez ile {1}",enBuyukSayi,tekrarsizulke[enBuyukIndex]);
            Console.ReadLine();
            Menu();
        }
        public void DanismanAdiIleCalistigiUniler()
        {
            Console.Clear();
            try
            {
                ArrayList danisman = new ArrayList();
                bool k = false;
                for (int i = 0; i < data.Count; i++)
                {
                    k = false;
                    for (int j = i; j < data.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        else
                        {
                            if (data[i].AdvisorName == data[j].AdvisorName)
                            {
                                k = true;

                            }
                        }
                    }
                    if (k == false)
                    {
                        danisman.Add(data[i].AdvisorName);
                    }
                }
                Console.WriteLine("Kayıtlı Danışmanlar \n");
                for (int i = 0; i < danisman.Count; i++)
                {
                    Console.WriteLine("{0}-{1}", i + 1, danisman[i]);
                }
                ArrayList uniler = new ArrayList();
                Console.WriteLine();
                Console.Write("Danışman Numarasını Giriniz :");
                int danismanadi = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < data.Count; i++)
                {
                    if (danisman[danismanadi - 1].ToString() == data[i].AdvisorName)
                    {
                        uniler.Add(data[i].UniversityName);
                    }
                    else if (danisman[danismanadi - 1].ToString() == data[i].StudentName)
                    {
                        uniler.Add(data[i].UniversityName);
                    }
                }
                Console.Clear();
                Console.WriteLine(danisman[danismanadi-1] + " Çalıştığı Üniversiteler");
                bool kontrol = false;
                int sayac = 1;
                for (int i = 0; i < uniler.Count; i++)
                {
                    kontrol = false;
                    for (int j = i + 1; j < uniler.Count; j++)
                    {
                        if (uniler[i].ToString() == uniler[j].ToString())
                        {
                            kontrol = true;

                        }
                    }
                    if (kontrol == false)
                    {
                        Console.WriteLine(sayac + "- " + uniler[i]);
                        sayac++;
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Deneyin.");
                Console.ReadLine();
                DanismanAdiIleCalistigiUniler();
            }
            Console.ReadLine();
            Menu();
        }
    }
}
