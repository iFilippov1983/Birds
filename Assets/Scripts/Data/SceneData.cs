using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject
    {
        private const string DataFolderPath = "Scene/";

        [SerializeField] private string _scoresBarPrefabPath;
        [SerializeField] private string _spawnPointLeftPrefabPath;
        [SerializeField] private string _spawnPointRightPrefabPath;
        [SerializeField] private string _mainCameraPrefabPath;
        [SerializeField] private string _eventSystemPath;
        [SerializeField] private string _cloudsSpawnFieldPrefabPath;
        [SerializeField] private string _cloudPrefabPath;
        [SerializeField] private string _timerPrefabPath;

        private GameObject _scoresBarPrefab;
        private GameObject _spawnPointLeftPrefab;
        private GameObject _spawnPointRightPrefab;
        private Camera _mainCameraPrefab;
        private GameObject _eventSystem;
        private Transform _cloudsSpawnFieldPrefab;
        private GameObject _cloudPrefab;
        private GameObject _timerPrefab;

        public GameObject MainCanvas
        {
            get
            {
                if (_scoresBarPrefab == null) _scoresBarPrefab =
                        Resources.Load<GameObject>(DataFolderPath + _scoresBarPrefabPath);
                return _scoresBarPrefab;
            }
        }

        public GameObject SpawnPointLeft
        {
            get 
            {
                if (_spawnPointLeftPrefab == null) _spawnPointLeftPrefab =
                        Resources.Load<GameObject>(DataFolderPath + _spawnPointLeftPrefabPath);
                return _spawnPointLeftPrefab;
            }
        }

        public GameObject SpawnPointRight
        {
            get
            {
                if (_spawnPointRightPrefab == null) _spawnPointRightPrefab =
                        Resources.Load<GameObject>(DataFolderPath + _spawnPointRightPrefabPath);
                return _spawnPointRightPrefab;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCameraPrefab == null) _mainCameraPrefab =
                         Resources.Load<Camera>(DataFolderPath + _mainCameraPrefabPath);
                return _mainCameraPrefab;
            }
        }

        public GameObject EventSystem
        {
            get
            {
                if (_eventSystem == null) _eventSystem =
                         Resources.Load<GameObject>(DataFolderPath + _eventSystemPath);
                return _eventSystem;
            }
        }

        public Transform CloudsField
        {
            get
            {
                if (_cloudsSpawnFieldPrefab == null) _cloudsSpawnFieldPrefab =
                         Resources.Load<Transform>(DataFolderPath + _cloudsSpawnFieldPrefabPath);
                return _cloudsSpawnFieldPrefab;
            }
        }

        public GameObject CloudsPrefabs
        {
            get
            {
                if (_cloudPrefab == null) _cloudPrefab = 
                        Resources.Load<GameObject>(DataFolderPath + _cloudPrefabPath);
                return _cloudPrefab;
            }
        }

        public GameObject TimerPrefab
        {
            get
            {
                if (_timerPrefab == null) _timerPrefab =
                         Resources.Load<GameObject>(DataFolderPath + _timerPrefabPath);
                return _timerPrefab;
            }
        }
    }
}
