using System;
using UnityEngine;

namespace Birds
{
    public class Bonus : InteractiveObject, IInteractive
    {
        private const string DataPath = "InteractiveObjects/";

        [SerializeField] private string _bonusPropertiesPath;

        private BonusProperties _properties;
        private float _lifeTime;
        private SpriteRenderer _spriteRenderer;
        private UnityEngine.Object _explosionPrefab;

        public Action<Bonus> OnLifeTermination;
        public Action<Bonus> OnShot;

        public BonusProperties Properties
        {
            get
            {
                if (_properties == null) _properties =
                             Resources.Load<BonusProperties>(DataPath + _bonusPropertiesPath);
                return _properties;
            }
        }

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _lifeTime = Properties.LifeTime;
        }

        private void FixedUpdate()
        {
            Live();
        }

        private void OnMouseDown()
        {
            OnShot?.Invoke(this);
        }

        public GameObject GetSelfGameObject() => gameObject;

        private void Live()
        {
            _lifeTime -= Time.deltaTime;
            var notVisible = !_spriteRenderer.isVisible;
            if (_lifeTime < 0 && notVisible)
            {
                _lifeTime = Properties.LifeTime;
                OnLifeTermination?.Invoke(this);
            } 
        }
    }
}
