using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/BirdProperties", fileName = "NameOfBird_Properties")]
    public class BirdProperties : ScriptableObject
    {
        [SerializeField] private float _minSizeMultiplyer;
        [SerializeField] private float _maxSizeMultiplyer;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private int _amountOnScene;

        public float MinSizeMultiplyer => _minSizeMultiplyer;
        public float MaxSizeMultiplyer => _maxSizeMultiplyer;
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;
        public int Amount => _amountOnScene;
    }
}
