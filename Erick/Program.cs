using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapPost("/api/folha/cadastrar",
    ([FromBody] Folha? folha,
    [FromServices] AppDataContext ctx) =>
{
    if (folha is null)
    {
        return Results.BadRequest("A folha não pode ser nula");
    }

    if (folha.Mes < 1 || folha.Mes > 12)
    {
        return Results.BadRequest("O mês deve estar entre 1 e 12");
    }

    if (folha.Ano < 2000)
    {
        return Results.BadRequest("O ano deve ser maior ou igual a 2000");
    }

    Folha? folhaEncontrada =
        ctx.Folhas.FirstOrDefault(x =>
            x.CPF == folha.CPF &&
            x.Mes == folha.Mes &&
            x.Ano == folha.Ano);

    if (folhaEncontrada is not null)
    {
        return Results.BadRequest("Já existe uma folha para esse CPF, mês e ano");
    }


    folha.ValorBruto = folha.horasTrabalhadas * folha.ValorHora;
    
// Até 1903,98                  → IR = 0
// De 1903,99 até 2826,65      → 7,5% - 142,80
// De 2826,66 até 3751,05      → 15%  - 354,80
// De 3751,06 até 4664,68      → 22,5% - 636,13
// Acima de 4664,68            → 27,5% - 869,36

    if (folha.ValorBruto <= 1903.98)
    {
    folha.ImpostoRenda = 0;
    }
    else if (folha.ValorBruto <= 2826.65)
    {
    folha.ImpostoRenda = (folha.ValorBruto * 0.075) - 142.80;
    }
    else if (folha.ValorBruto <= 3751.05)
    {
    folha.ImpostoRenda = (folha.ValorBruto * 0.15) - 354.80;
    }
    else if (folha.ValorBruto <= 4664.68)
    {
    folha.ImpostoRenda = (folha.ValorBruto * 0.225) - 636.13;
    }
    else
    {
    folha.ImpostoRenda = (folha.ValorBruto * 0.275) - 869.36;
    }
   


    return Results.Ok(folha);
});


// Até 1903,98                  → IR = 0
// De 1903,99 até 2826,65      → 7,5% - 142,80
// De 2826,66 até 3751,05      → 15%  - 354,80
// De 3751,06 até 4664,68      → 22,5% - 636,13
// Acima de 4664,68            → 27,5% - 869,36




app.Run();

