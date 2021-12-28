using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/BonusProperties", fileName = "NameOfBonus_Properties")]
    public class BonusProperties : InteractiveObjectProperties
    {
        [SerializeField] private BonusType _type;
        [SerializeField] private float _minSizeMultiplyer;
        [SerializeField] private float _maxSizeMultiplyer;
        [SerializeField] private float _timeBonus;
        [SerializeField] private float _lifeTime;

        public BonusType Type => _type;
        public float MinSizeMultiplyer => _minSizeMultiplyer;
        public float MaxSizeMultiplyer => _maxSizeMultiplyer;
        public float TimeBonus => _timeBonus;
        public float LifeTime => _lifeTime;
    }

    public enum BonusType
    { 
        None = 0,
        TimeBonus = 1
    }
}
