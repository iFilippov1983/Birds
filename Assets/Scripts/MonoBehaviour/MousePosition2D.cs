using UnityEngine;

namespace Birds
{
    public class MousePosition2D : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;

        private Vector3 _mouseWorldPosition;

        private void Update()
        {
            _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _mouseWorldPosition.z = 0f;

            transform.position = _mouseWorldPosition;
        }
    }
}
