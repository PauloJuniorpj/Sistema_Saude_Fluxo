using FluxoMedicoTesteNeoApp.Core.Repository;
using FluxoMedicoTesteNeoApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuração Banco Dados
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BancoContext>
    (banco => banco.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

//Configuração do Mapper
builder.Services.AddAutoMapper(typeof(StartupBase));

builder.Services.AddControllers();

//Constrole de scopo das repositorys

builder.Services.AddScoped<IMedicoRepository,MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository,PacienteRepository>();
builder.Services.AddScoped<IConsultaMedicaRepository, ConsultaMedicaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Sistema Medico Saúde", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Sistema Medico Saude v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
