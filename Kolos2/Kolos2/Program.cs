using Kolos2.Data;
using Kolos2.Repositories;
using Kolos2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


var app = builder.Build();
app.UseAuthorization();

app.MapControllers();

app.Run();