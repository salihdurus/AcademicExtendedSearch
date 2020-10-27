using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicExtendedSearch
{
    class Datas
    {
        private string advisorName;
        private string studentName;
        private int studentId;
        private string thesisName;
        private int thesisYear;
        private string universityName;
        private int universityFoundedYear;
        private string universityCountry;
        private string department;

        public string AdvisorName { get => advisorName; set => advisorName = value; }
        public string StudentName { get => studentName; set => studentName = value; }
        public int StudentId { get => studentId; set => studentId = value; }
        public string ThesisName { get => thesisName; set => thesisName = value; }
        public int ThesisYear { get => thesisYear; set => thesisYear = value; }
        public string UniversityName { get => universityName; set => universityName = value; }
        public int UniversityFoundedYear { get => universityFoundedYear; set => universityFoundedYear = value; }
        public string UniversityCountry { get => universityCountry; set => universityCountry = value; }
        public string Department { get => department; set => department = value; }
    }
}
