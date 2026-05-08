using System.ComponentModel;
using balta_desafio_may_the_fourth_2026_2_moving.Application.Abstractions.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;
using OllamaSharp;

namespace balta_desafio_may_the_fourth_2026_2_moving.AI.Tools;

public static class BoxTool
{
    private static IBoxRepository _repository = null!;
    private static OllamaApiClient _ollama = null!;
    
    public static void Initialize(IBoxRepository repository, OllamaApiClient ollama)
    {
        _repository = repository;
        _ollama = ollama;
    }
    
    [Description("Cria uma caixa pelo nome passado pelo usuário")]
    public static async Task CreateItemBoxByName(Box box) =>
        await _repository.CreateAsync(box); 
}