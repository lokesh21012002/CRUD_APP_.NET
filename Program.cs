
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using NET.Db;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";



});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Must be Teaccher", policy =>
    {
        policy.RequireClaim("gmail", "teacher@gmail.com");


    });
});
// builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("DefaultConnection")!);



builder.Services.AddEntityFrameworkMySql()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();





// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// });

// app.MapGet("/get/{id}", (int id) =>
// {


//     Dictionary<string, string> My_dict1 =
//                        new Dictionary<string, string>();
//     My_dict1.Add("msg", "Hello");
//     My_dict1.Add("type", id.ToString());


//     return My_dict1;



// });



// app.MapPost("/add", (string type) =>
// {
//     return $"{type} created";
// });

// app.MapPut("/update/{id}", (int id) =>
// {

//     return $"{id} updated";

// });


// app.MapDelete("/delete/{id}", (int id) =>
// {
//     return $"{id} deleted";
// })



// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }


