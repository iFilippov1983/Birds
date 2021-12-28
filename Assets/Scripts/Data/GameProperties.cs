using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/GameProperties", fileName = "GameProperties")]
    public class GameProperties : ScriptableObject
    {
        [SerializeField] private int _scoresToGetBonus = 5;
        [SerializeField] private int _scoresPerHit = 1;
        [SerializeField] private float _gameTimeOnStart = 30f;
        [SerializeField] private float _birdsSpawnRate = 1f;
        [SerializeField, Range(0, 10, order = 1)] private float _spawnOffset = 1f;

        public int ScoresToGetBonus => _scoresToGetBonus;
        public int ScoresPerHit => _scoresPerHit;
        public float GameTimeOnStart => _gameTimeOnStart;
        public float SpawnRate => _birdsSpawnRate;
        public float SpawnOffset => _spawnOffset;
    }
}
