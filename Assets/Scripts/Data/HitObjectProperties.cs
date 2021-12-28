using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/HitObjectProperties", fileName = "NameOfHitObject_Properties")]
    public class HitObjectProperties : InteractiveObjectProperties
    {
        [SerializeField] private float _minSizeMultiplyer;
        [SerializeField] private float _maxSizeMultiplyer;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private int _amountOnScene;
        [SerializeField] private float _lifeTime;

        public float MinSizeMultiplyer => _minSizeMultiplyer;
        public float MaxSizeMultiplyer => _maxSizeMultiplyer;
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;
        public int AmountOnScene => _amountOnScene;
        public float LifeTime => _lifeTime;
    }
}
