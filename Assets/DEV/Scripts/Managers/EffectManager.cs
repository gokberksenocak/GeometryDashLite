using UnityEngine;

namespace Assets.DEV.Scripts.Managers
{
    public class EffectManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform _playerBody;
        [SerializeField] private Transform _playerShip;
        [SerializeField] private GameObject _explodeParticle;
        
        [SerializeField] private ParticleSystem _flyParticle;
        public ParticleSystem FlyParticle { get => _flyParticle; set => _flyParticle = value; }

        [SerializeField] private ParticleSystem _moveParticle;
        public ParticleSystem MoveParticle { get => _moveParticle; set => _moveParticle = value; }

        private void OnEnable()
        {
            _gameManager.PlayerManager.OnHit += ShowExplodeEffect;
        }
        private void OnDisable()
        {
            _gameManager.PlayerManager.OnHit -= ShowExplodeEffect;
        }

        void ShowExplodeEffect()
        {
            _explodeParticle.transform.position = _gameManager.PlayerManager.transform.position;
            _playerShip.gameObject.SetActive(false);
            _explodeParticle.GetComponent<ParticleSystem>().Play();
        }
    }
}