using System.Collections.Generic;
using System;
using System.Text;

public class QuestController
{
    private const int MaxStatesCount = 2;

    private MapController _mapController;
    private Queue<string> _questStates = new Queue<string>();
    public Action<string> OnQuestStateChanged;


    public QuestController()
    {
        _mapController = new MapController();
        QuestDescriptionCommand.OnQuestChanged += HandleQuestEvent;
        QuestNameCommand.OnQuestChanged += _mapController.SetMissionState;
    }

    private void HandleQuestEvent(string questState)
    {
        _questStates.Enqueue(questState);

        if (_questStates.Count > MaxStatesCount)
        {
            _questStates.Dequeue();
        }
    
        string combinedStates = CombineQuestStates();
        OnQuestStateChanged?.Invoke(combinedStates);
    }

    private string CombineQuestStates()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var state in _questStates)
        {
            sb.AppendLine(state);
        }
        return sb.ToString();
    }
}
