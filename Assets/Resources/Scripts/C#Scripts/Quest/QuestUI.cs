using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Text questDescriptionText;
    [SerializeField] private QuestController _controller;

    private void OnEnable()
    {
        _controller = new QuestController();
      _controller.OnQuestStateChanged += UpdateQuestText;
    }

    private void OnDisable()
    {
      _controller.OnQuestStateChanged -= UpdateQuestText;
    }

    private void UpdateQuestText(string newText)
    {
        questDescriptionText.text = newText;
    }
}