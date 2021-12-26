using UnityEngine;
using UnityEngine.UI;

namespace Birds
{
    public class ScoresBarController : IConfigure, IInitialize, IExecute, ICleanup
    {
        private SceneInitializer _sceneInitializer;
        private int _scoresToGetBonus;
        private int _scoresPerHit;
        private GameObject _scoresBar;
        private float FadeTimerMax = 1f;
        private float FadeSpeed = 5f;

        private Image _frontBarImage;
        private Image _backBarImage;
        private Color _backColor;
        private float _fadeTimer;
        private ScoresSystem _scoresSystem;

        public ScoresBarController(GameData gameData, SceneInitializer sceneInitializer)
        {
            _scoresSystem = new ScoresSystem(_scoresToGetBonus);

            _sceneInitializer = sceneInitializer;
            _scoresToGetBonus = gameData.ScoresToGetBonus;
            _scoresPerHit = gameData.ScoresPerHit;
        }
        public void Configure()
        {
            _scoresBar = _sceneInitializer.ScoresBar;
            _frontBarImage = _scoresBar.transform.Find(UIElement.BarFront).GetComponent<Image>();
            _backBarImage = _scoresBar.transform.Find(UIElement.BarBack).GetComponent<Image>();

            _frontBarImage.fillAmount = 0;
            _backColor = _backBarImage.color;
            _backColor.a = 0f;
            _backBarImage.color = _backColor;
        }

        public void Initialize()
        {
            SetBarImage(_scoresSystem.GetScoresNormalized());
            _backBarImage.fillAmount = _frontBarImage.fillAmount;

            _scoresSystem.OnAdd += AddScores;
            _scoresSystem.OnSubstract += SubstractScores;
        }

        public void Execute(float deltaTime)
        {
            FadeBackBar();
        }

        public void Cleanup()
        {
            _scoresSystem.OnAdd += AddScores;
            _scoresSystem.OnSubstract += SubstractScores;
        }

        public void Substract()
        {
            _scoresSystem.Substract(_scoresPerHit);
        }

        public void Add()
        {
            _scoresSystem.Add(_scoresPerHit);
        }

        private void AddScores()
        {
            SetBarImage(_scoresSystem.GetScoresNormalized());
        }

        private void SubstractScores()
        {
            SetBackBar();
            SetBarImage(_scoresSystem.GetScoresNormalized());
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
    }

}
