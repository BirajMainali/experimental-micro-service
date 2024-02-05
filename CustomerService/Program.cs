using CustomerService.Data;
using CustomerService.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerService API", Version = "v1" }); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CustomerServiceDbContext>(o => { o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseLowerCaseNamingConvention(); });
builder.Services.AddScoped<DbContext, CustomerServiceDbContext>();
builder.Services.AddScoped<IMessagePublisherService, MessagePublisherService>();

builder.Services.AddMassTransit(conf =>
{
    conf.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("host.docker.internal", "/", h =>
        {
            h.Username("admin");
            h.Password("admin");
        });
    });
});

var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetService<CustomerServiceDbContext>()?.Database.Migrate();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerService API V1"); });

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();