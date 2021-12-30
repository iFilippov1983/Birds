using UnityEngine;

namespace Birds
{
    public class InteractiveObjectBuilder
    {
        private GameObject _interactiveObject;

        public InteractiveObjectBuilder MakeInstance(IInteractive prefab)
        {
            var obj = prefab.GetSelfGameObject();
            _interactiveObject = Object.Instantiate(obj);

            return this;
        }

        public InteractiveObjectBuilder SetPosition(Vector2 position)
        {
            _interactiveObject.transform.position = position;

            return this;
        }

        public InteractiveObjectBuilder SetActivityState(bool isActive)
        {
            _interactiveObject.gameObject.SetActive(isActive);

            return this;
        }

        public InteractiveObjectBuilder SetSpriteRendererFlip(bool isFliped)
        {
            var sr = _interactiveObject.GetComponent<SpriteRenderer>();
            sr.flipX = isFliped;

            return this;
        }

        public InteractiveObjectBuilder SetGravityScale(float value)
        {
            _interactiveObject.gameObject.GetComponent<Rigidbody2D>().gravityScale = value;

            return this;
        }

        public IInteractive Build()
        {
            return _interactiveObject.GetComponent<IInteractive>();
        }
    }
}
