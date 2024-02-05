using Booking.BookingService.Data;
using Booking.BookingService.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "Booking.RideBookingService API", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<RideBookingServiceDbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLowerCaseNamingConvention();
});

builder.Services.AddScoped<DbContext, RideBookingServiceDbContext>();
builder.Services.AddScoped<IMessagePublisherService, MessagePublisherService>();

builder.Services.AddMassTransit(conf =>
{
    conf.SetKebabCaseEndpointNameFormatter();
    conf.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("host.docker.internal", "/", h =>
        {
            h.Username("admin");
            h.Password("admin");
        });
        
        cfg.ConfigureEndpoints(context);
    });
});



var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetService<RideBookingServiceDbContext>()?.Database
    .Migrate();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking.RideBookingService API V1");
});

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();