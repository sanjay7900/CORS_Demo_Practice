using CORS_Demo_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<Students>();

builder.Services.AddControllers();
builder.Services.AddCors(option=>option.AddPolicy("SpacificPolicy",builder=>builder.WithOrigins("https://localhost:7020")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("SpacificPolicy");

app.MapControllers();

app.Run();
