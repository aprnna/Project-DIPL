using System;
using UnityEngine;
using UnityEngine.UI;

namespace Maps
{
    public class ProgressController : MonoBehaviour
    {
        private Slider _progressSlider;

        private void Start()
        {
            _progressSlider = GetComponent<Slider>();
            if (_progressSlider == null)
            {
                Debug.LogError("Progress Slider not found on the GameObject.");
                return;
            }

            InitializeProgress();
        }

        private void InitializeProgress()
        {
            var gameManager = GameManager.Instance;
            if (gameManager == null)
            {
                Debug.LogError("GameManager instance not found.");
                return;
            }

            int totalMaps = gameManager.GetTotalMaps();
            int currentMapIndex = gameManager.GetMapIndex();
            if (totalMaps <= 0)
            {
                Debug.LogError("Total maps is zero or negative.");
                return;
            }

            _progressSlider.value = (float)(currentMapIndex) / totalMaps;
        }
    }
}