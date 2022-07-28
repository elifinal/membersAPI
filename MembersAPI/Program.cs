global using Microsoft.EntityFrameworkCore;
using MembersDataAccess.Abstract;
using MembersDataAccess.Concrete;
using MembersDataAccess.Data;
using MembersService.Abstract;
using MembersService.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
// builder.Services.AddTransient<IEmailRepository, EmailRepository>();

#endregion

#region services
builder.Services.AddScoped<IMemberService, MemberService>();
//builder.Services.AddScoped<IEmailService, EmailService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
