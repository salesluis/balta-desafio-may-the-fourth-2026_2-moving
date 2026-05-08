using balta_desafio_may_the_fourth_2026_2_moving.AI.Abstractions;
using balta_desafio_may_the_fourth_2026_2_moving.AI.Tools;
using Microsoft.Extensions.AI;

namespace balta_desafio_may_the_fourth_2026_2_moving.AI.Agents;

public class SemanticBoxAgent(string systemPrompt) : AgentCreator
{
    protected override string Uri => "http://localhost:11434";
    protected override string Model => "llama3.1:latest";
    protected override string SystemPrompt => systemPrompt;

    protected override AITool[] Tools =>
    [
        AIFunctionFactory.Create(ItemBoxTool.CreateItemBoxByName),
        AIFunctionFactory.Create(ItemBoxTool.GetSimilarItemBoxes),
        AIFunctionFactory.Create(BoxTool.CreateItemBoxByName),
    ];
}