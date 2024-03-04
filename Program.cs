var builder = WebApplication.CreateBuilder(args);

// Add services to the container, nasa aplikacija koristi kontrolere
// Dependency injection ide ovde
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// kakva je ruta, ako nije nista definisano onda je ovo ruta, ? znaci da moze  biti definisana i ne mora

app.Run();
//pokrece aplikaciju
