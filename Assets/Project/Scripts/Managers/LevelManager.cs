using SpaceShip.Scripts.Constants;
using SpaceShip.Scripts.Data;
using SpaceShip.Scripts.Interfaces;
using SpaceShip.Scripts.Level;
using SpaceShip.Scripts.Pool;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace SpaceShip.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private AsteroidSpawner _spawner;

        [Header("End Game Events")]
        [SerializeField] private UnityEvent OnWinGame;
        [SerializeField] private UnityEvent OnLoseGame;

        [Header("UI Events")]
        [SerializeField] private UnityEvent<int> OnUpdateScore;
        [SerializeField] private UnityEvent<int> OnDestroyAsteroid;

        private bool _isLevelEnd = false;
        private int _score;
        private int _asteroidAmount;
        private float _gameTime;

        private ISaveManager _saveManager;

        [Inject]
        private void Constructor(ISaveManager saveManager)
        {
            _saveManager = saveManager;
        }

        private void Start()
        {
            _asteroidAmount = PlayerPrefs.GetInt(PlayerPrefsKeys.AsteroidAmountKey);
        }

        private void Update()
        {
            if(!_isLevelEnd) _spawner.SpawnAsteroid(UpdateScore, DestroyAsteroid);
            Timer();
        }

        private void UpdateScore()
        {
            _score++;
            OnUpdateScore?.Invoke(_score);
        }

        private void DestroyAsteroid()
        {
            _asteroidAmount--;
            OnDestroyAsteroid?.Invoke(_score);

            if (_asteroidAmount > 0) return;

            WinGame();
        }

        private void WinGame()
        {
            _isLevelEnd = true;
            OnWinGame?.Invoke();

            SaveLevel(true);
        }

        public void LoseGame()
        {
            _isLevelEnd = true;
            OnLoseGame?.Invoke();

            SaveLevel(false);
        }

        private void Timer()
        {
            if (_isLevelEnd) return;

            _gameTime += Time.deltaTime;
        }

        private void SaveLevel(bool isWin)
        {
            ResultData result = new ResultData()
            {
                Level = PlayerPrefs.GetInt(PlayerPrefsKeys.LevelKey),
                Time = Mathf.RoundToInt(_gameTime),
                Score = _score,
                IsWin = isWin
            };

            LevelData.Instance.AddResult(result);
            _saveManager.Save();
        }
    }
}