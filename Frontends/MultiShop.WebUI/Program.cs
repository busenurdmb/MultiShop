using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.ConfigOptions;
using MultiShop.WebUI.Handlers;

using MultiShop.WebUI.Services.Concrete;

using MultiShop.WebUI.Services.ImageServices;
using MultiShop.WebUI.Services.Interfaces;

using MultiShop.WebUI.Settings;
using MassTransit;
using MultiShop.WebUI.Consumers;
using System.Net.Mime;

using MultiShop.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(o =>
{
    o.ResourcesPath = "Resources";
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
//builder.Services.AddControllersWithViews()
//    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
//    .AddDataAnnotationsLocalization();

builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();

//JwtBearerDefaults cookie configürasyonu
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/LogOut/";
    opt.AccessDeniedPath = "/Pages/AccessDenied/";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultiShopJwt";
});

//CookieAuthenticationDefaults cookie configürasyonu
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/Index/";
        opt.ExpireTimeSpan = TimeSpan.FromDays(5);
        opt.Cookie.Name = "MultiShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();


builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));


builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClientServices(builder.Configuration);



// Add services to the container.

builder.Services.AddMassTransit(x =>
{
   
  

    x.AddConsumer<ProductNameChangedEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });


        // Endpoint yapýlandýrmasý
        cfg.ReceiveEndpoint("product-name-changed-event-basket-service1", e =>
        {
            e.ConfigureConsumer<ProductNameChangedEventConsumer>(context);

            // Ham JSON deserializer kullanýmý
            e.UseRawJsonDeserializer();
            e.DefaultContentType = new ContentType("application/json");

            // Tüketim topolojisi yapýlandýrmasýný devre dýþý býrakma
            e.ConfigureConsumeTopology = false;
        });
    });
});

builder.Services.AddMassTransitHostedService();



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

var supportedCultures = new[]
{
    "en","fr","de","it","tr"
};
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
