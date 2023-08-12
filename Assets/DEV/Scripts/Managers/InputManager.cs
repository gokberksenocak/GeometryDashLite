using Assets.DEV.Scripts.Movements;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.DEV.Scripts.Managers
{
    public class InputManager : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
    {
        [SerializeField] private Fly _fly;
        [SerializeField] private PlayerManager _playerManager;
        public event System.Action OnJump;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_fly.AtFlyZone && !_playerManager.IsHit)
            {
                OnJump?.Invoke();
            }
            else if(_fly.AtFlyZone && !_playerManager.IsHit)
            {
                _fly.IsRising = true;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_fly.AtFlyZone)
            {
                _fly.IsRising = false;
            }
        }
    }
}