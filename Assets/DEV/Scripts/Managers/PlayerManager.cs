using Assets.DEV.Scripts.Movements;
using UnityEngine;

namespace Assets.DEV.Scripts.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private EffectManager _effectManager;
        private Rotating _rotating;
        private Fly _fly;
        private Rigidbody2D _playerRigidbody;
        private Vector3 _firstPosition;
        public event System.Action OnHit;
        private bool _isHit;
        public bool IsHit { get => _isHit; set => _isHit = value; }

        void Awake()
        {
            _fly = transform.GetChild(0).GetComponent<Fly>();
            _rotating = GetComponent<Rotating>();
            _playerRigidbody = GetComponent<Rigidbody2D>();
            _firstPosition = transform.position;
        }
        private void OnEnable()
        {
            OnHit += ReturnStartStateWithDelay;
        }
        private void OnDisable()
        {
            OnHit -= ReturnStartStateWithDelay;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                OnHit?.Invoke();
                _isHit = true;
                gameObject.SetActive(false);
            }
        }
        public void ResetToPlayerDatas()//oyunun duzgun sekilde tekrar baslayabilmesi icin yazildi
        {
            transform.SetPositionAndRotation(_firstPosition,Quaternion.Euler(Vector3.zero));
            transform.GetChild(1).rotation = Quaternion.Euler(Vector3.zero);
            _fly.AtFlyZone = false;
            _playerRigidbody.velocity = Vector2.zero;
            _playerRigidbody.gravityScale = 5f;
            _playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            _rotating.enabled = true;
            _effectManager.FlyParticle.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
            _isHit = false;
        }

        void ReturnStartStateWithDelay()
        {
            Invoke(nameof(ResetToPlayerDatas), 1f);
        }
    }
}