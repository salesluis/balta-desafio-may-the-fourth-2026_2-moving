using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace balta_desafio_may_the_fourth_2026_2_moving.AI.Abstractions;

public abstract class AgentCreator
{
    protected abstract string Uri { get; }
    protected abstract string Model { get; }
    protected abstract string SystemPrompt { get; }
    protected abstract AITool[] Tools { get; }
    
    public ChatClientAgent CreateAgent() => new 
            OllamaApiClient(Uri, Model)
                .AsAIAgent(
                    SystemPrompt,
                    tools: Tools);
}
