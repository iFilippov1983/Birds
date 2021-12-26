using System;
using System.Collections;
using UnityEngine;

namespace Birds
{
    public class HitShotsSystem
    {
        private int _hitShotsAmount;
        private int _hitShotsAmountMax;

        public HitShotsSystem(int hitShotsAmount)
        {
            _hitShotsAmountMax = hitShotsAmount;
            _hitShotsAmount = hitShotsAmount;
        }

        public Action OnSubstract;
        public Action OnAdd;

        public void Substract(int amount)
        {
            _hitShotsAmount -= amount;
            if (_hitShotsAmount < 0) _hitShotsAmount = 0;

            OnSubstract?.Invoke();
        }

        public void Add(int amount)
        {
            _hitShotsAmount += amount;
            if (_hitShotsAmount > _hitShotsAmountMax) _hitShotsAmount = _hitShotsAmountMax;

            OnAdd?.Invoke();
        }

        public float GetHitShotsNormalized()
        {
            return (float)_hitShotsAmount / _hitShotsAmountMax;
        }
    }
}

