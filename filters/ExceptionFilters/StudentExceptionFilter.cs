using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NET.Models.Repository;

namespace NET.filters.ExceptionFilters
{
    public class StudentExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var studentId = context.RouteData.Values["id"].ToString();
            if (int.TryParse(studentId, out int id))
            {
                if (!StudentRepository.IsStudentExist(id))
                {
                    context.ModelState.AddModelError("id", "Student not found");
                    var problemobj = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };

                    context.Result = new NotFoundObjectResult(problemobj);





                }

            }



        }



    }
}