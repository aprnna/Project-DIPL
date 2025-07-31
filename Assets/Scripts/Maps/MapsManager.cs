using System;
using UnityEngine;

namespace Maps
{
    public class MapsManager:MonoBehaviour
    {
        public static MapsManager Instance { get; private set; }

        [SerializeField]
        private MapsController[] mapsControllers;

        private GameManager _gameManager;
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
            _gameManager.SetTotalMaps(mapsControllers.Length);
            InitializeMap();
        }

        private void InitializeMap()
        {
            var currentMapIndex = _gameManager.GetMapIndex();
            if(currentMapIndex >= mapsControllers.Length)
            {
                currentMapIndex = mapsControllers.Length - 1;
            }
            if (currentMapIndex < 0 )
            {
                Debug.LogError("Invalid map index: " + currentMapIndex);
                return;
            }
            for (int i = 0; i < mapsControllers.Length; i++)
            {
                if (i <= currentMapIndex)
                {
                    mapsControllers[i].UnlockMap();
                }
                else
                {
                    mapsControllers[i].LockMap();
                }
            }
        }

    }
}