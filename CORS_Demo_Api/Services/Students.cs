using CORS_Demo_Api.Model;

namespace CORS_Demo_Api.Services
{
    public class Students
    {
        private List<StudentsViewModel> ListStudents = new List<StudentsViewModel>(){new StudentsViewModel { Id = 1, Name = "Sanjay Singh", Address = "Noida", Age = 300 },
                             new StudentsViewModel { Id = 2, Name = "Rahul Singh", Address = "Gujrat", Age = 300 },
                             new StudentsViewModel { Id = 3, Name = "Raj Singh", Address = "Delgi", Age = 300 },
                             new StudentsViewModel { Id = 4, Name = "Praddep Singh", Address = "Mathura", Age = 300 },
                             new StudentsViewModel { Id = 5, Name = "Shiva Singh", Address = "Bulandshahr", Age = 300 }
        };
       

      
        public List<StudentsViewModel> GetStudents()
        {
            return ListStudents;

        }
        public Boolean PostStudents(StudentsViewModel students)
        {
            if (students == null)
            {
                return false;
            }
            else
            {
                ListStudents.Add(students);
                return true;
            }
        }

    }
}
