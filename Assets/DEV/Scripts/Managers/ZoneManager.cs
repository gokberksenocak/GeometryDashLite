using Assets.DEV.Scripts.Movements;
using UnityEngine;

namespace Assets.DEV.Scripts.Managers
{
    public class ZoneManager : MonoBehaviour
    {
        [SerializeField] private EffectManager _effectManager;
        [SerializeField] private Fly _fly;
        [SerializeField] private Transform _body;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerManager>()!=null)
            {
                _effectManager.FlyParticle.gameObject.SetActive(true);
                _fly.transform.GetComponentInParent<Rotating>().enabled = false;
                _fly.gameObject.SetActive(true);
                _fly.PlayersRigidbody.gravityScale = 1.5f;
                _fly.PlayersRigidbody.constraints = RigidbodyConstraints2D.None;
                _fly.Angle = 0f;
                _body.rotation = Quaternion.Euler(Vector3.zero);
                _fly.AtFlyZone = true;
            }
        }
    }
}