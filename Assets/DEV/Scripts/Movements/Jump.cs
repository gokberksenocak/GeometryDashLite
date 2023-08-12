using Assets.DEV.Scripts.Managers;
using UnityEngine;

namespace Assets.DEV.Scripts.Movements
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private EffectManager _effectManager;
        [SerializeField] private float _jumpForce;
        private Rigidbody2D _playersRigidbody;
        private bool _atRoad;
        public bool AtRoad { get => _atRoad; set => _atRoad = value; }

        private void Awake()
        {
            _playersRigidbody = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            _inputManager.OnJump += Jumping;
        }
        private void OnDisable()
        {
            _inputManager.OnJump -= Jumping;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Road"))
            { 
                _atRoad = true;
                _effectManager.MoveParticle.Play();
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Road"))
            {
                _atRoad = false;
                _effectManager.MoveParticle.Stop();
            }
        }

        void Jumping()
        {
            if (_atRoad)
            {
                _playersRigidbody.velocity = Vector2.zero;
                _playersRigidbody.velocity = Vector2.up * _jumpForce;
            }
        }
    }
}