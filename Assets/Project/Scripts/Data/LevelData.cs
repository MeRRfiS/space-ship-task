using System;
using System.Collections.Generic;

namespace SpaceShip.Scripts.Data
{
    [Serializable]
    public class LevelData : SaveData
    {
        public static LevelData Instance;
        public List<ResultData> Results = new List<ResultData>();

        public readonly string FileName = "levelData.dat";

        private const int MaxListCount = 10;

        public LevelData() 
        {
            Instance = this;
        }

        public void AddResult(ResultData result)
        {
            if(Results.Count >= MaxListCount)
            {
                Results.RemoveAt(0);
            }

            Results.Add(result);
        }
    }
}