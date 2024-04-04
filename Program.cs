using Microsoft.EntityFrameworkCore;
using TravelWeb.Data;
using TravelWeb.Repository;
using TravelWeb.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using TravelWeb.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container, nasa aplikacija koristi kontrolere
// Dependency injection ide ovde
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnit,Unit>();
builder.Services.ConfigureApplicationCookie(options => {
options.LoginPath = $"/Identity/Account/Login";
options.LogoutPath = $"/Identity/Account/Logout";
options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
//builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication(); //da li je user name i pass dobar
app.UseAuthorization(); //u odnosu na autorizaciju nije isti pristup za sve korsinike
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
// kakva je ruta, ako nije action definisano onda je ovo ruta, ? znaci da moze  biti definisana i ne mora

app.Run();
//pokrece aplikaciju
