using System.IO;
using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/GameData", fileName = "GameData")]
    public class GameData : ScriptableObject
    {
        private const string DataFolderPath = "GameData/";

        [SerializeField] private int _scoresToGetBonus = 5;
        [SerializeField] private int _scoresPerHit = 1;

        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _sceneDataPath;
        [SerializeField] private string _uiDataPath;
        [SerializeField] private string _gameProgressDataPath;

        private PlayerData _playerData;
        private SceneData _sceneData;
        private UIData _uiData;
        private GameProgressData _gameProgressData;

        public int ScoresToGetBonus => _scoresToGetBonus;
        public int ScoresPerHit => _scoresPerHit;

        public PlayerData PlayerData
        {
            get
            {
                if (_playerData == null) _playerData =
                        LoadPath<PlayerData>(DataFolderPath + _playerDataPath);
                return _playerData;
            }
        }

        public SceneData SceneData
        {
            get
            {
                if (_sceneData == null) _sceneData =
                        LoadPath<SceneData>(DataFolderPath + _sceneDataPath);
                return _sceneData;
            }
        }

        public UIData UIData
        {
            get
            {
                if (_uiData == null) _uiData =
                        LoadPath<UIData>(DataFolderPath + _uiDataPath);
                return _uiData;
            }
        }

        public GameProgressData GameProgressData
        {
            get
            {
                if (_gameProgressData == null) _gameProgressData =
                        LoadPath<GameProgressData>(DataFolderPath + _gameProgressDataPath);
                return _gameProgressData;
            }
        }

        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
    }
}

