using System;
using UnityEngine;
using UnityEngine.UI;

namespace Birds
{
    class TimerController : IInitialize, IExecute
    {
        private SceneInitializer _sceneInitializer;
        private Canvas _timerCanvas;
        private Text _text;
        private float _seconds;

        public TimerController(float timeOnStart, SceneInitializer sceneInitializer)
        {
            _seconds = timeOnStart;
            _sceneInitializer = sceneInitializer;
            
        }

        public Action OnTimeElapsed;

        public void Initialize()
        {
            _timerCanvas = _sceneInitializer.Timer;
            _text = _timerCanvas.transform.Find(UIElement.Text).GetComponent<Text>();
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
