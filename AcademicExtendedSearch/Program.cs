using System;
using System.Collections.Generic;
using System.Xml;

namespace AcademicExtendedSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Datas> datas = new List<Datas>();
            List list = new List(datas);
            Search search = new Search(datas);
            search.Start();
        }
    }
}
