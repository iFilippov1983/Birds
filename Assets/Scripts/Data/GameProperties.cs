using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/GameProperties", fileName = "GameProperties")]
    public class GameProperties : ScriptableObject
    {
        [SerializeField] private int _scoresToGetBonus = 5;
        [SerializeField] private int _scoresPerHit = 1;
        [SerializeField] private int _scoresOnStart = 10;
        [SerializeField] private float _gameTimeOnStart = 30f;
        [SerializeField] private float _timeToAddForBonus = 10f;
        [SerializeField] private float _birdsSpawnRate = 1f;
        [SerializeField, Range(0, 10, order = 1)] private float _spawnOffset = 1f;
        [SerializeField] private GameObject _destroyAnimationPrefab;

        public int ScoresToGetBonus => _scoresToGetBonus;
        public int ScoresPerHit => _scoresPerHit;
        public int ScoresOnStart => _scoresOnStart;
        public float GameTimeOnStart => _gameTimeOnStart;
        public float TimeToAddForBonus => _timeToAddForBonus;
        public float SpawnRate => _birdsSpawnRate;
        public float SpawnOffset => _spawnOffset;
        public GameObject DestroyAnimation => _destroyAnimationPrefab;
    }
}
