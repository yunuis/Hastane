using Hastanevs.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HastaneDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/*GetConnectionString ile connectionlarý yani baðlantýlarýmýzý aldýk.
appsettingsjsonda böyle kullanmamýz istendiðinden böyle yaptýk.
asp.net mekanizmasýna dedik ki oluþturduðumuz hastanedbcontext dosyasýný kullan,bu köprü dosyasýný oluþtururken
sql server kullan. bu sql serveri kullanýrken de defaultconnection'ý kullan.
Böylece database ve entitiyler arasýndaki köprü olan hastanedbcontext köprüsünü kurmuþ olduk.*/

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

app.Run();
