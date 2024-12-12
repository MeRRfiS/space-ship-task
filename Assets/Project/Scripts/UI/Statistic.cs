using SpaceShip.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShip.Scripts.UI
{
    public class Statistic : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _statistic;
        [SerializeField] private Button _closeButton;

        [Header("Result List")]
        [SerializeField] private Result _resultPrefab;
        [SerializeField] private Transform _content;

        private void Start()
        {
            _closeButton.onClick.AddListener(CloseStatistic);

            CreateResultInformations();
        }

        private void CreateResultInformations()
        {
            if (_content.childCount > 0) return;

            var resultDatas = LevelData.Instance.Results;

            foreach (var resultData in resultDatas)
            {
                var result = Instantiate(_resultPrefab, _content);
                result.Level = resultData.Level;
                result.Time = resultData.Time;
                result.Score = resultData.Score;
                result.IsWin = resultData.IsWin;
            }
        }

        private void CloseStatistic()
        {
            _mainMenu.SetActive(true);
            _statistic.SetActive(false);
        }
    }
}