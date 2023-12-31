using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using VKFW3.Application;
using VKFW3.Application.Common.Interfaces;
using VKFW3.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Diğer kütüphanelerdeki DI işlemleri
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

// Cors kurallarını serbest bıraktım
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// FluentValidation u entegre ediyorum.
// fv.RegisterValidatorsFromAssemblyContaining<IApplicationContext>()); buradaki mantık validasyon kurallarının,
// IApplicationContext dosyasının bulunduğu kütüphane (.Application) içerisinde olduğunu belirtir.
builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => 
        fv.RegisterValidatorsFromAssemblyContaining<IApplicationContext>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global Hata Yakalayıcı
app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
    var response = new { error = exception.Message };
    await context.Response.WriteAsJsonAsync(response);
}));

if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
