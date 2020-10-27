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

       
        
        public void BolumveUniyeGore() { 
            Console.Clear();
            Console.Write("Üniversiteyi Giriniz :");
            string uni = Console.ReadLine();
            string department="";
            Console.WriteLine("Bölümü Seçiniz");
            Console.WriteLine("1- Kimya");
            Console.WriteLine("2- Bilgisayar Bilimleri");
            Console.WriteLine("3- Matematik");
            Console.WriteLine("4- Fizik");
            int num = Convert.ToInt32(Console.ReadLine());
            
            
            switch (num)
            {
                case 1:
                    department = Department.CHEMISTRY.ToString();
                    break;
                case 2:
                    department = Department.COMPUTER_SCIENCE.ToString();
                    break;
                case 3:
                    department = Department.MATHEMATICS.ToString();
                    break;
                case 4:
                    department = Department.PHYSICS.ToString();
                    break;

                default:
                    Console.WriteLine("Hatalı Seçim !");
                    break;
            }
            int sayac = 1;
            bool kontrol = false;
            Console.Clear();
            Console.WriteLine(uni + " Üniversitesinin " + department + " Bölümündeki Tezler :\n");
            for (int i = 0; i < data.Count; i++)
            {
                  if( department == data[i].Department && uni.ToUpper() == data[i].UniversityName.ToUpper()  )
                {
                    Console.WriteLine(sayac+"- "+data[i].ThesisName);
                    sayac++;
                    Console.WriteLine();
                    kontrol = true;
                }
            }
            if (kontrol==false)
            {
                Console.WriteLine("Bulunamadı !");
            }

           
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
                        
                        //Console.WriteLine("{0}- {1}",sayac,data[i].AdvisorName);
                    }
                    
                }

            }

            bool kontrol = false;
            int num = 1;
            for (int i = 0; i < isimler.Count; i++)
            {
                kontrol = false;
                for (int j = 0; j < isimler.Count; j++)
                {
                    if (i==j)
                    {


                    }
                    else {
                        if (isimler[i] == isimler[j])
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
           
        }
        public void DanismanAdinaGoreDenetlenenTez()
        {
            Console.Clear();
            Console.Write("Danışman Adını Girin :");
            string danismanadi = Console.ReadLine();
           
            int sayac = 1;
            for (int i = 0; i < data.Count; i++)
            {
                if (danismanadi == data[i].AdvisorName)
                {
                    Console.WriteLine("{0}- {1} / {2}",sayac,data[i].ThesisName,data[i].ThesisYear);
                    sayac++;
                }


                
            }
          

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
                for (int j = i+1; j < ulkeler.Count; j++)
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
            



        }
        public void DanismanAdiIleCalistigiUniler()
        {
            Console.Clear();
            ArrayList uniler = new ArrayList();
            Console.Write("Danışman Adını Giriniz :");
            string danismanadi = Console.ReadLine();
           
            for (int i = 0; i < data.Count; i++)
            {
                if (danismanadi.ToUpper() == data[i].AdvisorName.ToUpper())
                {
                    uniler.Add(data[i].UniversityName);
                }
                else if (danismanadi.ToUpper() == data[i].StudentName.ToUpper())
                {
                    uniler.Add(data[i].UniversityName);
                }
            }
            Console.Clear();
            Console.WriteLine(danismanadi+" Çalıştığı Üniversiteler");
            bool kontrol = false;
            int sayac = 1;
            for (int i = 0; i < uniler.Count; i++)
            {
                kontrol = false;
                for (int j = i+1; j < uniler.Count; j++)
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
    }
}
