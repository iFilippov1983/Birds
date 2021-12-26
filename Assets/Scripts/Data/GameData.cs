using System.IO;
using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/GameData", fileName = "GameData")]
    public class GameData : ScriptableObject
    {
        private const string DataFolderPath = "GameData/";

        [SerializeField] private string _sceneDataPath;
        [SerializeField] private string _interactiveObjectsDataPath;
        [SerializeField] private string _gamePropertiesPath;

        private SceneData _sceneData;
        private InteractiveObjectsData _interactiveObjectsData;
        private GameProperties _gameProperties;

        public SceneData SceneData
        {
            get
            {
                if (_sceneData == null) _sceneData =
                        LoadPath<SceneData>(DataFolderPath + _sceneDataPath);
                return _sceneData;
            }
        }

        public InteractiveObjectsData InateractiveObjectsData
        {
            get
            {
                if (_interactiveObjectsData == null) _interactiveObjectsData =
                        LoadPath<InteractiveObjectsData>(DataFolderPath + _interactiveObjectsDataPath);
                return _interactiveObjectsData;
            }
        }

        public GameProperties GameProperties
        {
            get
            {
                if (_gameProperties == null) _gameProperties =
                        LoadPath<GameProperties>(DataFolderPath + _gamePropertiesPath);
                return _gameProperties;
            }
        }

        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
    }
}

