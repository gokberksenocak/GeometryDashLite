using UnityEngine;

namespace Assets.DEV.Scripts.Movements
{
    public class HorizontalMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public float Speed { get => _speed; set => _speed = value; }

        void Update()
        {
            HorizontalMovement();
        }
        void HorizontalMovement()
        {
            transform.position += _speed * Time.deltaTime * Vector3.right;
        }
    }
}