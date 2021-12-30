using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Birds
{
    class TimerController : IInitialize, IExecute
    {
        private GameProperties _gameProperties;
        private SceneInitializer _sceneInitializer;
        private Canvas _timerCanvas;
        private Text _text;
        private float _seconds;

        public TimerController(GameProperties properties, SceneInitializer sceneInitializer)
        {
            _gameProperties = properties;
            _sceneInitializer = sceneInitializer;
        }

        public Action OnTimeElapsed;

        public void Initialize()
        {
            _timerCanvas = _sceneInitializer.Timer;
            _text = _timerCanvas.transform.Find(UIElement.Text).GetComponent<Text>();
            _seconds = _gameProperties.GameTimeOnStart;
        }

        public void Execute(float deltatime)
        {
            DisplayTime(deltatime);
        }

        public void AddTime(float time)
        {
            _seconds += time;
        }

        private void DisplayTime(float deltatime)
        {
            _seconds -= deltatime;
            _text.text = ((int)_seconds).ToString();

            if (_seconds < 0)
            {
                _seconds = 0;
                OnTimeElapsed?.Invoke();
            }
        }
    }
}
