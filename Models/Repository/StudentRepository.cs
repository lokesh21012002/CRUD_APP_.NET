using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Models.Repository
{
    public static class StudentRepository
    {
        private static List<StuentModel> AuthorList = new List<StuentModel>(){
            new StuentModel {ID=1, Name = "Student 1", Standard=20, Gender="Male",Email = "Student1@gmail.com"},
 new StuentModel {ID=2, Name = "Student 2", Standard=20, Gender="Male",Email = "Student2@gmail.com"},
  new StuentModel {ID=3, Name = "Student 3", Standard=20, Gender="Male",Email = "Student3@gmail.com"},


        };

        public static bool isStudentExist(int id)
        {
            return AuthorList.Any(a => a.ID == id);
        }


        public static StuentModel? getStudentByID(int id)
        {
            return AuthorList.FirstOrDefault(x => x.ID == id);
        }

        public static List<StuentModel>? getAllStudents()
        {
            return AuthorList;
        }

        public static StuentModel? addStudent(StuentModel stuentModel)
        {
            AuthorList.Add(stuentModel);
            return stuentModel;
        }


        public static StuentModel? getStudentByAttribute(string? name, string? email)
        {

            var student = AuthorList.FirstOrDefault(x =>

                 name != null && x.Name == name || email != null && x.Email == email


             );
            return student;




        }





    }
}