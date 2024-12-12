using SpaceShip.Scripts.Constants;
using System;
using TMPro;
using UnityEngine;

namespace SpaceShip.Scripts.Managers
{
    public class InfoManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _lvlText;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _goalText;

        private string _lvlPreset;
        private string _healthPreset;
        private string _scorePreset;
        private string _goalPreset;

        private void Start()
        {
            _lvlPreset = _lvlText.text;
            _healthPreset = _healthText.text;
            _scorePreset = _scoreText.text;
            _goalPreset = _goalText.text;

            _lvlText.text = String.Format(_lvlPreset, PlayerPrefs.GetInt(PlayerPrefsKeys.LevelKey));
            _healthText.text = String.Format(_healthPreset, 3);
            _scoreText.text = String.Format(_scorePreset, 0);
            _goalText.text = String.Format(_goalPreset, 0, PlayerPrefs.GetInt(PlayerPrefsKeys.AsteroidAmountKey));
        }

        public void UpdateHealth(int health)
        {
            _healthText.text = String.Format(_healthPreset, health);
        }

        public void UpdateScore(int score)
        {
            _scoreText.text = String.Format(_scorePreset, score);
        }

        public void UpdateGoal(int score)
        {
            _goalText.text = String.Format(_goalPreset, score, PlayerPrefs.GetInt(PlayerPrefsKeys.AsteroidAmountKey));
        }
    }
}