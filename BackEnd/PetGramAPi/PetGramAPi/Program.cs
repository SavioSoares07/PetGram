using PetGramAPi.Communication.Connection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllers();

// Adiciona Swagger para documenta��o da API (opcional).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra a classe DbConnection como um servi�o Singleton
builder.Services.AddSingleton<DbConnection>();

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
