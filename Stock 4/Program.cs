using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Stock4.Repositories;
using Stock4.DataT;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie();
//builder.Services.AddAuthentication()
//        .AddCookie(options =>
//        {
//            options.LoginPath = "/LoginUser/UserToLogin";
//            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//        });


    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.LoginPath = new PathString("/Admin/AdminHomePage");
            options.LoginPath = new PathString("/Home/Index");
            //options.LoginPath = new PathString("/LoginUser/UserToLogin");

            options.AccessDeniedPath = new PathString("/Home/Index");
        });

//builder.Services.AddAuthorization(options => { options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin")); });
//builder.Services.AddAuthorization(options => { options.AddPolicy("UserRole", policy => policy.RequireRole("User")); });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StockContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUserWatchlist1Repository, UserWatchlist1Repository>();
builder.Services.AddSession();

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
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
