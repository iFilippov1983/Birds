using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class BarFade : MonoBehaviour
{
    private const int ShotsToGetBonus = 5;
    private const float FadeTimerMax = 1f;
    private const float FadeAmount = 5f;

    private Image _barImage;
    private Image _barSubstractImage;
    private Color _substractColor;
    private float _fadeTimer;
    private HitShotsSystem _hitShotSystem;

    private void Awake()
    {
        _barImage = transform.Find(UIElementName.Bar).GetComponent<Image>();
        _barSubstractImage = transform.Find(UIElementName.BarSubstract).GetComponent<Image>();
        _substractColor = _barSubstractImage.color;
        _substractColor.a = 0f;
        _barSubstractImage.color = _substractColor;
    }

    private void Start()
    {
        _hitShotSystem = new HitShotsSystem(ShotsToGetBonus);
        SetHitShots(_hitShotSystem.GetHitShotsNormalized());

        _hitShotSystem.OnAdd += HitShotAdd;
        _hitShotSystem.OnSubstract += HitShotSubstract;

        Button buttonS = transform.Find("SubstractButton").GetComponent<Button>();
        buttonS.onClick.AddListener(Substract);

        Button buttonA = transform.Find("AddButton").GetComponent<Button>();
        buttonA.onClick.AddListener(Add);

    }

    private void Update()
    {
        FadeSubsctactBar();
    }

    //private void HitShotAdd(object sender, System.EventArgs e)
    //{
    //    SetHitShots(_hitShotSystem.GetHitShotsNormalized());
    //}

    //private void HitShotSubstract(object sender, System.EventArgs e)
    //{
    //    SetSubstractBar();
    //    SetHitShots(_hitShotSystem.GetHitShotsNormalized());
    //}

    private void HitShotAdd()
    {
        SetHitShots(_hitShotSystem.GetHitShotsNormalized());
    }

    private void HitShotSubstract()
    {
        SetSubstractBar();
        SetHitShots(_hitShotSystem.GetHitShotsNormalized());
    }

    private void SetHitShots(float hitShotsNormalized)
    {
        _barImage.fillAmount = hitShotsNormalized;
    }

    private void FadeSubsctactBar()
    {
        if (_substractColor.a > 0)
        {
            _fadeTimer -= Time.deltaTime;
            if (_fadeTimer < 0)
            {
                _substractColor.a -= FadeAmount * Time.deltaTime;
                _barSubstractImage.color = _substractColor;
            }
        }
    }

    private void SetSubstractBar()
    {
        if (_substractColor.a <= 0)     
        {
            //Substract bar image is invisible
            _barSubstractImage.fillAmount = _barImage.fillAmount;
        }

        _substractColor.a = 1;
        _barSubstractImage.color = _substractColor;
        _fadeTimer = FadeTimerMax;
    }

    private void Substract()
    {
        _hitShotSystem.Substract(1);
    }

    private void Add()
    {
        _hitShotSystem.Add(1);
    }
}
