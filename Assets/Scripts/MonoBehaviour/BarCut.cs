using UnityEngine;
using UnityEngine.UI;

namespace Birds
{
    /// <summary>
    /// Bar with cutting back image
    /// </summary>
    public class BarCut : MonoBehaviour
    {
        private const int ShotsToGetBonus = 5;
        private const int ScoresForShot = 1;
        private const float ShrinkTimerMax = 1f;
        private const float ShrinkSpeed = 5f;

        [SerializeField, Header("Value from the Rect Transform of the bar this script attached on")]
        private float _rectTransformWidth = 400f;
        private Image _frontBarImage;
        private Transform _backBar;
        private Transform _backBarTemplate;
        private float _beforeSubstractionBarFillAmount;
        private HitShotsSystem _hitShotSystem;

        private void Awake()
        {
            _frontBarImage = transform.Find(UIElementName.BarFront).GetComponent<Image>();
            _backBarTemplate = transform.Find(UIElementName.BarBackTemplate);
        }

        private void Start()
        {
            _hitShotSystem = new HitShotsSystem(ShotsToGetBonus);
            SetHitShots(_hitShotSystem.GetHitShotsNormalized());

            _hitShotSystem.OnAdd += AddHitShot;
            _hitShotSystem.OnSubstract += SubstractHitShot;

            Button buttonS = transform.Find("SubstractButton").GetComponent<Button>();
            buttonS.onClick.AddListener(Substract);

            Button buttonA = transform.Find("AddButton").GetComponent<Button>();
            buttonA.onClick.AddListener(Add);

        }

        private void Update()
        {
            CutBackBar();
        }

        private void OnDestroy()
        {
            _hitShotSystem.OnAdd -= AddHitShot;
            _hitShotSystem.OnSubstract -= SubstractHitShot;
        }

        private void AddHitShot()
        {
            SetHitShots(_hitShotSystem.GetHitShotsNormalized());
        }

        private void SubstractHitShot()
        {
            _beforeSubstractionBarFillAmount = _frontBarImage.fillAmount;

            SetHitShots(_hitShotSystem.GetHitShotsNormalized());

            _backBar = Instantiate(_backBarTemplate, transform);
            _backBar.gameObject.SetActive(true);

            //_backBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(_frontBarImage.fillAmount * _rectTransformWidth, _backBar.GetComponent<RectTransform>().anchoredPosition.y);

            var rightEdgeXCoordinate = _frontBarImage.fillAmount * _rectTransformWidth; //Calculation of front bar right edge X position
            var backBarRectTransform = _backBar.GetComponent<RectTransform>();
            backBarRectTransform.anchoredPosition = new Vector2(rightEdgeXCoordinate, backBarRectTransform.anchoredPosition.y);

            _backBar.GetComponent<Image>().fillAmount = _beforeSubstractionBarFillAmount - _frontBarImage.fillAmount;

            Debug.Log(_beforeSubstractionBarFillAmount);
        }

        private void SetHitShots(float hitShotsNormalized)
        {
            _frontBarImage.fillAmount = hitShotsNormalized;
        }

        private void CutBackBar()
        {

        }

        private void Substract()
        {
            _hitShotSystem.Substract(ScoresForShot);
        }

        private void Add()
        {
            _hitShotSystem.Add(ScoresForShot);
        }
    }
}


