using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();

app.UseCors("Acesso Total");

app.MapGet("/", () => "COLOQUE O SEU NOME");

//ENDPOINTS DE TAREFA
//GET: http://localhost:5273/api/chamado/listar
app.MapGet("/api/chamado/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Chamados.Any())
    {
        return Results.Ok(ctx.Chamados.ToList());
    }
    return Results.NotFound("Nenhum chamado encontrada");
});

//POST: http://localhost:5273/api/chamado/cadastrar
app.MapPost("/api/chamado/cadastrar", async ([FromServices] AppDataContext ctx, [FromBody] Chamado chamado) =>
{
    ctx.Chamados.Add(chamado);
    await ctx.SaveChangesAsync();
    return Results.Created("", chamado);
});

//PUT: http://localhost:5273/chamado/alterar/{id}
app.MapPut("/api/chamado/alterar/{id}", async ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    var chamado = await ctx.Chamados.FirstOrDefaultAsync(x => x.ChamadoId == id);

    if (chamado is null)
    {
        return Results.NotFound("Chamado não encontrado");
    }

    if (chamado.Status == "Em atendimento")
    {
        chamado.Status = "Resolvido";
    }

    if (chamado.Status == "Aberto")
    {
        chamado.Status = "Em atendimento";
    }

    await ctx.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/api/chamado/{id}", async ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    var chamado = await ctx.Chamados
        .FirstOrDefaultAsync(x => x.ChamadoId == id);

    if (chamado is null)
        return Results.NotFound("Nenhum chamado encontrado");

    return Results.Ok(chamado);
});


//GET: http://localhost:5273/chamado/naoconcluidas
app.MapGet("/api/chamado/naoresolvidos", async ([FromServices] AppDataContext ctx) =>
{
    var chamados = await ctx.Chamados
        .Where(x => x.Status == "Em atendimento" || x.Status == "Aberto")
        .ToListAsync();

    if (chamados is null)
        return Results.NotFound("Nenhum chamado encontrado");

    return Results.Ok(chamados);
});

//GET: http://localhost:5273/chamado/concluidas
app.MapGet("/api/chamado/resolvidos", async ([FromServices] AppDataContext ctx) =>
{
    var chamados = await ctx.Chamados
        .Where(x => x.Status == "Resolvido").ToListAsync();

    if (chamados is null)
        return Results.NotFound("Nenhum chamado encontrado");

    return Results.Ok(chamados);
});

app.Run();
