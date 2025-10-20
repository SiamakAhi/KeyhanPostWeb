using keyhanPostWeb.Areas.CMS.CmsInterfaces;
using keyhanPostWeb.Areas.CMS.CmsServices;
using keyhanPostWeb.Models.Entities.Identity;
using keyhanPostWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using keyhanPostWeb.GeneralService;
using keyhanPostWeb.GeneralInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Identity Services
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequiredUniqueChars = 0;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.User.RequireUniqueEmail = true;
    option.Password.RequiredLength = 0;
    option.Password.RequireLowercase = false;
    option.User.AllowedUserNameCharacters = null;

})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<PersianIdentityError>()
    .AddDefaultTokenProviders();

// ======== AddScoped General Services==========================================
builder.Services.AddScoped<IApplicationUserManager, ApplicationUserManager>();
builder.Services.AddScoped<IApplicationRoleManager, ApplicationRoleManager>();
builder.Services.AddScoped<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<PersianIdentityError>();
builder.Services.AddScoped<IPersonService, PersonService>();

// ======== AddScoped CMS Services==========================================
builder.Services.AddScoped<IContentManager, ContentManagerService>();


// ======== AddScoped Club Services==========================================

// ======== AddScoped chat Services==========================================
builder.Services.AddSignalR();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await AppDbContext.SeedData(services); // فراخوانی متد SeedData
    }
    catch (Exception ex)
    {
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();
app.UseStaticFiles();


app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Account}/{action=login}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=KPIndex}/{id?}")
    .WithStaticAssets();

app.UseEndpoints(endpoints =>
{
    // مپ کردن هاب
    endpoints.MapHub<ChatHub>("keyhanPostWeb.GeneralService.ChatHub");
});
app.Run();
