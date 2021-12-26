using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _mousePosition;

        public GameObject MousePosition => _mousePosition;
    }
}
