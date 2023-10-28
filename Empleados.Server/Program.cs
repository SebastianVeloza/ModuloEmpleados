using Empleados.Server.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Conexion de bd
builder.Services.AddSingleton(new Conexion(builder.Configuration.GetConnectionString("conexionBD")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//habilitar Cors

builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowOrigin", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//habilitando el cors
app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
