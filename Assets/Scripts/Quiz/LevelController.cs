using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Quiz
{
    public class LevelController:MonoBehaviour
    {
        [SerializeField] private QuizDatabase _quizDatabase;

        private GameManager _gameManager;
        private SceneManager _sceneManager;
        public void Start()
        {
            _gameManager = GameManager.Instance;
            _sceneManager = GetComponent<SceneManager>();
        }

        public void StartQuiz()
        {
            _gameManager.SetActiveQuiz(_quizDatabase);
            _sceneManager.ChangeSceneWithSound("QuizAR");

        }
    }
}