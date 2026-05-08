using System.ComponentModel;
using balta_desafio_may_the_fourth_2026_2_moving.Application.Abstractions.Repositories;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Entities;
using balta_desafio_may_the_fourth_2026_2_moving.Domain.Repositories;
using Microsoft.SemanticKernel.Embeddings;
using OllamaSharp;

namespace balta_desafio_may_the_fourth_2026_2_moving.AI.Tools;

    // todo implementar tudo via prompt, criação, etc...
public static class ItemBoxTool
{
    private static IItemBoxRepository _repository = null!;
    private static OllamaApiClient _ollama = null!;
    
    public static void Initialize(IItemBoxRepository repository, OllamaApiClient ollama)
    {
        _repository = repository;
        _ollama = ollama;
    }
    
    [Description("Cria um item pelo nome passado pelo usuário")]
    public static async Task CreateItemBoxByName(
        [Description("Entidade que vai ser criada para inserir no banco")]
        ItemBox itemBox,
        [Description("Numero da caixa onde será colocado o item")]
        int numberBox) =>
        await _repository.CreateAsync(itemBox, numberBox); 
   
    [Description("Busca um item pelo nome exato")]
    public static async Task<ItemBox?> GetItemBoxByName(string productName) =>
        await _repository.GetAsync(productName);

    [Description("Busca produtos similares por contexto quando o nome exato não é conhecido")]
    public static async Task<List<ItemBox>> GetSimilarItemBoxes(
        [Description("contexto que o usuário mandou")]
        string context)
    {
        var embeddings = await _ollama
            .AsTextEmbeddingGenerationService()
            .GenerateEmbeddingAsync(context);

        var i = await _repository.SearchSimilarAsync(embeddings.ToArray());
        return i;
    }
    
    
}