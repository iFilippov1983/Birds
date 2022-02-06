using UnityEngine;

namespace Birds
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private ControllersDepo _controllers;

        public void Awake()
        {
            _controllers = new ControllersDepo();
            new GameInitializer(_controllers, _gameData);
            _controllers.Configure();
        }

        public void Start()
        {
            _controllers.Initialize();
        }

        public void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        public void FixedUpdate()
        {
            _controllers.FixedExecute();
        }

        public void LateUpdate()
        {
            _controllers.LateExecute();
        }

        public void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}

