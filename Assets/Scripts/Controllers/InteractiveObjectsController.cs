using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Birds
{
    public class InteractiveObjectsController : IInitialize, IExecute, IFixedExecute, ICleanup
    {
        private InteractiveObjectsData _interactiveObjectsData;

        public InteractiveObjectsController(GameData gameData)
        {
            _interactiveObjectsData = gameData.InateractiveObjectsData;
        }

        public void Initialize()
        {
            
        }

        public void Execute(float deltatime)
        {
            
        }

        public void FixedExecute()
        {
            
        }

        public void Cleanup()
        {
            
        }
    }
}
