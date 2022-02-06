using UnityEngine;

namespace Birds
{
    public sealed class InteractiveObjectBuilder
    {
        private GameObject _interactiveObject;

        public IInteractive Build(IInteractive prefab, Vector2 position, bool isActive, bool isFliped, float gravityScale)
        {
            return MakeInstance(prefab)
                    .SetPosition(position)
                    .SetActivityState(isActive)
                    .SetSpriteRendererFlip(isFliped)
                    .SetGravityScale(gravityScale)
                    .Build();
        }

        private IInteractive Build()
        {
            return _interactiveObject.GetComponent<IInteractive>();
        }

        private InteractiveObjectBuilder MakeInstance(IInteractive prefab)
        {
            var obj = prefab.GetSelfGameObject();
            _interactiveObject = Object.Instantiate(obj);

            return this;
        }

        private InteractiveObjectBuilder SetPosition(Vector2 position)
        {
            _interactiveObject.transform.position = position;

            return this;
        }

        private InteractiveObjectBuilder SetActivityState(bool isActive)
        {
            _interactiveObject.gameObject.SetActive(isActive);

            return this;
        }

        private InteractiveObjectBuilder SetSpriteRendererFlip(bool isFliped)
        {
            var sr = _interactiveObject.GetComponent<SpriteRenderer>();
            sr.flipX = isFliped;

            return this;
        }

        private InteractiveObjectBuilder SetGravityScale(float value)
        {
            _interactiveObject.gameObject.GetComponent<Rigidbody2D>().gravityScale = value;

            return this;
        }
    }
}
