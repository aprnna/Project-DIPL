using System;
using TMPro;
using UnityEngine;

public class QuizManager: MonoBehaviour
{
    public static QuizManager Instance { get; private set; }
    [SerializeField] private GameObject _endQuizPanel;
    [SerializeField] private TMP_Text _endScoreText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;
    private GameManager _gameManager;
    private QuizDatabase quizDatabase;
    public int Score { get; set; } = 0;
    private int currentQuestionIndex = 0;
    public AudioSource LoseSound => _loseSound;
    public int CurrentQuestionIndex
    {
        get { return currentQuestionIndex; }
        private set { currentQuestionIndex = value; }
    }
    
    public void NextQuestion()
    {
        CurrentQuestionIndex++;
        if (quizDatabase != null && currentQuestionIndex >= quizDatabase.questions.Length)
        {
            _winSound.Play();
            ShowEndQuizPanel();
        }
    }
    
    public void ShowEndQuizPanel()
    {
        _endQuizPanel.SetActive(true);
        _endScoreText.text = _scoreText.text;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        quizDatabase = _gameManager.ActiveQuiz;
        _endQuizPanel.SetActive(false);
        SetScore(Score);
    }

    public QuizQuestion GetCurrentQuestion()
    {
        return quizDatabase.questions[CurrentQuestionIndex];
    }
    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }
    
}