using UnityEditor;
using UnityEngine;

namespace Birds
{
    class GameProgressController : IInitialize, ICleanup
    {
        private ScoresBarController _scoresBarController;
        private InteractiveObjectsController _objectsController;
        private TimerController _timerController;
        private float _timeToAdd;

        public GameProgressController
            (
            float timeToAdd,
            InteractiveObjectsController objectsController,
            ScoresBarController scoresBarController,
            TimerController timerController
            )
        {
            _objectsController = objectsController;
            _scoresBarController = scoresBarController;
            _timerController = timerController;
            _timeToAdd = timeToAdd;
        }
        public void Initialize()
        {
            _objectsController.OnHitObjectDestroyed += _scoresBarController.Add;
            _objectsController.OnHitObjectEscape += _scoresBarController.Substract;
            _objectsController.OnBonusHit += AddTime;
            _timerController.OnTimeElapsed += FinalizeGame;
            _scoresBarController.OnScoresRunOut += FinalizeGame;
            _scoresBarController.OnBarReset += GiveTimeBonus;
        }

        public void Cleanup()
        {
            _objectsController.OnHitObjectDestroyed -= _scoresBarController.Add;
            _objectsController.OnHitObjectEscape -= _scoresBarController.Substract;
            _objectsController.OnBonusHit -= AddTime;
            _timerController.OnTimeElapsed -= FinalizeGame;
            _scoresBarController.OnScoresRunOut -= FinalizeGame;
            _scoresBarController.OnBarReset -= GiveTimeBonus;
        }

        private void GiveTimeBonus()
        {
            _objectsController.SpawBonus(BonusType.TimeBonus);
        }

        private void AddTime()
        {
            _timerController.AddTime(_timeToAdd);
        }

        private void FinalizeGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
