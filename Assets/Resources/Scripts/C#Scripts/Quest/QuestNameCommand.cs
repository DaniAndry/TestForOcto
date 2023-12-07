using Naninovel;
using System;

[CommandAlias("questNameEvent")]
public class QuestNameCommand : Command
{
    [ParameterAlias(NamelessParameterAlias)]
    public StringParameter QuestDescription;

    public static event Action<string> OnQuestChanged;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        if (!string.IsNullOrEmpty(QuestDescription))
        {
            OnQuestChanged?.Invoke(QuestDescription);
        }
        return UniTask.CompletedTask;
    }
}
