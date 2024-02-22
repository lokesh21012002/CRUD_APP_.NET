using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NET.Db;
using NET.filters;
using NET.Models;
using NET.Models.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;


namespace NET.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]

public class StudentController : ControllerBase
{

    private readonly ApplicationDbContext _db;

    public StudentController(ApplicationDbContext db)
    {
        _db = db;

    }














    [HttpGet("{id}")]
    public IActionResult? getStudentById([FromRoute] int id)
    {



        if (StudentRepository.getStudentByID(id, _db) == null)
        {
            return NotFound("Student not found");

        }

        return Ok(StudentRepository.getStudentByID(id, _db));
    }






    [HttpGet]

    public async Task<ActionResult<IEnumerable<StuentModel>>> GetCSharpCornerArticles()
    {
        return await _db.StuentModels.ToListAsync();

    }
    // public IEnumerable<StuentModel>? GetAll()
    // {
    //     // return StudentRepository.getAllStudents();




    // }
    // [StudentStandardFilter]

    [HttpPost]
    public IActionResult? Addstudent([FromBody] StuentModel stuentModel)
    {

        try
        {

            if (StudentRepository.getStudentByEmail(stuentModel.Email, _db) == null)
            {
                _db.StuentModels.Add(stuentModel);
                _db.SaveChanges();


                return Ok(StudentRepository.getStudentByEmail(stuentModel.Email, _db));


                // return "Success";

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);


        }

        return Ok("stuentModel");



        // var existingStudent = StudentRepository.getStudentByAttribute(stuentModel.Name, stuentModel.Email);
        // if (existingStudent == null)
        // {
        //     StudentRepository.addStudent(stuentModel);
        //     return Ok(stuentModel);
        // }


        // return BadRequest("Already exists student   ");
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
    public async Task<IActionResult> updateStudent(int id, [FromBody] StuentModel stuentModel)
    {

        if (StudentRepository.getStudentByID(stuentModel.ID, _db) == null)
        {
            return NotFound("student not found");
        }




        _db.Entry(stuentModel).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (StudentRepository.getStudentByID(id, _db) == null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();




    }

    [HttpDelete("{id}")]
    [Authorize("Must be Teacher")]



    public async Task<IActionResult> deleteStudent([FromQuery] int id)
    {
        var article = await _db.StuentModels.FindAsync(id);
        if (article == null)
        {
            return NotFound();
        }

        _db.StuentModels.Remove(article);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/api/v1/stduent")]

    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {

        if (!ModelState.IsValid) return BadRequest(new ResponseModel(HttpStatusCode.BadRequest, "Invalid Credentails"));


        var student = await _db.StuentModels.FirstOrDefaultAsync((x) => x.Email == loginDTO.Email);
        var student2 = await _db.StuentModels.FirstOrDefaultAsync((x) => x.Name == loginDTO.Name);

        if (student == null || student2 == null)
        {
            return NotFound(new ResponseModel(HttpStatusCode.NotFound, "Couldn't find student with this email"));



        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,loginDTO.Name),
            new Claim(ClaimTypes.Email,loginDTO.Email),
            new Claim("gmail", "teacher@gmail.com")



    };
        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);








        return Ok(new ResponseModel(HttpStatusCode.OK, "Sucess"));









    }









}




