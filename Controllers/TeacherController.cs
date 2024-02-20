using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NET.Controllers

{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TeacherController : ControllerBase
    {

        [HttpGet]

        public string getAllTeachers()
        {
            return "All teachers";

        }


    }
}