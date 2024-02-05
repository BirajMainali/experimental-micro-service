using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RiderService.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking.RiderService API", Version = "v1" });
});

builder.Services.AddDbContext<RiderServiceDbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLowerCaseNamingConvention();
});

builder.Services.AddMassTransit(x =>
{
    var assembly = typeof(Program).Assembly;

    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();
    x.AddConsumers(assembly);
    x.AddSagaStateMachines(assembly);
    x.AddSagas(assembly);
    x.AddActivities(assembly);

    x.UsingRabbitMq((context, cfg) =>
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

app.Services.CreateScope().ServiceProvider.GetService<RiderServiceDbContext>()?.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking.RiderService API V1");
});

app.UseHttpsRedirection();

app.UseRouting();


app.Run();