using System;

namespace Birds
{
    public class ScoresSystem
    {
        private int _scoresAmount;
        private int _scoresAmountMax;

        public ScoresSystem(int scores)
        {
            _scoresAmountMax = scores;
            _scoresAmount = scores;
        }

        public Action OnSubstract;
        public Action OnAdd;

        public void Substract(int amount)
        {
            _scoresAmount -= amount;
            if (_scoresAmount < 0) _scoresAmount = 0;

            OnSubstract?.Invoke();
        }

        public void Add(int amount)
        {
            _scoresAmount += amount;
            if (_scoresAmount > _scoresAmountMax) _scoresAmount = _scoresAmountMax;

            OnAdd?.Invoke();
        }

        public float GetScoresNormalized()
        {
            return (float)_scoresAmount / _scoresAmountMax;
        }
    }
}

