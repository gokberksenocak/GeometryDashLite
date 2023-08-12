using UnityEngine;
using TMPro;

namespace Assets.DEV.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
       
        [SerializeField] private PlayerManager _playerManager;
        public PlayerManager PlayerManager { get => _playerManager; set => _playerManager = value; }

        [SerializeField] private UIManager _uiManager;
        [SerializeField] private TextMeshPro _attempText;
        private int _attempt = 1;

        void Awake()
        {
            Singleton();
            _attempText.text = "Attempt " + _attempt.ToString();
        }
        
        private void OnEnable()
        {
            _uiManager.OnRestart += ResetAttemptDatas;
            _playerManager.OnHit += IncreaseAttempt;
            _playerManager.OnHit += InvokeToActivePlayer;
        }
        private void OnDisable()
        {
            _uiManager.OnRestart -= ResetAttemptDatas;
            _playerManager.OnHit -= IncreaseAttempt;
            _playerManager.OnHit -= InvokeToActivePlayer; ;
        }

        private void FixedUpdate()
        {
            _uiManager.ProgressBarMove();
            WinControl();   
        }

        private void WinControl()
        {
            if (_playerManager.gameObject.activeSelf && _playerManager.transform.position.x >= 104.5f)
            {
                _uiManager.OpenWinPanel();
            }
        }
        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        void MakeActiveToPlayer()
        {
            _playerManager.gameObject.SetActive(true);
        }

        void InvokeToActivePlayer()
        {
            Invoke(nameof(MakeActiveToPlayer), 1f);
        }
        void IncreaseAttempt()
        {
            _attempt++;
            _attempText.text = "Attempt " + _attempt.ToString();
        }
        void ResetAttemptDatas()
        {
            _attempt = 1;
            _attempText.text = "Attempt " + _attempt.ToString();
        }
    }
}