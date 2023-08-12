using UnityEngine;

namespace Assets.DEV.Scripts.Movements
{
    public class Fly : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playersRigidbody;
        public Rigidbody2D PlayersRigidbody { get => _playersRigidbody; set => _playersRigidbody = value; }

        
        private HorizontalMove _horizontalMove;
        public HorizontalMove HorizontalMove { get => _horizontalMove; set => _horizontalMove = value; }


        private bool _isRising;
        public bool IsRising { get => _isRising; set => _isRising = value; }
       

        private bool _atFlyZone;
        public bool AtFlyZone { get => _atFlyZone; set => _atFlyZone = value; }
        
        
        private float _angle;
        public float Angle { get => _angle; set => _angle = value; }

        [SerializeField] private float _shipFlySpeed;

        private void Awake()
        {
            HorizontalMove = transform.GetComponentInParent<HorizontalMove>();
        }

        void Update()
        {
            if (_atFlyZone)
            {
                FlightAndAngle();
            }
        }

        void FlightAndAngle()
        {
            transform.parent.rotation = Quaternion.Euler(0, 0, _playersRigidbody.velocity.y * 2);

            if (_isRising)
            {
                _playersRigidbody.gravityScale = -_shipFlySpeed;
            }
            else
            {
                _playersRigidbody.gravityScale = 2f;
            }
        }
    }
}