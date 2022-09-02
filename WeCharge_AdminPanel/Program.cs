using WeCharge.BAL.Services.Implementation;
using WeCharge.BAL.Services.Interface;
using WeCharge.DAL.Connection;
using WeCharge.DAL.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;
using WeCharge_AdminPanel.Handler;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.LogoutPath = new PathString("/Account/LogOut");
        options.LoginPath = new PathString("/");
        options.SlidingExpiration = true;
        options.Cookie.Name = "UserLoginCookie";
        options.AccessDeniedPath = new PathString("/Account/AccessDenied");
    });
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("UserPolicy", policyBuilder =>
    {
        policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
        //policyBuilder.UserRequireCustomClaim(ClaimTypes.Role);
    });
});

builder.Services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
builder.Services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IAssetServices, AssetServices>();
builder.Services.AddScoped<IWallet, WalletServices>();
builder.Services.AddScoped<IOrdersServices, OrdersServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");


app.Run();
