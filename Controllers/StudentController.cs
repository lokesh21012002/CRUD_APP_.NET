using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NET.Db;
using NET.filters;
using NET.Models;
using NET.Models.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace NET.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]

public class StudentController : ControllerBase
{

    private readonly DbConn _db;

    public StudentController(DbConn db)
    {
        _db = db;

    }














    [HttpGet("{id}")]
    public IActionResult? getStudentById([FromRoute] int id)
    {



        if (StudentRepository.getStudentByID(id) == null)
        {
            return NotFound("Student not found");

        }

        return Ok(StudentRepository.getStudentByID(id));
    }






    [HttpGet]
    public IEnumerable<StuentModel>? GetAll()
    {
        return StudentRepository.getAllStudents();



    }
    [StudentStandardFilter]

    [HttpPost]
    public IActionResult addstudent([FromBody] StuentModel stuentModel)
    {

        var existingStudent = StudentRepository.getStudentByAttribute(stuentModel.Name, stuentModel.Email);
        if (existingStudent == null)
        {
            StudentRepository.addStudent(stuentModel);
            return Ok(stuentModel);
        }


        return BadRequest("Already exists student   ");
        // Console.WriteLine(stuentModel.Standard);

        // if (StudentRepository.getStudentByID(stuentModel.ID) == null)
        // {
        //     Ok(stuentModel);
        // }


        // return BadRequest("Invalid data");
    }
    // _db.CSharpCornerArticles.Add(stuentModel);
    // _db.SaveChanges();
    // return "Success";



    // Console.WriteLine(ModelState.IsValid);

    // if (ModelState.IsValid)
    // {
    //     return "Success!";

    // }
    // else
    // {
    //     return "Error!";
    // }

    // Console.WriteLine(stuentModel);
    // string tmp=ToString(stuentModel);
    // Console.WriteLine(stuentModel);




    // return "Added";
    // }


    [HttpPut("{id}")]
    [filters.ExceptionFilters.StudentExceptionFilter]
    public IActionResult updateStudent(int id, [FromBody] StuentModel stuentModel)
    {

        try
        {

            if (StudentRepository.getStudentByID(stuentModel.ID) == null)
            {
                return NotFound("student not found");
            }
            return Ok(stuentModel);
        }
        catch
        {
            return BadRequest();
            throw;



        }

        return NoContent();


    }

    [HttpDelete("{id}")]


    public IActionResult deleteStudent([FromQuery] int id)
    {
        if (StudentRepository.getStudentByID(id) == null)
        {
            return NotFound("student not found");
        }
        return Ok("Deleted successfully");
    }









}




