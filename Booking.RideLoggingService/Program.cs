using Booking.RideLoggingSerivce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Administrative API", Version = "v1" }); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<RideLoggingServiceDbContext>(o => { o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseLowerCaseNamingConvention(); });


builder.Services.AddScoped<DbContext, RideLoggingServiceDbContext>();

var app = builder.Build();


app.Services.CreateScope().ServiceProvider.GetService<RideLoggingServiceDbContext>()?.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Administrative API V1"); });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.Run();