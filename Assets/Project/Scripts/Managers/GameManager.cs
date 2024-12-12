using SpaceShip.Scripts.Constants;
using SpaceShip.Scripts.Interfaces;
using UnityEngine;

namespace SpaceShip.Scripts.Managers
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        private const int MinAsteroidAmount = 10;
        private const int MaxAsteroidAmount = 51;
        private const int MinAsteroidSpeed = 10;
        private const int MaxAsteroidSpeed = 31;
        private const int MinShootFreqyency = 5;
        private const int MaxShootFreqyency = 10;
        private const float Multiplier = 0.1f;

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsKeys.LevelKey))
            {
                PlayerPrefs.SetInt(PlayerPrefsKeys.LevelKey, 1);
                SetUpLevel();
            }
        }

        private void SetUpLevel()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.AsteroidAmountKey,
                               Random.Range(MinAsteroidAmount, MaxAsteroidAmount));
            PlayerPrefs.SetFloat(PlayerPrefsKeys.AsteroidSpeedKey,
                                 Random.Range(MinAsteroidSpeed, MaxAsteroidSpeed) * Multiplier);
            PlayerPrefs.SetFloat(PlayerPrefsKeys.ShootFreqyencyKey,
                                 Random.Range(MinShootFreqyency, MaxShootFreqyency) * Multiplier);
        }

        public void NextLevel()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.LevelKey, PlayerPrefs.GetInt(PlayerPrefsKeys.LevelKey) + 1);
            SetUpLevel();
        }
    }
}