using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Business.Concrete;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore;
using ConsultancyApp.Data.Concrete.EfCore.Context;
using ConsultancyApp.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ConsultancyAppContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ConsultancyAppContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDescriptionService, CategoryDescriptionManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IPsychologistDescriptionService, PsychologistDescriptionManager>();
builder.Services.AddScoped<IPsychologistService, PsychologistManager>();



builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<ICategoryDescriptionRepository, EfCoreCategoryDescriptionRepository>();
builder.Services.AddScoped<ICustomerRepository, EfCoreCustomerRepository>();
builder.Services.AddScoped<IPsychologistRepository, EfCorePsychologistRepository>();
builder.Services.AddScoped<IPsychologistDescriptionRepository, EfCorePsychologistDescriptionRepository>();

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
    name: "categorydetails",
    pattern:"category/{categoryurl}",
    defaults: new { controller = "Category", action = "CategoryDetails" }
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
