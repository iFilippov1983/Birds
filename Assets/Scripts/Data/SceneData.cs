using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/SceneData", fileName = "SceneData")]
    public class SceneData : ScriptableObject
    {
        private const string DataFolderPath = "Scene/";

        [SerializeField] private string _scoresBarPrefabPath;
        [SerializeField] private string _borderLeftPrefabPath;
        [SerializeField] private string _borderRightPrefabPath;
        [SerializeField] private string _mainCameraPrefabPath;
        [SerializeField] private string _eventSystemPath;
        [SerializeField] private string _cloudsSpawnFieldPrefabPath;
        [SerializeField] private string _cloudPrefabPath;
        [SerializeField] private string _timerPrefabPath;

        private GameObject _scoresBarPrefab;
        private GameObject _borderLeftPrefab;
        private GameObject _borderRightPrefab;
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

        public GameObject BorderLeft
        {
            get 
            {
                if (_borderLeftPrefab == null) _borderLeftPrefab =
                        Resources.Load<GameObject>(DataFolderPath + _borderLeftPrefabPath);
                return _borderLeftPrefab;
            }
        }

        public GameObject BorderRight
        {
            get
            {
                if (_borderRightPrefab == null) _borderRightPrefab =
                        Resources.Load<GameObject>(DataFolderPath + _borderRightPrefabPath);
                return _borderRightPrefab;
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
