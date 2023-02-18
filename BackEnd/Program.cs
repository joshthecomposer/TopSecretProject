// Added using statements
using Microsoft.EntityFrameworkCore;
using Server.Models;
var builder = WebApplication.CreateBuilder(args);
// Added connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
// Add cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader();
        }
    );
});
// Add MySQL connection
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
// Comment these out
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Add this
    app.UseDeveloperExceptionPage();
    // Comment these out
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
// Add this line
app.UseCors();
app.MapControllers();
app.Run();


