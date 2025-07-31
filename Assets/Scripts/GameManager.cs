using Learn;
using UnityEngine;

public class GameManager:PersistentSingleton<GameManager>
{
    private GameStatsSO _gameStats;
    public LearnDatabase ActiveLearn { get; private set; }
    public QuizDatabase ActiveQuiz { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (_gameStats == null)
        {
            _gameStats = Resources.Load<GameStatsSO>("GameStats");
            _gameStats.ResetStats();
        }
    }

    public int GetMapIndex()
    {
        if (_gameStats == null) return -1;
        Debug.Log($"Current Map Index: {_gameStats.CurrentMapIndex}");
        return _gameStats.CurrentMapIndex;
    }
    public void SetTotalMaps(int totalMaps)
    {
        if (_gameStats == null) return;
        _gameStats.TotalMaps = totalMaps;
        Debug.Log($"Total Maps Set: {_gameStats.TotalMaps}");
    }
    public int GetTotalMaps()
    {
        Debug.Log($"Total Maps: {_gameStats.TotalMaps}");
        return _gameStats.TotalMaps;
    }
    public void NextMapIndex()
    {
        if (_gameStats == null) return;
        if (_gameStats.CurrentMapIndex >= _gameStats.TotalMaps)
        {
            Debug.LogWarning("Already at the last map.");
            return;
        }
        _gameStats.CurrentMapIndex++;
    }
    
    public void SetActiveLearn(LearnDatabase learnDatabase)
    {
        ActiveLearn = learnDatabase;
        Debug.Log($"Active Learn Database Set: {learnDatabase.name}");
    }
    public void SetActiveQuiz(QuizDatabase quizDatabase)
    {
        ActiveQuiz = quizDatabase;
        Debug.Log($"Active Quiz Database Set: {quizDatabase.name}");
    }
}
