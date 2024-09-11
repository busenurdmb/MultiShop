using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.RabbitMQMessage.Services;

var builder = WebApplication.CreateBuilder(args);
// RabbitMQ ve MassTransit yapýlandýrmasý (message consumer)

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceRabbit";
    opt.RequireHttpsMetadata = false;
});

// Add services to the container.
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();
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
