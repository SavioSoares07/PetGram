using PetGramAPi.Communication.Connection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();

// Adiciona Swagger para documentação da API (opcional).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra a classe DbConnection como um serviço Singleton
builder.Services.AddSingleton<DbConnection>();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
