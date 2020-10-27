using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace AcademicExtendedSearch
{
    class FileOperations
    {
        private List<Datas> datas;
        public FileOperations(List<Datas> datas)
        {
            this.datas = datas;
        }
        
        public void XmlReader()
        {
            
            string Xmldosya = AppDomain.CurrentDomain.BaseDirectory + "genealogy.xml";
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(Xmldosya);

           
            
            XmlNodeList AdvisorNode= xmldocument.SelectNodes("/Genealogy/Advisor/@name");
            XmlNodeList StudentNode= xmldocument.SelectNodes("/Genealogy/Advisor/Student/@name");
            XmlNodeList StudentIdNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/@id");
            XmlNodeList ThesisNameNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/Thesis/@name");
            XmlNodeList ThesisYearNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/Thesis/@year");
            XmlNodeList UniversityNameNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/University/@name");
            XmlNodeList UniversityFoundedYearNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/University/@foundedYear");
            XmlNodeList UniversityCountryNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/University/@country");
            XmlNodeList DepartmentNode = xmldocument.SelectNodes("/Genealogy/Advisor/Student/Department/@name");

           
            for (int i = 0; i < AdvisorNode.Count; i++)
            {
                Datas data = new Datas();
                data.AdvisorName = AdvisorNode[i].Value;
                data.StudentName = StudentNode[i].Value;
                data.StudentId = Convert.ToInt32(StudentIdNode[i].Value);
                data.ThesisName = ThesisNameNode[i].Value;
                data.ThesisYear = Convert.ToInt32(ThesisYearNode[i].Value);
                data.UniversityName = UniversityNameNode[i].Value;
                data.UniversityFoundedYear = Convert.ToInt32(UniversityFoundedYearNode[i].Value);
                data.UniversityCountry = UniversityCountryNode[i].Value;
                
               
                if (DepartmentNode[i].Value == Department.CHEMISTRY.ToString()) data.Department = Department.CHEMISTRY.ToString();
                else if (DepartmentNode[i].Value == Department.COMPUTER_SCIENCE.ToString()) data.Department = Department.COMPUTER_SCIENCE.ToString();
                else if (DepartmentNode[i].Value == Department.MATHEMATICS.ToString()) data.Department = Department.MATHEMATICS.ToString();
                else if (DepartmentNode[i].Value == Department.PHYSICS.ToString()) data.Department = Department.PHYSICS.ToString();

                datas.Add(data);


            }
            
            

        }
    }
}

