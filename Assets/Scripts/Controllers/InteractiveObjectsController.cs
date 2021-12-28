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
        private Stack<HitObject> _hitObjStack;
        private Stack<HitObject> _objectsToSwing;
        private Dictionary<BonusType, GameObject> _bonusesDictionary;
        private InteractiveObjectsData _interactiveObjectsData;
        private Camera _camera;
        private float _cameraSize;
        private float _spawnRate;
        private float _timeCounter;
        private float _spawnOffset;

        public InteractiveObjectsController(GameData gameData)
        {
            _gameData = gameData;
            _driver = new InteractiveObjectsDriver();
            _interactiveObjectsData = _gameData.InateractiveObjectsData;
            _spawnRate = _gameData.GameProperties.SpawnRate;
            _spawnOffset = _gameData.GameProperties.SpawnOffset;
        }

        public Action<HitObject> OnHitObjectDestroyed;
        public Action<Bonus> OnBonusHit;

        public void Initialize()
        {
            _camera = Object.FindObjectOfType<Camera>();
            _cameraSize = _camera.orthographicSize;

            var spawnRange = _cameraSize - _spawnOffset;
            _spawner = new InteractiveObjectsSpawner(_gameData, spawnRange);
            _hitObjStack = _spawner.CreateUnactiveHitObjectsStack();
            _bonusesDictionary = _spawner.CreateUnactiveBonusesDictionary();
            _objectsToSwing = new Stack<HitObject>();

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
            UnsubscribeFromHOEvents();
            UnsubscribeFromBonusesEvents();

            _objectsToSwing.Clear();
        }

        private void SpawnHitObjects()
        {
            if (_timeCounter > _spawnRate && _hitObjStack.Count != 0)
            {
                _timeCounter = 0;

                var hitObj = _hitObjStack.Pop();
                _spawner.Respawn(hitObj);
                _driver.DriveHitObject(hitObj);

                _objectsToSwing.Push(hitObj);
            }
        }

        private void LifeTimeTermination(HitObject hitObject)
        {
            _driver.StopHitObject(hitObject);
            _hitObjStack.Push(hitObject);
        }

        private void BonusLifeTimeTermination(Bonus bonus)
        {
            _driver.StopBonus(bonus);
        }

        private void ObjectHit(HitObject hitObject)
        {
            LifeTimeTermination(hitObject);
            OnHitObjectDestroyed?.Invoke(hitObject);
        }

        private void BonusHit(Bonus bonus)
        {
            BonusLifeTimeTermination(bonus);
            OnBonusHit?.Invoke(bonus);
        }

        private void SubscribeOnHOEvents()
        {
            foreach (HitObject ho in _hitObjStack)
            {
                ho.OnEscape += LifeTimeTermination;
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
                    ho.OnEscape -= LifeTimeTermination;
                    ho.OnHit -= ObjectHit;
                }
            }
            
            foreach (HitObject ho in _hitObjStack)
            {
                ho.OnEscape -= LifeTimeTermination;
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
            var liveObjects = Object.FindObjectsOfType(typeof(Bonus));

            if (liveObjects != null)
            {
                foreach (Bonus b in liveObjects)
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
