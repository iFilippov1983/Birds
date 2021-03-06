using System.Collections.Generic;
using UnityEngine;

namespace Birds
{
    public class SceneInitializer : IConfigure, IInitialize
    {
        private SceneData _sceneData;
        private CloudsSpawner _cloudsSpawner;
        private GameObject _scoresBar;
        private GameObject _borderLeft;
        private GameObject _borderRight;
        private Camera _mainCamera;
        private Canvas _timer;

        public GameObject ScoresBar => _scoresBar;
        public GameObject BorderLeft => _borderLeft;
        public GameObject BorderRight => _borderRight;
        public List<GameObject> Clouds => _cloudsSpawner.Clouds;
        public Canvas Timer => _timer;

        public SceneInitializer(SceneData sceneData)
        {
            _sceneData = sceneData;
            _cloudsSpawner = new CloudsSpawner(_sceneData.CloudsField, _sceneData.CloudsPrefabs);
        }

        public void Configure()
        {
            _scoresBar = Object.Instantiate(_sceneData.MainCanvas);
            _mainCamera = Object.Instantiate(_sceneData.MainCamera);
            _borderLeft = Object.Instantiate(_sceneData.SpawnPointLeft);
            _borderRight = Object.Instantiate(_sceneData.SpawnPointRight);
            _timer = Object.Instantiate(_sceneData.TimerPrefab).GetComponent<Canvas>();
            Object.Instantiate(_sceneData.EventSystem);
        }

        public void Initialize()
        {
            _scoresBar.GetComponent<Canvas>().worldCamera = _mainCamera;
            _timer.GetComponent<Canvas>().worldCamera = _mainCamera;

            _cloudsSpawner.SpawnClouds();
        }
    }
}
