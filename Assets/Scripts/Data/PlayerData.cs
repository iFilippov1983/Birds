using UnityEngine;

namespace Birds
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        private const string DataPath = "Player/";

        [SerializeField] private string _mousePoritionPrefabPath;

        private GameObject _mousePositionObject;

        public GameObject MousePositionObject
        {
            get
            {
                if (_mousePositionObject == null) _mousePositionObject =
                             Resources.Load<GameObject>(DataPath + _mousePoritionPrefabPath);
                return _mousePositionObject;
            }
        }
    }
}
