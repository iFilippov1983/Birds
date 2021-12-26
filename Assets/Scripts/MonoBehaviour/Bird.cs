using System;
using UnityEngine;

namespace Birds
{
    public class Bird : MonoBehaviour, IInteractive
    {
        private const string DataPath = "InteractiveObjects/";

        [SerializeField] private string _birdPropertisPath;

        private BirdProperties _properties;

        public BirdProperties Properties
        {
            get
            {
                if (_properties == null) _properties =
                             Resources.Load<BirdProperties>(DataPath + _birdPropertisPath);
                return _properties;
            }
        }

        public Action OnFinishEnter;
        public Action OnShot;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == HasTag.Finish)
            {
                gameObject.SetActive(false);

                OnFinishEnter?.Invoke();
            }

            if (collision.gameObject.tag == HasTag.PlayerMouseTarget)
            {

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Interact();

                    OnShot?.Invoke();
                } 
            }
        }

        public void Interact()
        {
            
        }
    }
}
