using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var l = builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestPath | HttpLoggingFields.RequestMethod | HttpLoggingFields.ResponseStatusCode | HttpLoggingFields.ResponseBody;
    logging.MediaTypeOptions.AddText("application/json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();