using System;
using Learn;
using UnityEngine;
using UnityEngine.UI;

namespace Maps
{
    public class MapsController:MonoBehaviour
    {
        private Button _mapButton;
        [SerializeField] private GameObject _lockedMap;
        [SerializeField] private GameObject _unlockedMap;
        [SerializeField] private LearnDatabase _learnDatabase;
        [SerializeField] private Color _lockedColor = Color.gray;
        [SerializeField] private Color _unlockedColor = Color.white;
        private Outline _outline;
        private GameManager _gameManager;
        private void Awake()
        {
            _mapButton = GetComponent<Button>();
            _outline = GetComponent<Outline>();
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }

        public void UnlockMap()
        {
            _mapButton.interactable = true;
            _outline.effectColor = _unlockedColor;
            _lockedMap.SetActive(false);
            _unlockedMap.SetActive(true);
        }
        public void LockMap()
        {
            _mapButton.interactable = false;
            _outline.effectColor = _lockedColor;
            _lockedMap.SetActive(true);
            _unlockedMap.SetActive(false);
        }
        
        public void StartLearn(string scene)
        {
            _gameManager.SetActiveLearn(_learnDatabase);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
        
    }
}