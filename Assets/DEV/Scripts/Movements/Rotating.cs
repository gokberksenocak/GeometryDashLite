using UnityEngine;

namespace Assets.DEV.Scripts.Movements
{
    public class Rotating : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Transform _playerBody;
        private Jump _jump;
        private Fly _fly;
        void Awake()
        {
            _fly = transform.GetChild(0).GetComponent<Fly>();
            _jump = GetComponent<Jump>();
        }
        void Update()
        {
            if (_jump.AtRoad && !_fly.AtFlyZone)
            {
                Vector3 rotationValue = _playerBody.rotation.eulerAngles;
                rotationValue.z = Mathf.Round(rotationValue.z / 90) * 90;
                _playerBody.rotation = Quaternion.Euler(rotationValue);
            }
            else if(!_jump.AtRoad && !_fly.AtFlyZone)
            {
                _playerBody.Rotate(_rotationSpeed * Time.deltaTime * Vector3.back);
            }
        }
    }
}