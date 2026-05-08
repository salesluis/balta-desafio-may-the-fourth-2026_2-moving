using System.Text.Json;
using balta_desafio_may_the_fourth_2026_2_moving.AI;
using balta_desafio_may_the_fourth_2026_2_moving.Infra;
using OllamaSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfra(builder.Configuration);

builder.Services.AddTransient<OllamaApiClient>(x => new OllamaApiClient(
    uriString: "http://localhost:11434",
    defaultModel: "mxbai-embed-large"
));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapPost("/v1/prompt", async (Question question) =>
{
    var especialist = AgentFactory.GetAgent("semantic-box");
    var rawResponse =  await especialist!.RunAsync(question.Prompt);
    return Results.Ok(rawResponse.Text);
})
.WithName("Prompt API");

app.Run();

record Question(string Prompt);

