using System.Collections.Generic;
using UnityEngine;

namespace Birds
{
    class AnimationController
    {
        private GameObject _destroyAnomationPrefab;
        private Stack<GameObject> _animationGOs;

        public AnimationController(GameProperties gameProperties)
        {
            _destroyAnomationPrefab = gameProperties.DestroyAnimation;
            _animationGOs = new Stack<GameObject>();
        }

        public void PlayDestroyAnimation(Vector3 position)
        {
            var explosion = Object.Instantiate(_destroyAnomationPrefab);
            explosion.transform.position = position;

            _animationGOs.Push(explosion);
        }

        public void ClearStack()
        {
            foreach (GameObject go in _animationGOs)
            {
                Object.Destroy(go);
            }
        }
    }
}
