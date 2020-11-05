using System;
using System.Collections.Generic;
using System.Xml;

namespace AcademicExtendedSearch
{
    class Program
    {
        public static void Main()
        {
            List<Datas> datas = new List<Datas>(); 
            Search search = new Search(datas);
            search.Start();
        }
    }
}
