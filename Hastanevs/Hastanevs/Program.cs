using Hastanevs.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HastaneDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HastaneDbContext>().AddDefaultTokenProviders();
/*GetConnectionString ile connectionlar� yani ba�lant�lar�m�z� ald�k.
appsettingsjsonda b�yle kullanmam�z istendi�inden b�yle yapt�k.
asp.net mekanizmas�na dedik ki olu�turdu�umuz hastanedbcontext dosyas�n� kullan,bu k�pr� dosyas�n� olu�tururken
sql server kullan. bu sql serveri kullan�rken de defaultconnection'� kullan.
B�ylece database ve entitiyler aras�ndaki k�pr� olan hastanedbcontext k�pr�s�n� kurmu� olduk.*/

builder.Services.AddRazorPages(); //razor sayfalarını kullanabilmek için.
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
