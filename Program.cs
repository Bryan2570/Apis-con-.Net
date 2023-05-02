using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IHelloWorldService, HelloWorldSercvice>();

//otra manera de inyectar
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldSercvice());
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareaServices,TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();

//Quien puede utilizarla y quien no puede la API
//app.UseCors();

app.UseAuthorization();

//mensaje de bienvenida mostrandonos la API
//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
