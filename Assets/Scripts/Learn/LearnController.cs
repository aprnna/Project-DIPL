using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Learn
{
    public class LearnController: MonoBehaviour
    {
        [SerializeField] private TMP_Text _learn;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Transform _spawnPoint;
        
        private GameManager _gameManager;
        private LearnDatabase _activeLearn;
        private int _currentLearnIndex = 0;
        private GameObject _learnObject;
        private SceneManager _sceneManager;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            _activeLearn = _gameManager.ActiveLearn;
            _sceneManager = GetComponent<SceneManager>();
            InitializeLearn();
        }
        
        private void InitializeLearn()
        {
            if (_activeLearn == null || _activeLearn.LearnItems.Length == 0)
            {
                Debug.LogWarning("No learn items available.");
                return;
            }
            var activeLearnItem = _activeLearn.LearnItems[_currentLearnIndex]; 
            _currentLearnIndex = 0;
            _learn.text = activeLearnItem.title;
            _learnObject = Instantiate(activeLearnItem.prefab, _spawnPoint);
            _backButton.onClick.AddListener(BackLearn);
            _nextButton.onClick.AddListener(NextLearn);
        }
        
        public void NextLearn()
        {
            if(_currentLearnIndex < _activeLearn.LearnItems.Length - 1)
            {
                _currentLearnIndex++;
                if (_learnObject != null)
                {
                    Destroy(_learnObject);
                    _learnObject = Instantiate(_activeLearn.LearnItems[_currentLearnIndex].prefab, _spawnPoint);
                }
                _learn.text = _activeLearn.LearnItems[_currentLearnIndex].title;
            }
            else
            {
                Debug.LogWarning("No more learn items available.");
                _sceneManager.ChangeSceneWithSound("Maps");
                _gameManager.NextMapIndex(); 
                return;
            }
        }

        public void BackLearn()
        {
            if (_currentLearnIndex <= 0)
            {
                Debug.LogWarning("Already at the first learn item.");
                return;
            }
            _currentLearnIndex--;
            _learn.text = _activeLearn.LearnItems[_currentLearnIndex].title;
            if (_learnObject != null)
            {
                Destroy(_learnObject);
                _learnObject = Instantiate(_activeLearn.LearnItems[_currentLearnIndex].prefab, _spawnPoint);
            }
        }
    }
}