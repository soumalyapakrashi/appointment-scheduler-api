using appointment_scheduler_api.Data;
using appointment_scheduler_api.Services.auth;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add database service
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DevDbConnection")
));

// Add support for services with controllers
builder.Services.AddControllers();

// Setup CORS and add policy to allow the frontend running on http://localhost:3000
builder.Services.AddCors(options => options.AddPolicy(name: "AppointmentScheduler",
    policy => {
        policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    }
));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Automapper support
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Register services
builder.Services.AddScoped<IUserAuthService, UserAuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AppointmentScheduler");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
