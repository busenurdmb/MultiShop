using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Comment.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // JWT kimlik doðrulama þemasýný ekler
    .AddJwtBearer(opt => // JWT doðrulama ayarlarýný yapýlandýrýr
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"]; // Yetkilendirme sunucusunun URL'sini ayarlar
        opt.Audience = "ResourceComment"; // JWT'nin geçerli olduðu kaynak adýný belirtir
        opt.RequireHttpsMetadata = false; // Metadata'nýn HTTPS üzerinden olup olmadýðýný kontrol etme gereðini belirtir
    });

// Add services to the container.
builder.Services.AddDbContext<CommentContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
