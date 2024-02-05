using API.Extensions;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Delgate to our Extension class, to perform the rest of the services decoration.
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

// This directive pushes all actions through our Exception Handling middleware, enabling us to catch any server errors, and format a response
// through ApiException.
app.UseMiddleware<ExceptionMiddleware>();


// This directive enables us to catch errors and reformat the response (via the ErrorController)
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwagger();
app.UseSwaggerUI();

// This directive enables the app to serve static content for the product images:
app.UseStaticFiles();

// This directive enables a CORS (Cross-Origin Resource Sharing) policy to be used (set in ApplicationServicesExtensions):
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

// Prepare the database and copy the sample data:
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration.");
}

app.Run();
