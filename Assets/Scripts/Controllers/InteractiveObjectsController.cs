using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Birds
{
    public class InteractiveObjectsController : IInitialize, IExecute, IFixedExecute, ICleanup
    {
        private GameData _gameData;
        private InteractiveObjectsSpawner _spawner;
        private InteractiveObjectsDriver _driver;
        private AnimationController _animationSpawner;
        private Stack<HitObject> _hitObjStack;
        private Dictionary<BonusType, GameObject> _bonusesDictionary;
        private float _spawnRate;
        private float _timeCounter;
        private float _spawnOffset;
        private Vector3 _bonusPosition;
        private Vector3 _interactiveObjectPosition;

        public InteractiveObjectsController(GameData gameData)
        {
            _gameData = gameData;
            _driver = new InteractiveObjectsDriver();
            _spawnRate = _gameData.GameProperties.SpawnRate;
            _spawnOffset = _gameData.GameProperties.SpawnOffset;
        }

        public Action OnHitObjectDestroyed;
        public Action OnHitObjectEscape;
        public Action OnBonusHit;
        
        public void Initialize()
        {
            var cameraSize = Camera.main.orthographicSize;
            var spawnRange = cameraSize - _spawnOffset;

            _spawner = new InteractiveObjectsSpawner(_gameData, spawnRange);
            _hitObjStack = _spawner.CreateUnactiveHitObjectsStack();
            _bonusesDictionary = _spawner.CreateUnactiveBonusesDictionary();

            _animationSpawner = new AnimationController(_gameData.GameProperties);

            SubscribeOnHOEvents();
            SubscribeOnBonusesEvents();
        }

        public void Execute(float deltatime)
        {
            _timeCounter += deltatime;
        }

        public void FixedExecute()
        {
            SpawnHitObjects();
        }

        public void Cleanup()
        {
            _animationSpawner.ClearStack();
            UnsubscribeFromHOEvents();
            UnsubscribeFromBonusesEvents();
        }

        public void SpawBonus(BonusType type)
        {
            var bonus = _bonusesDictionary[type];
            bonus.transform.position = _bonusPosition;
            _driver.DriveBonus(bonus);
        }

        private void SpawnHitObjects()
        {
            if (_timeCounter > _spawnRate && _hitObjStack.Count != 0)
            {
                _timeCounter = 0;
                var hitObj = _hitObjStack.Pop();
                _spawner.Respawn(hitObj);
                _driver.DriveHitObject(hitObj);
            }
        }

        private void HitObjectEscape(HitObject hitObject)
        {
            OnHitObjectEscape?.Invoke();
            _driver.StopHitObject(hitObject);
            _hitObjStack.Push(hitObject);
        }

        private void BonusLifeTimeTermination(Bonus bonus)
        {
            _driver.StopBonus(bonus.gameObject);
        }

        private void ObjectHit(HitObject hitObject)
        {
            _bonusPosition = hitObject.transform.position;

            _interactiveObjectPosition = hitObject.transform.position;
            _animationSpawner.PlayDestroyAnimation(_interactiveObjectPosition);

            OnHitObjectDestroyed?.Invoke();
            _driver.StopHitObject(hitObject);
            _hitObjStack.Push(hitObject);
        }

        private void BonusHit(Bonus bonus)
        {
            _interactiveObjectPosition = bonus.transform.position;
            _animationSpawner.PlayDestroyAnimation(_interactiveObjectPosition);

            OnBonusHit?.Invoke();
            BonusLifeTimeTermination(bonus);
        }

        private void SubscribeOnHOEvents()
        {
            foreach (HitObject ho in _hitObjStack)
            {
                ho.OnEscape += HitObjectEscape;
                ho.OnHit += ObjectHit;
            }
        }

        private void UnsubscribeFromHOEvents()
        {
            var liveObjects = Object.FindObjectsOfType(typeof(HitObject));
            if (liveObjects != null)
            {
                foreach (HitObject ho in liveObjects)
                {
                    ho.OnEscape -= HitObjectEscape;
                    ho.OnHit -= ObjectHit;
                }
            }
            
            foreach (HitObject ho in _hitObjStack)
            {
                ho.OnEscape -= HitObjectEscape;
                ho.OnHit -= ObjectHit;
            }
        }

        private void SubscribeOnBonusesEvents()
        {
            for (int bonusType = 1; bonusType <= _bonusesDictionary.Keys.Count; bonusType++)
            {
                var bonus = _bonusesDictionary[(BonusType)bonusType].GetComponent<Bonus>();
                bonus.OnLifeTermination += BonusLifeTimeTermination;
                bonus.OnShot += BonusHit;
            }
        }

        private void UnsubscribeFromBonusesEvents()
        {
            var bonuses = Object.FindObjectsOfType(typeof(Bonus));

            if (bonuses != null)
            {
                foreach (Bonus b in bonuses)
                {
                    b.OnLifeTermination -= BonusLifeTimeTermination;
                    b.OnShot -= BonusHit;
                }
            }

            for (int bonusType = 1; bonusType <= _bonusesDictionary.Keys.Count; bonusType++)
            {
                var bonus = _bonusesDictionary[(BonusType)bonusType].GetComponent<Bonus>();
                bonus.OnLifeTermination -= BonusLifeTimeTermination;
                bonus.OnShot -= BonusHit;
            }
        }
    }
}
