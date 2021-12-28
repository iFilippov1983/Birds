using System;
using UnityEngine;

namespace Birds
{
    public class HitObject : InteractiveObject, IInteractive
    {
        private const string DataPath = "InteractiveObjects/";

        [SerializeField] private string _hitObjectPropertiesPath;

        private HitObjectProperties _properties;
        private float _lifeTime;
        private SpriteRenderer _spriteRenderer;

        public HitObjectProperties Properties
        {
            get
            {
                if (_properties == null) _properties =
                             Resources.Load<HitObjectProperties>(DataPath + _hitObjectPropertiesPath);
                return _properties;
            }
        }
        
        public Action<HitObject> OnEscape;
        public Action<HitObject> OnHit;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _lifeTime = Properties.LifeTime;
        }
        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            Live();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.gameObject.tag.Equals(Tag.Finish))
            //{
            //    gameObject.SetActive(false);

            //    OnEscape?.Invoke();
            //}

            if (collision.gameObject.GetComponent<MousePosition2D>())
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Interact();

                    OnHit?.Invoke(this);
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

                OnEscape?.Invoke(this);
            } 
        }
    }
}
