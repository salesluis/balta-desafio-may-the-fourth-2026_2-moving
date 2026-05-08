using balta_desafio_may_the_fourth_2026_2_moving.AI.Abstractions;
using balta_desafio_may_the_fourth_2026_2_moving.AI.Agents;
using Microsoft.Agents.AI;

namespace balta_desafio_may_the_fourth_2026_2_moving.AI;

public static class AgentFactory
{
    private static readonly Dictionary<string, AgentCreator> Agents = new()
    {
        ["semantic-box"] = new SemanticBoxAgent(ReadSystemPrompt("SEMANTIC_BOX")),
    };
    
    public static ChatClientAgent? GetAgent(string agentName)
    {
        if (!Agents.TryGetValue(agentName, out var agent))
            throw new InvalidOperationException(@$"O agente {agentName}, não foi encontrado.
                                                 Verifique se digitou o nome correto ou se foi criado o agente");
        return agent!.CreateAgent();
    }
    
    private static string ReadSystemPrompt(string name)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "AI", "Prompts", $"{name}.md");
        return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
    }

}