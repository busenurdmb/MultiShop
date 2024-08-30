using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Comment.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // JWT kimlik do�rulama �emas�n� ekler
    .AddJwtBearer(opt => // JWT do�rulama ayarlar�n� yap�land�r�r
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"]; // Yetkilendirme sunucusunun URL'sini ayarlar
        opt.Audience = "ResourceComment"; // JWT'nin ge�erli oldu�u kaynak ad�n� belirtir
        opt.RequireHttpsMetadata = false; // Metadata'n�n HTTPS �zerinden olup olmad���n� kontrol etme gere�ini belirtir
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
