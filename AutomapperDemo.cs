using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace demo
{


    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Employee, EmployeeDTO>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }


    class EmployeeDTO
    {

        public string Name { get; set; }
        public int Salary { get; set; }

        public string Department { get; set; }


        public override string ToString()
        {
            return $"{Name} + {Salary} + {Department}";

        }



        public EmployeeDTO(string name, int salary, string department)
        {
            Name = name; Salary = salary; Department = department;

        }






    }
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public string Department { get; set; }

        public Employee(string name, int salary, string department)
        {
            Name = name; Salary = salary; Department = department;


        }










    }

    // class MainClass
    // {
    //     public static void Main(string[] args)
    //     {
    //         Employee emp = new Employee("Lokesh", 200, "IT");
    //         EmployeeDTO employeeDTO = new EmployeeDTO("lokesh", 200, "it");
    //         Console.WriteLine($"Employee Name :{emp.Name},Salary:{emp.Salary},Department: {emp.Department}");


    //         var mapper = MapperConfig.InitializeAutomapper();

    //         var dto2 = mapper.Map<EmployeeDTO>(emp);



    //         Console.WriteLine(dto2);










    //     }
    // }

}