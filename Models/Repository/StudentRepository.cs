using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Db;

namespace NET.Models.Repository
{
    public static class StudentRepository
    {













        //         private static List<StuentModel> AuthorList = new List<StuentModel>(){
        //             new StuentModel {ID=1, Name = "Student 1", Standard=20, Gender="Male",Email = "Student1@gmail.com"},
        //  new StuentModel {ID=2, Name = "Student 2", Standard=20, Gender="Male",Email = "Student2@gmail.com"},
        //   new StuentModel {ID=3, Name = "Student 3", Standard=20, Gender="Male",Email = "Student3@gmail.com"},


        //         };

        public static bool IsStudentExist(int id, ApplicationDbContext _db)
        {
            var x = _db.StuentModels.ToList();

            // x.Any




            return x.Any(a => a.ID == id);
        }
        public static bool IsStudentExist(int id)
        {

            return true;
            // var x = _db.StuentModels.ToList();

            // // x.Any




            // return x.Any(a => a.ID == id);
        }


        public static StuentModel? getStudentByEmail(string email, ApplicationDbContext _db)
        {
            var x = _db.StuentModels.ToList();

            return x.FirstOrDefault(x => x.Email.Equals(email));


        }

        public static StuentModel? getStudentByID(int id, ApplicationDbContext _db)
        {
            var x = _db.StuentModels.ToList();

            return x.FirstOrDefault(x => x.ID == id);
        }

        public static List<StuentModel>? getAllStudents(ApplicationDbContext _db)
        {
            var x = _db.StuentModels.ToList();

            return x;
        }

        public static StuentModel? addStudent(StuentModel stuentModel, ApplicationDbContext _db)
        {

            _db.StuentModels.Add(stuentModel);
            _db.SaveChanges();

            return stuentModel;


            // AuthorList.Add(stuentModel);
            // return stuentModel;
        }


        public static StuentModel? getStudentByAttribute(string? name, string? email, ApplicationDbContext _db)
        {
            var x = _db.StuentModels.ToList();



            var student = x.FirstOrDefault(x =>

                 name != null && x.Name == name || email != null && x.Email == email


             );
            return student;




        }





    }
}