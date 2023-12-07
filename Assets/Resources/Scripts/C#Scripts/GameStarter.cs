using DTT.MinigameMemory;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private MemoryGameManager _memoryGameManager;
    [SerializeField] private MemoryGameSettings _gameSettings;
    [SerializeField] private GameObject _game;

    private void OnEnable()
    {
        GameCommand.OnGameStarted += StartGame;
        _memoryGameManager.Finish += FinishGame;
    }

    private void StartGame()
    {
        _game.SetActive(true);
        _memoryGameManager.StartGame(_gameSettings);
    }

    private void FinishGame(MemoryGameResults result)
    {
        _game.SetActive(false);
    }
}