using SpaceShip.Scripts.Constants;
using SpaceShip.Scripts.Interfaces;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceShip.Scripts.UI
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _statistic;

        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _statisticButton;

        private string _levelPreset;

        private ISceneLoader _sceneLoader;

        [Inject]
        private void Constructor(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Start()
        {
            _levelPreset = _levelText.text;

            _levelText.text = String.Format(_levelPreset, PlayerPrefs.GetInt(PlayerPrefsKeys.LevelKey));

            _playButton.onClick.AddListener(OpenLevel);
            _statisticButton.onClick.AddListener(OpenStatistic);
        }

        private void OpenLevel()
        {
            _sceneLoader.OpenScene(SceneNames.LevelScene);
        }

        private void OpenStatistic()
        {
            _mainMenu.SetActive(false);
            _statistic.SetActive(true);
        }
    }
}