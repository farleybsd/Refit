using Refit;
using RefitApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var CategoriasApiUrl = builder.Configuration["ServiceUri:CategoriasApiUrl"];

builder.Services
    .AddRefitClient<ICategoriaRefitService>()
     .ConfigureHttpClient(c => c.BaseAddress = new Uri(CategoriasApiUrl));


var saude = builder.Configuration["ServiceUri:tipos_unidade_saude"];

builder.Services
    .AddRefitClient<ITipoUnidadesSaude>()
     .ConfigureHttpClient(c => c.BaseAddress = new Uri(saude));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
