using Application.Intefaces;
using Application.Services;
using DataAccess;
using Domain.InterfaceServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DbConnection")));
builder.Services.AddScoped<ISchoolDbContext, SchoolDbContext>();
builder.Services.AddScoped<ICommandParentService, CommandParentService>();
builder.Services.AddScoped<ICommandStudentService, CommandStudentService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Parent}/{action=GetAll}/{id?}");

app.Run();
