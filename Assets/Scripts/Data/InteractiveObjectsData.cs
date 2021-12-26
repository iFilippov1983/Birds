using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/InteractiveObjectsData", fileName = "InteractiveObjectsData")]
    public class InteractiveObjectsData : ScriptableObject
    {
        [SerializeField] private Transform[] _birdsPrefabs;
        [SerializeField] private Transform _bonusPrefab;

        public Transform[] BirdsPrefabs => _birdsPrefabs;
        public Transform BonusPrefab => _bonusPrefab;
    }
}
