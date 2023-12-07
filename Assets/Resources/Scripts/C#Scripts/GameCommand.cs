using Naninovel;
using System;

[CommandAlias("gameEvent")]
public class GameCommand : Command
{
    public static event Action OnGameStarted;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        OnGameStarted?.Invoke();
        return UniTask.CompletedTask;
    }
}

