using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/GameProperties", fileName = "GameProperties")]
    public class GameProperties : ScriptableObject
    {
        [SerializeField] private int _scoresToGetBonus = 5;
        [SerializeField] private int _scoresPerHit = 1;
        [SerializeField] private float _gameTimeOnStart = 30f;

        public int ScoresToGetBonus => _scoresToGetBonus;
        public int ScoresPerHit => _scoresPerHit;
        public float GameTimeOnStart => _gameTimeOnStart;
    }
}
