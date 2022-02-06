using System.Collections.Generic;
using UnityEngine;

namespace Birds
{
    class HitAnimationController
    {
        private GameObject _destroyAnimationPrefab;

        public HitAnimationController(GameObject prefab)
        {
            _destroyAnimationPrefab = prefab;
        }

        public void PlayDestroyAnimation(Vector3 position)
        {
            var explosion = Object.Instantiate(_destroyAnimationPrefab);
            explosion.transform.position = position;

            Object.Destroy(explosion, 2);
        }
    }
}
