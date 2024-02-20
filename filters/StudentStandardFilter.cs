using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NET.Models.Repository;

namespace NET.filters
{
    public class StudentStandardFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            Console.WriteLine(context.ActionArguments["id"]);
            var standard2 = context.ActionArguments["id"] as int?;
            if (standard2.HasValue)
            {
                if (standard2.Value <= 0)
                {

                    context.ModelState.AddModelError("Standard", " Invalid StudentStandard ");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };



                    // context.Result = new BadRequestObjectResult("Invalid Student");
                    context.Result = new BadRequestObjectResult(problemDetails);

                }

                else
                {

                    context.Result = new OkObjectResult("Valid student");

                }
            }
        }


    }
}