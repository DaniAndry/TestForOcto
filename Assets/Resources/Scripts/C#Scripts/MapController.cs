using Naninovel;
using System;

public class MapController
{
    private string _currentMission;

    public MapController()
    {
        MapCommand.OnMapSelected += SelectPoint;
    }

    public void SetMissionState(string mission)
    {
        _currentMission = mission;
    }

    public void SelectPoint(string local)
    {
        var varManager = Engine.GetService<ICustomVariableManager>();
        var myValue = varManager.GetVariableValue("MapPoint");

        string mapPoint = _currentMission + " " + local;

        switch (mapPoint)
        {
            case "continueQuest Field":
                mapPoint = "Field.StartDialogue";
                break;

            case "continueQuest3 Forest":
                mapPoint = "Forest.StartDialogue";
                break;

            case "continueQuest4 Forest":
                mapPoint = "Map.Map";
                break;

            case "continueQuest5 Forest":
                mapPoint = "Map.Map";
                break;

            case "continueQuest4 Field":
                mapPoint = "Field.deviceFound";
                break;

            case "continueQuest5 City":
                mapPoint = "City.finishDialogue";
                break;

            default:
                mapPoint = local + ".emptyLocation";
                break;
        }

        varManager.SetVariableValue("MapPoint", mapPoint);
    }
}

[CommandAlias("mapEvent")]
public class MapCommand : Command
{
    [ParameterAlias(NamelessParameterAlias)]
    public StringParameter MapPoint;
    public static event Action<string> OnMapSelected;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        OnMapSelected?.Invoke(MapPoint);
        return UniTask.CompletedTask;
    }
}
