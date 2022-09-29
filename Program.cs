using webapi;
using webapi.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencias
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();
builder.Services.AddSqlServer<TareasContext>("Data Source=LAPTOP-SSJU5TPK;Initial Catalog=Tareas2Db;user id=sa;password=123Richi$890");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();//middleware
    app.UseSwaggerUI();//middleware
}

app.UseHttpsRedirection();//middleware

app.UseAuthorization();//middleware

//app.UseWelcomePage(); middleware

app.MapControllers();//middleware

app.Run();//middleware
