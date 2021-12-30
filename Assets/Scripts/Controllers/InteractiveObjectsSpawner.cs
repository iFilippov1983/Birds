using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Birds
{
    public class InteractiveObjectsSpawner
    {
        private InteractiveObjectsData _interactiveObjectsData;
        private InteractiveObjectBuilder _builder;
        private HitObject[] _hitObjects;
        private Bonus[] _bonuses;
        private float _minMultiplyer;
        private float _maxMultiplyer;
        private Transform _spawnPointLeft;
        private Transform _spawnPointRight;
        private float _spawnRange;
        private bool _isFliped;

        public InteractiveObjectsSpawner(GameData gameData, float spawnRange)
        {
            _builder = new InteractiveObjectBuilder();
            _interactiveObjectsData = gameData.InateractiveObjectsData;
            _spawnPointLeft = gameData.SceneData.SpawnPointLeft.transform;
            _spawnPointRight = gameData.SceneData.SpawnPointRight.transform;
            _spawnRange = spawnRange;
        }

        public Stack<HitObject> CreateUnactiveHitObjectsStack()
        {
            _hitObjects = _interactiveObjectsData.HitObjectsPrefabs;

            var stack = new Stack<HitObject>();

            foreach (HitObject ho in _hitObjects)
            {
                var amount = ho.Properties.AmountOnScene;
                for (int index = 0; index < amount; index++)
                {
                    var obj = SpawnUnactive(ho) as HitObject;
                    stack.Push(obj);
                }
            }

            return stack;
        }

        public Dictionary<BonusType, GameObject> CreateUnactiveBonusesDictionary()
        {
            _bonuses = _interactiveObjectsData.BonusesPrefabs;

            var dic = new Dictionary<BonusType, GameObject>();

            foreach (Bonus b in _bonuses)
            {
                var type = b.Properties.Type;
                var obj = SpawnUnactive(b) as Bonus;
                dic.Add(type, obj.gameObject);
            }

            return dic;
        }

        public InteractiveObject Respawn(InteractiveObject interactiveObj)
        {
            interactiveObj.gameObject.SetActive(true);

            if (interactiveObj.GetType().Equals(typeof(HitObject)))
            {
                interactiveObj.transform.position = CalculateRandomPosition();
                interactiveObj.GetComponent<SpriteRenderer>().flipX = _isFliped;
                SetRandomScale(interactiveObj as HitObject);
            }

            return interactiveObj;
        }

        private IInteractive SpawnUnactive(IInteractive prefab)
        {
            var interactiveObject = _builder
                                        .MakeInstance(prefab)
                                        .SetPosition(CalculateRandomPosition())
                                        .SetActivityState(false)
                                        .SetSpriteRendererFlip(_isFliped)
                                        .SetGravityScale(0)
                                        .Build();

            return interactiveObject;
        }

        private Vector2 CalculateRandomPosition()
        {
            int side = Random.Range(0,2);
            Vector3 position;

            if (side == 0)
            {
                position = _spawnPointLeft.position;
                _isFliped = false;
            }
            else
            {
                position = _spawnPointRight.position;
                _isFliped = true;
            }

            float yCorrection = Random.Range(-_spawnRange, +_spawnRange);
            position.y += yCorrection;

            return position;
        }

        private void SetRandomScale(HitObject hitObject)
        {
            _minMultiplyer = hitObject.Properties.MinSizeMultiplyer;
            _maxMultiplyer = hitObject.Properties.MaxSizeMultiplyer;
            hitObject.gameObject.transform.localScale *= Random.Range(_minMultiplyer, _maxMultiplyer);
        }
    }
}
