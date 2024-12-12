using SpaceShip.Scripts.Data;
using SpaceShip.Scripts.Interfaces;
using UnityEngine;

namespace SpaceShip.Scripts.Managers
{
    public class SaveManager : MonoBehaviour, ISaveManager
    {
        private LevelData _levelData;

        private void Start()
        {
            _levelData = new LevelData();

            Load();
        }

        public void Load()
        {
            _levelData.LoadDataFromFile(LevelData.Instance.FileName, _levelData);
        }

        public void Save()
        {
            _levelData.SaveToFile(LevelData.Instance.FileName, _levelData);
        }
    }
}