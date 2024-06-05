using Microsoft.EntityFrameworkCore;
using Rent_a_car.DAL;
using Rent_a_car.Repos;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//00013374