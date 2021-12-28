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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<MousePosition2D>())
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Interact();

                    OnShot?.Invoke(this);
                }
            }
        }

        public override void Interact()
        {

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
