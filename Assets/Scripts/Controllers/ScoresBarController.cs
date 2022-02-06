using System;
using UnityEngine;
using UnityEngine.UI;

namespace Birds
{
    public class ScoresBarController : IConfigure, IInitialize, IExecute, ICleanup
    {
        private SceneInitializer _sceneInitializer;
        private int _scoresToGetBonus;
        private int _scoresPerHit;
        private int _scoresOnStart;
        private GameObject _scoresBar;
        private float FadeTimerMax = 1f;
        private float FadeSpeed = 5f;
        private float _currentScoreOnBar;
        private float _curentScoreTotal;

        private Image _frontBarImage;
        private Image _backBarImage;
        private Color _backColor;
        private float _fadeTimer;

        private Text _scoresLabel;

        private ScoresSystem _scoresSystem;

        public ScoresBarController(GameData gameData, SceneInitializer sceneInitializer)
        {
            _sceneInitializer = sceneInitializer;
            _scoresToGetBonus = gameData.GameProperties.ScoresToGetBonus;
            _scoresPerHit = gameData.GameProperties.ScoresPerHit;
            _scoresOnStart = gameData.GameProperties.ScoresOnStart;
            _scoresSystem = new ScoresSystem(_scoresToGetBonus);
            
        }

        public Action OnBarReset;
        public Action OnScoresRunOut;

        public void Configure()
        {
            _scoresBar = _sceneInitializer.ScoresBar;

            _frontBarImage = _scoresBar.transform.Find(UIElement.BarFront).GetComponent<Image>();
            _backBarImage = _scoresBar.transform.Find(UIElement.BarBack).GetComponent<Image>();
            _scoresLabel = _scoresBar.transform.Find(UIElement.Scores).GetComponent<Text>();
        }

        public void Initialize()
        {
            _scoresSystem.Substract(_scoresToGetBonus);
            SetBarImage(_scoresSystem.GetScoresNormalized());
            _backBarImage.fillAmount = _frontBarImage.fillAmount;

            _curentScoreTotal = _scoresOnStart;
            _scoresLabel.text = _curentScoreTotal.ToString();

            _scoresSystem.OnAdd += AddScores;
            _scoresSystem.OnSubstract += SubstractScores;
        }

        public void Execute(float deltaTime)
        {
            FadeBackBar();
        }

        public void Cleanup()
        {
            _scoresSystem.OnAdd -= AddScores;
            _scoresSystem.OnSubstract -= SubstractScores;
        }

        public float GetScores() => _scoresSystem.GetScoresNormalized();

        public void Substract()
        {
            _scoresSystem.Substract(_scoresPerHit);
            _curentScoreTotal -= _scoresPerHit;
            SetScoreLabel();
        }

        public void Add()
        {
            _scoresSystem.Add(_scoresPerHit);
        }

        private void SetScoreLabel()
        {
            _scoresLabel.text = _curentScoreTotal.ToString();
        }

        private void AddScores()
        {
            _currentScoreOnBar = _scoresSystem.GetScoresNormalized();
            _curentScoreTotal += _scoresPerHit;

            SetScoreLabel();
            SetBarImage(_currentScoreOnBar);

            if (_currentScoreOnBar >= 1) ResetBar();
        }

        private void SubstractScores()
        {
            _currentScoreOnBar = _scoresSystem.GetScoresNormalized();
            _curentScoreTotal -= _scoresPerHit;

            SetBackBar();
            SetBarImage(_currentScoreOnBar);

            if (_curentScoreTotal <= 0) OnScoresRunOut?.Invoke();
        }

        private void SetBarImage(float hitShotsNormalized)
        {
            _frontBarImage.fillAmount = hitShotsNormalized;
        }

        private void FadeBackBar()
        {
            if (_backColor.a > 0)
            {
                _fadeTimer -= Time.deltaTime;
                if (_fadeTimer < 0)
                {
                    _backColor.a -= FadeSpeed * Time.deltaTime;
                    _backBarImage.color = _backColor;
                }
            }
        }

        private void SetBackBar()
        {
            if (_backColor.a <= 0)
            {
                //Back bar image is invisible
                _backBarImage.fillAmount = _frontBarImage.fillAmount;
            }

            _backColor.a = 1;
            _backBarImage.color = _backColor;
            _fadeTimer = FadeTimerMax;
        }

        private void ResetBar()
        {
            _currentScoreOnBar = 0;
            _scoresSystem.Substract(_scoresToGetBonus);

            OnBarReset?.Invoke();
        }
    }

}
