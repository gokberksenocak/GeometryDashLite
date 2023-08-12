using UnityEngine;
using UnityEngine.UI;

namespace Assets.DEV.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _progressBarImage;
        [SerializeField] private GameObject _soundsOnButton;
        [SerializeField] private GameObject _soundsOffButton;
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _gameManager;
        public event System.Action OnRestart;

        public void StartGame()
        {
            _gameManager.SetActive(true);
            _startPanel.SetActive(false);
            _player.SetActive(true);
        }

        public void SoundSettings(int volume)
        {
            AudioListener.volume = volume;
            if (volume==0)
            {
                _soundsOnButton.SetActive(false);
                _soundsOffButton.SetActive(true);
            }
            else if (volume==1)
            {
                _soundsOnButton.SetActive(true);
                _soundsOffButton.SetActive(false);
            }
        }

        public void OpenWinPanel()
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void RestartGame()
        {
            OnRestart?.Invoke();
            _winPanel.SetActive(false);
            _player.GetComponent<PlayerManager>().ResetToPlayerDatas();
            Time.timeScale = 1;
        }

        public void ProgressBarMove()
        {
            _progressBarImage.fillAmount = (118 - (104 - _player.transform.position.x)) / 118;// [toplam yol-(son nokta-mevcut nokta)] / % toplam yolda orani
        }
    }
}