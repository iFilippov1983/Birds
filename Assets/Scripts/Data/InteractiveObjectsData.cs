using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/InteractiveObjectsData", fileName = "InteractiveObjectsData")]
    public class InteractiveObjectsData : ScriptableObject
    {
        [SerializeField] private HitObject[] _hitObjectsPrefabs;
        [SerializeField] private Bonus[] _bonusesPrefabs;

        public HitObject[] HitObjectsPrefabs => _hitObjectsPrefabs;
        public Bonus[] BonusesPrefabs => _bonusesPrefabs;
    }
}
