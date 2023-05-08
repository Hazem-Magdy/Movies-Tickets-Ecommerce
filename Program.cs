using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Services;

var builder = WebApplication.CreateBuilder(args);
// db context configrations
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));

builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<ICinemaRepositoray,CinemaRepository>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


// Add services to the container.
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);

app.Run();


